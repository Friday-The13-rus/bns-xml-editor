using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace BnsXmlEditor
{
	class BnsTranslateFile
	{
		public List<TranslatableItem> Elements { get; protected set; }

		string openedPath;

		BnsTranslateFile()
		{
		}

		public static BnsTranslateFile Load(string path)
		{
			BnsTranslateFile file = new BnsTranslateFile();
			file.Open(path);
			return file;
		}

		void Open(string path)
		{
			openedPath = path;

			XDocument doc = XDocument.Load(path);
			XElement el = doc.Root;

			Elements = new List<TranslatableItem>();

			foreach (XElement elem in el.Elements())
			{
				int autoId = int.Parse(elem.Element("autoId").Value);
				string alias = elem.Element("alias").Value;
				string original = elem.Element("original").Value;
				string translate = elem.Element("replacement").Value;

				Elements.Add(new TranslatableItem(autoId, alias, original, translate));
			}
		}

		public void Save()
		{
			Save(openedPath);
		}

		public void Save(string path)
		{
			XElement texts = new XElement("text");

			foreach (TranslatableItem line in Elements)
			{
				texts.Add(new XElement("TEXT",
					new XElement("autoId", line.AutoId),
					new XElement("alias", line.Alias),
					new XElement("original", line.Original),
					new XElement("replacement", line.Translate)
				));
			}

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.OmitXmlDeclaration = true;
			settings.Encoding = System.Text.Encoding.UTF8;
			settings.Indent = true;

			using (XmlWriter xw = XmlWriter.Create(path, settings))
			{
				texts.Save(xw);
			}
		}

		public List<TranslatableItem> Find(string value, TranslatableItem.Fields field, bool isRegex, bool isIgnoreCase)
		{
			Predicate<TranslatableItem> matcher;

			if (isRegex)
			{
				Regex regex = CreateRegex(value, isIgnoreCase);

				switch (field)
				{
					case TranslatableItem.Fields.Alias:
						matcher = item => regex.IsMatch(item.Alias);
						break;

					case TranslatableItem.Fields.Original:
						matcher = item => regex.IsMatch(item.Original);
						break;

					case TranslatableItem.Fields.Translate:
						matcher = item => regex.IsMatch(item.Translate);
						break;

					default:
						throw new ArgumentException("Поиск по autoId не реализован.");
				}
			}
			else
			{
				StringComparison comparisonType = GetComparison(isIgnoreCase);

				switch (field)
				{
					case TranslatableItem.Fields.Alias:
						matcher = item => Compare(item.Alias, value, comparisonType);
						break;

					case TranslatableItem.Fields.Original:
						matcher = item => Compare(item.Original, value, comparisonType);
						break;

					case TranslatableItem.Fields.Translate:
						matcher = item => Compare(item.Translate, value, comparisonType);
						break;

					default:
						throw new ArgumentException("Поиск по autoId не реализован.");
				}
			}

			return Elements.FindAll(matcher);
		}

		private static StringComparison GetComparison(bool isIgnoreCase)
		{
			return isIgnoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
		}

		private static Regex CreateRegex(string pattern, bool isIgnoreCase)
		{
			RegexOptions options = RegexOptions.Compiled | RegexOptions.Singleline;
			if (isIgnoreCase)
				options |= RegexOptions.IgnoreCase;

			return new Regex(pattern, options);
		}

		public List<TranslatableItem> Replace(string pattern, string replacement, bool isRegex, bool isIgnoreCase)
		{
			List<TranslatableItem> result = Find(pattern, TranslatableItem.Fields.Translate, isRegex, isIgnoreCase);
			if (isRegex)
			{
				Regex regex = CreateRegex(pattern, isIgnoreCase);
				result.AsParallel().ForAll(item => item.Translate = regex.Replace(item.Translate, replacement));
			}
			else
			{
				StringComparison comparisonType = GetComparison(isIgnoreCase);
				result.AsParallel().ForAll(item => item.Translate = Replace(item.Translate, pattern, replacement, comparisonType));
			}

			return result;
		}

		public List<string> GetGroups()
		{
			return GetGroups(Elements);
		}

		public List<string> GetGroups(List<TranslatableItem> items)
		{
			return items.Select(elem => elem.Alias.Split('.')[0]).Distinct().ToList();
		}

		bool Compare(string strA, string strB, StringComparison comparisonType)
		{
			return strA.IndexOf(strB, comparisonType) >= 0;
		}

		string Replace(string original, string pattern, string replacement, StringComparison comparisonType)
		{
			if (pattern == replacement)
				return original;

			int position = 0;

			do
			{
				position = original.IndexOf(pattern, position, comparisonType);
				if (position != -1)
				{
					original = original.Remove(position, pattern.Length).Insert(position, replacement);
					position += pattern.Length;
					if (position > original.Length)
						position = original.Length;
				}
			}
			while (position != -1);

			return original;
		}
	}
}