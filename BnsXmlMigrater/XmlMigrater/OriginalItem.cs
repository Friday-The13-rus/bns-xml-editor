using System.Xml.Linq;

namespace XmlMigrater
{
	public class OriginalItem : IXLinqCompatible
	{
		public int AutoId { get; private set; }
		public string Alias { get; private set; }
		public string Text { get; private set; }

		public OriginalItem(int autoId, string alias, string replacement)
		{
			AutoId = autoId;
			Alias = alias;
			Text = replacement;
		}

		public static OriginalItem Create(XElement xElement)
		{
			return new OriginalItem(
				int.Parse(xElement.Element("autoId").Value), 
				xElement.Element("alias").Value,
				xElement.Element("text").Value
				);
		}

		public virtual XElement GetXElement()
		{
			return new XElement("TEXT",
				new XElement("autoId", AutoId),
				new XElement("alias", Alias),
				new XElement("text", Text)
				);
		}
	}
}