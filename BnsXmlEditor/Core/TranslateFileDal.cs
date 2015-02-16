using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Core.Properties;

namespace Core
{
	static class TranslateFileDal
	{
		private static class NodeNames
		{
			public const string Root = "TEXT";
			public const string AutoId = "autoId";
			public const string Alias = "alias";
			public const string Original = "original";
			public const string Replacement = "replacement";
		}

		private static readonly XmlSchemaSet schemaSet;

		static TranslateFileDal()
		{
			schemaSet = new XmlSchemaSet();
			schemaSet.Add("", new XmlTextReader(new StringReader(Resources.translate)));
			schemaSet.Compile();
		}

		public static IEnumerable<TranslatableItem> Open(string path)
		{
			XmlReaderSettings settings = new XmlReaderSettings 
			{
				CloseInput = true,
				Schemas = schemaSet, 
				ValidationType = ValidationType.Schema 
			};

			XDocument doc;

			using (XmlReader reader = XmlReader.Create(path, settings))
			{
				doc = XDocument.Load(reader);
			}

			XElement el = doc.Root;

			List<TranslatableItem> elements = new List<TranslatableItem>();

			foreach (XElement elem in el.Elements(NodeNames.Root))
			{
				int autoId = int.Parse(elem.Element(NodeNames.AutoId).Value);
				string alias = elem.Element(NodeNames.Alias).Value;
				string original = elem.Element(NodeNames.Original).Value;
				string translate = elem.Element(NodeNames.Replacement).Value;

				elements.Add(new TranslatableItem(autoId, alias, original, translate));
			}

			return elements;
		}

		public static void Save(string path, IEnumerable<TranslatableItem> elements)
		{
			XElement texts = new XElement("text");

			foreach (TranslatableItem line in elements)
			{
				texts.Add(new XElement(NodeNames.Root,
					new XElement(NodeNames.AutoId, line.AutoId),
					new XElement(NodeNames.Alias, line.Alias),
					new XElement(NodeNames.Original, line.Original),
					new XElement(NodeNames.Replacement, line.Translate)
				));
			}

			XmlWriterSettings settings = new XmlWriterSettings
			{
				OmitXmlDeclaration = true,
				Encoding = Encoding.UTF8,
				Indent = true
			};

			using (XmlWriter xw = XmlWriter.Create(path, settings))
			{
				texts.Save(xw);
			}
		}

	}
}
