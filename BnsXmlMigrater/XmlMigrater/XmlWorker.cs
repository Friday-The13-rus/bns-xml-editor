using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using XmlMigrater.Properties;

namespace XmlMigrater
{
	public static class XmlWorker
	{
		static bool ValidateDocument(XDocument document, bool isTranslate)
		{
			int errorsCount = 0;
			XmlSchemaSet schemaSet = new XmlSchemaSet();
			schemaSet.Add("", new XmlTextReader(new StringReader(isTranslate ? Resources.translate : Resources.original)));
			document.Validate(schemaSet, (sender, args) =>
			{
				errorsCount++;
				if (errorsCount <= 20)
					Console.WriteLine(args.Message);
			});

			return errorsCount > 0;
		}

		public static List<OriginalItem> ReadOriginalFile(string path)
		{
			XDocument doc = XDocument.Load(path, LoadOptions.PreserveWhitespace);
			
			if (ValidateDocument(doc, false))
				throw new XmlSchemaValidationException();

			XElement el = doc.Root;

			return el.Elements().Select(OriginalItem.Create).ToList();
		}

		public static Dictionary<string, OriginalItem> ReadOriginalFileAlias(string path)
		{
			XDocument doc = XDocument.Load(path);
			XElement el = doc.Root;

			Dictionary<string, OriginalItem> temp = new Dictionary<string, OriginalItem>();
			foreach (XElement elem in el.Elements())
			{
				if (!temp.ContainsKey(elem.Element("alias").Value))
				{
					temp.Add(elem.Element("alias").Value, OriginalItem.Create(elem));
				}
			}
			return temp;
		}

		public static SortedList<int, TranslatedItem> ReadTranslateFile(string path)
		{
			XDocument doc = XDocument.Load(path);
			if (ValidateDocument(doc, true))
				throw new XmlSchemaValidationException();
			XElement el = doc.Root;

			List<TranslatedItem> temp = new List<TranslatedItem>();
			foreach (XElement elem in el.Elements())
			{
				temp.Add(new TranslatedItem(elem.Element("autoId").Value, elem.Element("alias").Value, elem.Element("original").Value, elem.Element("replacement").Value));
			}
			return new SortedList<int, TranslatedItem>(temp.ToDictionary(elem => int.Parse(elem.AutoId)));
		}

		public static void WriteOnlyChineseText(List<OriginalItem> original, string path)
		{
			using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
			{
				foreach (OriginalItem text in original)
				{
					writer.WriteLine(text.Text);
				}
			}
		}

		public static List<TranslatedItem> CreateNewTranslateFile(List<OriginalItem> original)
		{
			return original.Select(e => new TranslatedItem(e.AutoId, e.Alias, e.Text, e.Text)).ToList();
		}

		public static bool CheckTranslate(List<OriginalItem> original, SortedList<int, TranslatedItem> translated)
		{
			if (original.Count != translated.Count)
				return false;

			for (int i = 0; i < original.Count; i++)
			{
				if (original[i].Alias != translated[i + 1].Alias)
					return false;
			}

			return true;
		}

		public static void SaveToXml(IEnumerable<IXLinqCompatible> collection, string path)
		{
			XElement texts = new XElement("text");

			foreach (IXLinqCompatible line in collection)
			{
				texts.Add(line.GetXElement());
			}

			texts.Save(path);
		}

		public static void ReassignId(List<OriginalItem> original, SortedList<int, TranslatedItem> translated, out List<TranslatedItem> result, out List<InvalidItem> invalidTranslate)
		{
			ConcurrentBag<TranslatedItem> tempResult = new ConcurrentBag<TranslatedItem>();
			ConcurrentBag<InvalidItem> tempInvalidTranslate = new ConcurrentBag<InvalidItem>();

			const string replaceSymbols = @"[、。，.,一1二2三3四4五5六6七7八8九9段()【】]|ур|\sЗапечатанный\s|封印|\sшт|个|(?<=\s)\s";
			Regex trimmer = new Regex(replaceSymbols, RegexOptions.Compiled | RegexOptions.Singleline);

			original.AsParallel().ForAll(line =>
				{
					if (line.Alias == "Mission.Name2.1400_1")
						Debugger.Break();

					string findedOriginalText;
					string translate = GetTranslateValue(line, translated, out findedOriginalText);

					if (findedOriginalText != line.Text)
					{
						string trimmedTranslate = trimmer.Replace(translate, string.Empty);
						string trimmedFindedOriginal = trimmer.Replace(findedOriginalText, string.Empty);

						if (trimmedTranslate != trimmedFindedOriginal)
							tempInvalidTranslate.Add(new InvalidItem(line.AutoId, line.Alias, findedOriginalText, translate, line.Text));
					}

					//if (!TranslateIsValid(line.text, translate))
					//{
					//	tempInvalidTranslate.Add(new InvalidItem(line.autoId, line.alias, findedOriginalText, translate, line.text));
					//	translate = line.text;
					//}

					tempResult.Add(new TranslatedItem(line.AutoId, line.Alias, line.Text, translate));
				});

			result = tempResult.OrderBy(elem => int.Parse(elem.AutoId)).ToList();
			invalidTranslate = tempInvalidTranslate.OrderBy(elem => int.Parse(elem.AutoId)).ToList();
		}

		static bool TranslateIsValid(string original, string translate)
		{
			return original.Count(ch => ch == '<') == translate.Count(ch => ch == '<');
		}

		static string GetTranslateValue(OriginalItem line, SortedList<int, TranslatedItem> translated, out string findedOriginalText)
		{
			TranslatedItem element;
			if (translated.TryGetValue(int.Parse(line.AutoId), out element) && line.Alias == element.Alias)
			{
				findedOriginalText = element.Text;
				return element.Translate;
			}

			int elementIndex = int.Parse(line.AutoId) - 1;
			if (elementIndex >= translated.Count)
				elementIndex = translated.Count - 1;

			for (int i = elementIndex; i >= 0; i--)
			{
				TranslatedItem value = translated.Values[i];
				if (value.Alias == line.Alias)
				{
					findedOriginalText = value.Text;
					return value.Translate;
				}
			}

			for (int i = elementIndex; i < translated.Values.Count; i++)
			{
				TranslatedItem value = translated.Values[i];
				if (value.Alias == line.Alias)
				{
					findedOriginalText = value.Text;
					return value.Translate;
				}
			}

			findedOriginalText = line.Text;
			return line.Text;
		}

		public static void GetNewStrings(List<OriginalItem> original, List<TranslatedItem> translated, Action<int> Progress, out List<TranslatedItem> result, out List<InvalidItem> invalidTranslate)
		{
			List<TranslatedItem> tempResult = new List<TranslatedItem>();
			List<InvalidItem> tempInvalid = new List<InvalidItem>();

			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.WorkerSupportsCancellation = false;
			worker.ProgressChanged += ((object sender, ProgressChangedEventArgs e) =>
			{
				Progress(e.ProgressPercentage);
			});
			worker.DoWork += ((object sender, DoWorkEventArgs e) =>
			{
				int countLines = original.Count;
				double i = 0;
				foreach (OriginalItem line in original)
				{
					int percent = (int)Math.Round(i / countLines * 100);
					(sender as BackgroundWorker).ReportProgress(percent);
					i++;

					if (translated.Exists(elem => elem.AutoId == line.AutoId))
					{
						TranslatedItem elem = translated.First(item => item.AutoId == line.AutoId);
						if (elem.Text != line.Text)
						{
							tempResult.Add(new TranslatedItem(line.AutoId, line.Alias, line.Text, line.Text));
							tempInvalid.Add(new InvalidItem(line.AutoId, line.Alias, elem.Text, elem.Translate, line.Text));
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
			});
			worker.RunWorkerAsync();

			while (worker.IsBusy)
			{
			};

			result = tempResult;
			invalidTranslate = tempInvalid;
		}

		public static List<TranslatedItem> ReassignTranslate(Dictionary<string, OriginalItem> original, SortedList<int, TranslatedItem> translated)
		{
			List<TranslatedItem> tempResult = new List<TranslatedItem>();

			Regex regex = new Regex("<(image|font).*?>", RegexOptions.Compiled | RegexOptions.Singleline);

			foreach (KeyValuePair<int, TranslatedItem> line in translated)
			{
				OriginalItem value;

				if (original.TryGetValue(line.Value.Alias, out value) && value.Text.Length > 0 && value.Text[0] != '#' &&
					AllTagsIsEquals(regex, line.Value.Text, value.Text) &&
					(ContainsOneOfMoreChineseChars(line.Value.Translate) || // есть хотябы один китайский
					!ContainsOneOfMoreRussianChars(line.Value.Translate))	// нету ни одного русского
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

		static bool ContainsOneOfMoreChineseChars(string line)
		{
			return line.Any(elem => elem >= '\u4E00' && elem <= '\u9FFF');
		}

		static bool ContainsOneOfMoreRussianChars(string line)
		{
			return line.Any(elem => elem >= '\u0401' && elem <= '\u0451');
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

		public static List<TranslatedItem> RepairTags(SortedList<int, TranslatedItem> translated, out List<TranslatedItem> invalidTags)
		{
			List<TranslatedItem> result = new List<TranslatedItem>();
			invalidTags = new List<TranslatedItem>();
			Regex regex = new Regex("<(image|font).*?>", RegexOptions.Compiled | RegexOptions.Singleline);

			List<string> userTags = new List<string>
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
					if (!ContainsOneOfMoreRussianChars(repairedTranslate))
					{
						result.Add(new TranslatedItem(line.Value.AutoId, line.Value.Alias, line.Value.Text, line.Value.Text));
					}
					else
					{
						invalidTags.Add(line.Value);
						result.Add(line.Value);
					}
				}
				else
				{
					result.Add(new TranslatedItem(line.Value.AutoId, line.Value.Alias, line.Value.Text, repairedTranslate));
				}
			}

			return result;
		}

		public static List<TranslatedItem> ReplaceKoreianTranslate(SortedList<int, TranslatedItem> translated)
		{
			List<TranslatedItem> result = new List<TranslatedItem>();
			foreach (KeyValuePair<int, TranslatedItem> item in translated)
			{
				if (item.Value.Translate.Any(el => el >= '\uAC00' && el <= '\uD7AF')) //Слоги Хангыля AC00—D7AF
					result.Add(new TranslatedItem(item.Value.AutoId, item.Value.Alias, item.Value.Text, item.Value.Text));
				else
					result.Add(item.Value);
			}
			return result;
		}
	}
}