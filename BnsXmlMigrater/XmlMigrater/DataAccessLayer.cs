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
		private static bool ValidateDocument(XDocument document, string schema)
		{
			bool isValid = true;

			using (StreamWriter validationErrorsLog = new StreamWriter("shemaValidationErrors.txt", true))
			{
				XmlSchemaSet schemaSet = new XmlSchemaSet();
				schemaSet.Add(String.Empty, new XmlTextReader(new StringReader(schema)));
				document.Validate(schemaSet, (sender, args) =>
				{
					isValid = false;
					validationErrorsLog.WriteLine(args.Message);
				});
			}

			return isValid;
		}

		public static IEnumerable<OriginalItem> ReadOriginalFile(string path)
		{
			XDocument doc = XDocument.Load(path, LoadOptions.PreserveWhitespace);

			if (!ValidateDocument(doc, Resources.original))
				throw new XmlSchemaValidationException();

			XElement el = doc.Root;

			return el.Elements().Select(OriginalItem.Create).ToList();
		}

		public static IDictionary<string, OriginalItem> ReadOriginalFileAlias(string path)
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

		public static IEnumerable<TranslatedItem> ReadTranslateFile(string path)
		{
			XDocument doc = XDocument.Load(path);
			if (!ValidateDocument(doc, Resources.translate))
				throw new XmlSchemaValidationException();
			XElement el = doc.Root;

			return el.Elements().Select(TranslatedItem.Create).ToList();
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

		public static void SaveSplitted(IEnumerable<TranslatedItem> collection, string path)
		{
			XElement aliases = new XElement("Aliases");
			XElement originals = new XElement("Originals");
			XElement translates = new XElement("Translates");

			foreach (TranslatedItem item in collection)
			{
				aliases.Add(new XElement("Alias", new XAttribute("autoId", item.AutoId), item.Alias));
				originals.Add(new XElement("Original", new XAttribute("autoId", item.AutoId), item.Text));
				translates.Add(new XElement("Translate", new XAttribute("autoId", item.AutoId), item.Translate));
			}

			aliases.Save(path + "_aliases.xml");
			originals.Save(path + "_originals.xml");
			translates.Save(path + "_translates.xml");
		}
	}
}
