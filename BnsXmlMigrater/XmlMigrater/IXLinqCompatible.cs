using System.Xml.Linq;

namespace XmlMigrater
{
	public interface IXLinqCompatible
	{
		XElement GetXElement();
	}
}
