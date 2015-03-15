using System;
using System.Xml.Linq;

namespace XmlMigrater
{
	public class TranslatedItem : OriginalItem
	{
		public string Translate { get; set; }

		public TranslatedItem(string autoId, string alias, string original, string translate)
			: base(autoId, alias, original)
		{
			Translate = translate;
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