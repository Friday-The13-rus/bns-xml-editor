using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BnsXmlEditor.Controls
{
	class ExtendedTextBox : TextBox
	{
		Stack<string> undoList = new Stack<string>();

		protected override void OnKeyDown(KeyEventArgs e)
		{			
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.A:
						SelectAll();
						e.SuppressKeyPress = true;
						e.Handled = true;
						break;
					case Keys.Z:
						if (undoList.Count > 0)
						{
							int index = SelectionStart;
							Text = undoList.Pop();
							SelectionStart = index;
						}
						e.Handled = true;
						break;
				}
			}
			
			base.OnKeyDown(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				e.Handled = true;

			const char CtrlZ = '\u001A';
			const char CtrlA = '\u0001';
			const char CtrlC = '\u0003';
			const char CtrlX = '\u0018';

			if (e.KeyChar != CtrlZ && e.KeyChar != CtrlA && e.KeyChar != CtrlC && e.KeyChar != CtrlX)
			{
				int index = SelectionStart;
				undoList.Push(Text);
				SelectionStart = index;
			}
			
			base.OnKeyPress(e);
		}

		public void ClearUndoRedoList()
		{
			undoList.Clear();
		}

		public void PastTag(string tag)
		{
			int index = SelectionStart;
			string text = Text.Insert(index, tag);
			Text = text;
			SelectionStart = index + tag.Length;
		}
	}
}
