using System.Collections.Generic;

namespace Core.UndoRedo
{
	internal class EditCommand
	{
		private readonly IEnumerable<EditableElement> _elements;

		public EditCommand(EditableElement element)
		{
			_elements = new List<EditableElement> { element };
		}

		public EditCommand(IEnumerable<EditableElement> elements)
		{
			_elements = new List<EditableElement>(elements);
		}

		public void Execute()
		{
			foreach (EditableElement element in _elements)
				element.Element.UpdateTranslate(element.NewTranslate);
		}

		public void UnExecute()
		{
			foreach (EditableElement element in _elements)
				element.Element.UpdateTranslate(element.OldTranslate);
		}
	}
}
