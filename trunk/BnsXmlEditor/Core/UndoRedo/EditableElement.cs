namespace Core.UndoRedo
{
	public class EditableElement
	{
		public TranslatableItem Element { get; private set; }

		public string OldTranslate { get; private set; }

		public string NewTranslate { get; private set; }

		public EditableElement(TranslatableItem element, string newTranslate)
		{
			Element = element;
			OldTranslate = element.Translate;
			NewTranslate = newTranslate;
		}
	}
}
