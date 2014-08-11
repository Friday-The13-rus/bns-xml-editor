using System.Linq;

namespace BnsXmlEditorWpf
{
	class TranslatableItem
	{
		public enum Fields { AutoId, Alias, Original, Translate }

		public enum TranslateState { Translated, PartiallyTranslated, NotTranslated }

		public int AutoId { get; private set; }

		public string Alias { get; set; }

		public string Original { get; set; }

		public string Translate { get; set; }

		public TranslateState State { get; private set; }

		public TranslatableItem(int autoId, string alias, string original, string translate)
		{
			AutoId = autoId;
			Alias = alias;
			Original = original;
			Translate = translate;

			UpdateTranslateState();
		}

		public void UpdateTranslateState()
		{
			if (string.Equals(Original, Translate, System.StringComparison.CurrentCulture))
				State = TranslateState.NotTranslated;
			else if (Translate.Any(elem => elem >= '\u4E00' && elem <= '\u9FFF') ||   // хотябы один китайский
					!Translate.Any(elem => elem >= '\u0401' && elem <= '\u0451'))     // ни одного русского
				State = TranslateState.PartiallyTranslated;
			else
				State = TranslateState.Translated;
		}
	}
}