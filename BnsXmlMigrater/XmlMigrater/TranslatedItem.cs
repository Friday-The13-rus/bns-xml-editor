using System;
using System.Xml.Linq;

namespace XmlMigrater
{
	public class TranslatedItem : OriginalItem
	{
		public string Translate { get; set; }

		public TranslatedItem(int autoId, string alias, string original, string translate)
			: base(autoId, alias, original)
		{
			Translate = translate;
		}

		public TranslatedItem(OriginalItem originalItem)
			: this(originalItem.AutoId, originalItem.Alias, originalItem.Text, originalItem.Text)
		{
		}

		public new static TranslatedItem Create(XElement xElement)
		{
			return new TranslatedItem(
				int.Parse(xElement.Element("autoId").Value),
				xElement.Element("alias").Value,
				xElement.Element("original").Value,
				xElement.Element("replacement").Value
				);
		}

		public override XElement GetXElement()
		{
			return new XElement("TEXT",
				new XElement("autoId", AutoId),
				new XElement("alias", Alias),
				new XElement("original", Text),
				new XElement("replacement", Translate)
				);
		}
	}
}