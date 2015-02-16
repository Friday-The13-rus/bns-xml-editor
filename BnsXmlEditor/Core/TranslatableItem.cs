using System;
using System.Linq;

namespace Core
{
	public class TranslatableItem
	{
		public enum Fields { AutoId, Alias, Original, Translate }

		public enum TranslateState { Translated, PartiallyTranslated, NotTranslated }

		public int AutoId { get; private set; }

		public string Alias { get; private set; }

		public string Original { get; private set; }

		public string Translate { get; private set; }

		public TranslateState State { get; private set; }

		public TranslatableItem(int autoId, string alias, string original, string translate)
		{
			AutoId = autoId;
			Alias = alias;
			Original = original;
			Translate = translate;

			//UpdateTranslateState();
		}

		public void UpdateTranslateState()
		{
			if (string.Equals(Original, Translate, StringComparison.CurrentCulture))
				State = TranslateState.NotTranslated;
			else if (Translate.Any(CharExtension.IsChineseChar) ||   // хотябы один китайский
					!Translate.Any(CharExtension.IsRussianChar))     // ни одного русского
				State = TranslateState.PartiallyTranslated;
			else
				State = TranslateState.Translated;
		}

		internal void UpdateTranslate(string newValue)
		{
			Translate = newValue;
		}
	}
}