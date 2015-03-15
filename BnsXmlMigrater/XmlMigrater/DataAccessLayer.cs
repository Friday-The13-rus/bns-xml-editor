using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using XmlMigrater.Properties;

namespace XmlMigrater
{
	static class DataAccessLayer
	{
		private static bool ValidateDocument(XDocument document, bool isTranslate)
		{
			int errorsCount = 0;
			XmlSchemaSet schemaSet = new XmlSchemaSet();
			schemaSet.Add(String.Empty, new XmlTextReader(new StringReader(isTranslate ? Resources.translate : Resources.original)));
			document.Validate(schemaSet, (sender, args) =>
			{
				errorsCount++;
				if (errorsCount <= 20)
					Console.WriteLine(args.Message);
			});

			return errorsCount > 0;
		}

		public static IEnumerable<OriginalItem> ReadOriginalFile(string path)
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
			foreach (OriginalItem item in el.Elements().Select(OriginalItem.Create).Where(item => !temp.ContainsKey(item.Alias)))
			{
				temp.Add(item.Alias, item);
			}
			return temp;
		}

		public static SortedList<int, TranslatedItem> ReadTranslateFile(string path)
		{
			XDocument doc = XDocument.Load(path);
			if (ValidateDocument(doc, true))
				throw new XmlSchemaValidationException();
			XElement el = doc.Root;

			List<TranslatedItem> temp = el.Elements().Select(TranslatedItem.Create).ToList();
			return new SortedList<int, TranslatedItem>(temp.ToDictionary(elem => elem.AutoId));
		}

		public static void WriteOnlyChineseText(IEnumerable<OriginalItem> original, string path)
		{
			using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
			{
				foreach (OriginalItem text in original)
				{
					writer.WriteLine(text.Text);
				}
			}
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

		public static void SaveToBinary(object collection, string path)
		{
			using (FileStream stream = new FileStream(path, FileMode.Create))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, collection);
			}
		}
	}
}
