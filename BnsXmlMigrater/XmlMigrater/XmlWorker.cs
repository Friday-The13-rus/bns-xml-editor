using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XmlMigrater
{
	public static class XmlWorker
	{
		#region Dal methods

		public static IEnumerable<OriginalItem> ReadOriginalFile(string path)
		{
			return DataAccessLayer.ReadOriginalFile(path);
		}

		public static Dictionary<string, OriginalItem> ReadOriginalFileAlias(string path)
		{
			return DataAccessLayer.ReadOriginalFileAlias(path);
		}

		public static SortedList<int, TranslatedItem> ReadTranslateFile(string path)
		{
			return DataAccessLayer.ReadTranslateFile(path);
		}

		public static void WriteOnlyChineseText(IEnumerable<OriginalItem> original, string path)
		{
			DataAccessLayer.WriteOnlyChineseText(original, path);
		}

		public static void SaveToXml(IEnumerable<IXLinqCompatible> collection, string path)
		{
			DataAccessLayer.SaveToXml(collection, path);
		}

		public static void SaveToBinary(object collection, string path)
		{
			DataAccessLayer.SaveToBinary(collection, path);
		}

		#endregion

		public static IEnumerable<TranslatedItem> CreateNewTranslateFile(IEnumerable<OriginalItem> original)
		{
			return original.Select(e => new TranslatedItem(e)).ToList();
		}

		public static bool CheckTranslate(List<OriginalItem> original, SortedList<int, TranslatedItem> translated)
		{
			if (original.Count != translated.Count)
				return false;

			return !original.Where((t, i) => t.Alias != translated[i + 1].Alias).Any();
		}

		public static void ReassignId(IEnumerable<OriginalItem> original, SortedList<int, TranslatedItem> translated, 
			out IEnumerable<TranslatedItem> result, out IEnumerable<InvalidTranslateItem> invalidTranslate)
		{
			ConcurrentBag<TranslatedItem> tempResult = new ConcurrentBag<TranslatedItem>();
			ConcurrentBag<InvalidTranslateItem> tempInvalidTranslate = new ConcurrentBag<InvalidTranslateItem>();

			const string replaceSymbols = @"[、。，.,一1二2三3四4五5六6七7八8九9段()【】]|ур|\sЗапечатанный\s|封印|\sшт|个|(?<=\s)\s";
			Regex trimmer = new Regex(replaceSymbols, RegexOptions.Compiled | RegexOptions.Singleline);

			original.AsParallel().ForAll(line =>
				{
					string findedOriginalText;
					string translate = GetTranslateValue(line, translated, out findedOriginalText);

					if (findedOriginalText != line.Text)
					{
						string trimmedTranslate = trimmer.Replace(translate, string.Empty);
						string trimmedFindedOriginal = trimmer.Replace(findedOriginalText, string.Empty);

						if (trimmedTranslate != trimmedFindedOriginal)
							tempInvalidTranslate.Add(new InvalidTranslateItem(line.AutoId, line.Alias, findedOriginalText, translate, line.Text));
					}

					//if (!TranslateIsValid(line.text, translate))
					//{
					//	tempInvalidTranslate.Add(new InvalidTranslateItem(line.autoId, line.alias, findedOriginalText, translate, line.text));
					//	translate = line.text;
					//}

					tempResult.Add(new TranslatedItem(line.AutoId, line.Alias, line.Text, translate));
				});

			result = tempResult.OrderBy(elem => elem.AutoId).ToList();
			invalidTranslate = tempInvalidTranslate.OrderBy(elem => elem.AutoId).ToList();
		}

		static bool TranslateIsValid(string original, string translate)
		{
			return original.Count(ch => ch == '<') == translate.Count(ch => ch == '<');
		}

		static string GetTranslateValue(OriginalItem line, SortedList<int, TranslatedItem> translated, out string findedOriginalText)
		{
			TranslatedItem element;
			if (translated.TryGetValue(line.AutoId, out element) && line.Alias == element.Alias)
			{
				findedOriginalText = element.Text;
				return element.Translate;
			}

			int elementIndex = line.AutoId - 1;
			if (elementIndex >= translated.Count)
				elementIndex = translated.Count - 1;

			for (int i = elementIndex; i >= 0; i--)
			{
				TranslatedItem value = translated.Values[i];
				if (value.Alias != line.Alias) 
					continue;

				findedOriginalText = value.Text;
				return value.Translate;
			}

			for (int i = elementIndex; i < translated.Values.Count; i++)
			{
				TranslatedItem value = translated.Values[i];
				if (value.Alias != line.Alias) 
					continue;

				findedOriginalText = value.Text;
				return value.Translate;
			}

			findedOriginalText = line.Text;
			return line.Text;
		}

		public static void GetNewStrings(IEnumerable<OriginalItem> original, IEnumerable<TranslatedItem> translated, 
			out IEnumerable<TranslatedItem> result, out IEnumerable<InvalidTranslateItem> invalidTranslate)
		{
			List<TranslatedItem> tempResult = new List<TranslatedItem>();
			List<InvalidTranslateItem> tempInvalid = new List<InvalidTranslateItem>();

			foreach (OriginalItem line in original)
			{
				TranslatedItem elem = translated.FirstOrDefault(item => item.AutoId == line.AutoId);
				if (elem != null)
				{
					if (elem.Text != line.Text)
					{
						tempResult.Add(new TranslatedItem(line.AutoId, line.Alias, line.Text, line.Text));
						tempInvalid.Add(new InvalidTranslateItem(line.AutoId, line.Alias, elem.Text, elem.Translate, line.Text));
					}
					else
					{
						tempResult.Add(new TranslatedItem(line.AutoId, line.Alias, line.Text, elem.Translate));
					}
				}
				else
				{
					tempResult.Add(new TranslatedItem(line.AutoId, line.Alias, line.Text, line.Text));
				}
			}

			result = tempResult;
			invalidTranslate = tempInvalid;
		}

		public static IEnumerable<TranslatedItem> ReassignTranslate(IDictionary<string, OriginalItem> original, IDictionary<int, TranslatedItem> translated)
		{
			List<TranslatedItem> tempResult = new List<TranslatedItem>();

			Regex regex = new Regex("<(image|font).*?>", RegexOptions.Compiled | RegexOptions.Singleline);

			foreach (KeyValuePair<int, TranslatedItem> line in translated)
			{
				OriginalItem value;

				if (original.TryGetValue(line.Value.Alias, out value) && 
					string.IsNullOrEmpty(value.Text) && 
					value.Text[0] != '#' &&
					AllTagsIsEquals(regex, line.Value.Text, value.Text) &&
					(ContainsAnyChineseChar(line.Value.Translate) || !ContainsAnyRussianChar(line.Value.Translate))
				   )  
				{
					tempResult.Add(new TranslatedItem(line.Value.AutoId, line.Value.Alias, line.Value.Text, value.Text));
				}
				else
				{
					tempResult.Add(new TranslatedItem(line.Value.AutoId, line.Value.Alias, line.Value.Text, line.Value.Translate));
				}
			}

			return tempResult;
		}

		static bool ContainsAnyChineseChar(string line)
		{
			return line.Any(elem => elem >= '\u4E00' && elem <= '\u9FFF');
		}

		static bool ContainsAnyRussianChar(string line)
		{
			return line.Any(elem => elem >= '\u0401' && elem <= '\u0451');
		}

		static bool ContainsAnyKoreanChar(string line)
		{
			return line.Any(el => el >= '\uAC00' && el <= '\uD7AF'); //Слоги Хангыля AC00—D7AF
		}

		static bool AllTagsIsEquals(Regex regex, string original, string translated)
		{
			MatchCollection originalTags = regex.Matches(original);
			MatchCollection translatedTags = regex.Matches(translated);

			if (originalTags.Count != translatedTags.Count)
				return false;

			for (int i = 0; i < originalTags.Count; i++)
				if (originalTags[i].Value != translatedTags[i].Value)
					return false;

			return true;
		}

		static bool TryRepairTags(Regex regex, string original, string translated, out string repairedTranslate)
		{
			MatchCollection originalTags = regex.Matches(original);
			MatchCollection translatedTags = regex.Matches(translated);

			repairedTranslate = translated;
			
			if (originalTags.Count != translatedTags.Count)
				return false;

			for (int i = 0; i < originalTags.Count; i++)
				if (originalTags[i].Value != translatedTags[i].Value)
				{
					string originalTag = originalTags[i].Value;
					string translatedTag = translatedTags[i].Value;

					if ((originalTag.Contains("image") && translatedTag.Contains("font")) ||
					(originalTag.Contains("font") && translatedTag.Contains("image")))
						return false;

					repairedTranslate = repairedTranslate.Replace(translatedTag, originalTag);
				}

			return true;
		}

		public static IEnumerable<TranslatedItem> RepairTags(IEnumerable<KeyValuePair<int, TranslatedItem>> translated, out IEnumerable<TranslatedItem> invalidTags)
		{
			List<TranslatedItem> result = new List<TranslatedItem>();
			List<TranslatedItem> tempInvalidTags = new List<TranslatedItem>();
			Regex regex = new Regex("<(image|font).*?>", RegexOptions.Compiled | RegexOptions.Singleline);

			HashSet<string> userTags = new HashSet<string>
			{
				"<image enablescale=\"true\" imagesetpath=\"00009076.Tooltip_Growth\" scalerate=\"1.3\"/>",
				"<image enablescale=\"true\" imagesetpath=\"00009076.Production_SungDunDang\" scalerate=\"1.3\"/>",
				"<image enablescale=\"true\" imagesetpath=\"00009076.Tooltip_BreakMaterial\" scalerate=\"1.3\"/>"
			};

			foreach (KeyValuePair<int, TranslatedItem> line in translated)
			{
				string repairedTranslate;
				if (!TryRepairTags(regex, line.Value.Text, line.Value.Translate, out repairedTranslate) && 
					!userTags.Any(el => repairedTranslate.Contains(el))) 
				{
					if (!ContainsAnyRussianChar(repairedTranslate))
					{
						result.Add(new TranslatedItem(line.Value.AutoId, line.Value.Alias, line.Value.Text, line.Value.Text));
					}
					else
					{
						tempInvalidTags.Add(line.Value);
						result.Add(line.Value);
					}
				}
				else
				{
					result.Add(new TranslatedItem(line.Value.AutoId, line.Value.Alias, line.Value.Text, repairedTranslate));
				}
			}

			invalidTags = tempInvalidTags;
			return result;
		}

		public static IEnumerable<TranslatedItem> ReplaceKoreanTranslate(IDictionary<int, TranslatedItem> translated)
		{
			List<TranslatedItem> result = new List<TranslatedItem>();
			foreach (KeyValuePair<int, TranslatedItem> item in translated)
			{
				if (ContainsAnyKoreanChar(item.Value.Translate)) //Слоги Хангыля AC00—D7AF
					result.Add(new TranslatedItem(item.Value.AutoId, item.Value.Alias, item.Value.Text, item.Value.Text));
				else
					result.Add(item.Value);
			}
			return result;
		}
	}
}