using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BnsXmlEditor
{
	class ExtendedRichTextBox : RichTextBox
	{
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (!base.AutoWordSelection)
			{
				base.AutoWordSelection = true;
				base.AutoWordSelection = false;
			}
		}

		public void HighlightWord(string word, bool ignoreCase)
		{
			SuspendLayout();

			int selectedIndex = SelectionStart;

			SelectAll();
			SelectionBackColor = BackColor;

			RegexOptions options = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;

			MatchCollection resultsWords = Regex.Matches(Text, word, options);
			foreach (Match findedWord in resultsWords)
			{
				Select(findedWord.Index, findedWord.Length);
				SelectionBackColor = Color.Yellow;
			}

			Select(selectedIndex, 0);
			//SelectionBackColor = BackColor;

			ResumeLayout();
		}

		public void HighlightXmlTags()
		{
			SuspendLayout();

			int selectedIndex = SelectionStart;

			SelectAll();
			SelectionColor = ForeColor;

			MatchCollection resultsTags = Regex.Matches(Text, @"(</?[a-z]+)([^/>]+)?(/?>)");
			foreach (Match tag in resultsTags)
			{
				MatchCollection resultsAtribures = Regex.Matches(tag.Groups[2].Value, "\\s?([a-z]+)=(\"[^\"]+\")");
				foreach (Match attribute in resultsAtribures)
				{
					Colorize(attribute.Groups[1], tag.Groups[2].Index, Color.Red);
					Colorize(attribute.Groups[2], tag.Groups[2].Index, Color.DarkViolet);
				}
				Colorize(tag.Groups[1], 0, Color.Blue);
				Colorize(tag.Groups[3], 0, Color.Blue);
			}

			Select(selectedIndex, 0);
			SelectionColor = ForeColor;

			ResumeLayout();
		}

		private void Colorize(Group group, int offset, Color color)
		{
			Select(group.Index + offset, group.Length);
			SelectionColor = color;
		}
	}
}