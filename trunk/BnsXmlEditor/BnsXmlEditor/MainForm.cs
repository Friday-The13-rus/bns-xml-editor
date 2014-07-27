using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BnsXmlEditor
{
	public partial class MainForm : Form
	{
		BnsTranslateFile xmlFile;

		BindingList<TranslatableItem> listViewItems = new BindingList<TranslatableItem>();

		public MainForm()
		{
			InitializeComponent();

			originalText.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
			translatedText.LanguageOption = RichTextBoxLanguageOptions.UIFonts;

			searchField.Items.Add(TranslatableItem.Fields.Alias);
			searchField.Items.Add(TranslatableItem.Fields.Original);
			searchField.Items.Add(TranslatableItem.Fields.Translate);
			searchField.SelectedIndex = 0;

			searchQuery.LoadHistory();
			replaceSearchQuery.LoadHistory();
			replaceString.LoadHistory();

			mainMenuSave.Enabled = false;
			mainMenuSaveAs.Enabled = false;
			textControlsContainer.Enabled = false;
		}

		private void mainMenuOpen_Click(object sender, EventArgs e)
		{
			if (open.ShowDialog() == DialogResult.OK)
			{
				ClearSelectedItem();
				searchQuery.Text = string.Empty;
				
				xmlFile = BnsTranslateFile.Load(open.FileName);
				listViewItems = new BindingList<TranslatableItem>(xmlFile.Elements);

				aliasColumn.AspectGetter = elem => ((TranslatableItem)elem).Alias;
				originalColumn.AspectGetter = elem => ((TranslatableItem)elem).Original;
				translateColumn.AspectGetter = elem => ((TranslatableItem)elem).Translate;

				//TextMatchFilter xmlTagsFilter = new TextMatchFilter(elements);
				//xmlTagsFilter.RegexOptions = System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.Singleline;
				//xmlTagsFilter.RegexStrings = new List<string>() { @"(</?[a-z]+)([^/>]+)?(/?>)" };

				//HighlightTextRenderer renderer = new HighlightTextRenderer();
				//renderer.

				//elements.DefaultRenderer = renderer;

				UpdateItems();

				mainMenuSave.Enabled = true;
				mainMenuSaveAs.Enabled = true;
				textControlsContainer.Enabled = true;
			}
		}

		private void mainMenuExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void cancelSearch_Click(object sender, EventArgs e)
		{
			ClearSelectedItem();
			searchQuery.Text = string.Empty;
			listViewItems = new BindingList<TranslatableItem>(xmlFile.Elements);
			UpdateItems();
		}

		private void search_Click(object sender, EventArgs e)
		{
			Find();
		}

		private void Find()
		{
			string query = searchQuery.Text;
			if (query == string.Empty)
				return;

			searchQuery.Add(query);

			if (searchQuery.Text == string.Empty)
				searchQuery.Text = query;

			ClearSelectedItem();

			listViewItems = new BindingList<TranslatableItem>(xmlFile.Find(query, (TranslatableItem.Fields)searchField.SelectedItem, searchIsRegex.Checked, !searchNotIgnoreCase.Checked));
			UpdateItems();
		}

		private void UpdateItems()
		{
			elements.SetObjects(listViewItems, true);
			itemsCount.Text = listViewItems.Count.ToString("N0");
		}

		private void SaveTranslate()
		{
			if (elements.SelectedIndex != -1)
			{
				listViewItems[elements.SelectedIndex].Translate = translatedText.Text;
			}
		}

		private void ClearSelectedItem()
		{
			elements.SelectedIndex = -1;
		}

		private void mainMenuSave_Click(object sender, EventArgs e)
		{
			SaveTranslate();
			xmlFile.Save();
		}

		private void mainMenuSaveAs_Click(object sender, EventArgs e)
		{
			if (save.ShowDialog() == DialogResult.OK)
			{
				SaveTranslate();
				xmlFile.Save(save.FileName);
			}
		}

		private void translatedText_Leave(object sender, EventArgs e)
		{
			SaveTranslate();
		}

		private void elementsContextMenuAliasCopy_Click(object sender, EventArgs e)
		{
			CopyToClipboard(TranslatableItem.Fields.Alias);
		}

		private void CopyToClipboard(TranslatableItem.Fields field)
		{
			string text;
			int index = elements.SelectedIndex;
			switch (field)
			{
				case TranslatableItem.Fields.Alias:
					text = listViewItems[index].Alias;
					break;

				case TranslatableItem.Fields.Original:
					text = listViewItems[index].Original;
					break;

				case TranslatableItem.Fields.Translate:
					text = listViewItems[index].Translate;
					break;

				default:
					throw new ArgumentException("Поле не поддерживается.", "field");
			}

			Clipboard.SetText(text, TextDataFormat.UnicodeText);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			searchQuery.SaveHistory();
			replaceSearchQuery.SaveHistory();
			replaceString.SaveHistory();
		}

		private void translatedText_TextChanged(object sender, EventArgs e)
		{
			if (translatedText.Text.IndexOf('\n') != -1)
				translatedText.Text = translatedText.Text.Replace('\n', '\0');
			
			if (mainMenuViewHighlight.Checked)
				translatedText.HighlightXmlTags();
			else
			{
				translatedText.SelectAll();
				translatedText.SelectionColor = translatedText.ForeColor;
			}

			if (mainMenuViewHighlightWords.Checked && searchQuery.Text != string.Empty &&
					(TranslatableItem.Fields)searchField.SelectedItem == TranslatableItem.Fields.Translate)
				translatedText.HighlightWord(searchQuery.Text, !searchNotIgnoreCase.Checked);
		}

		private void tagsContextMenuBr_Click(object sender, EventArgs e)
		{
			PastTag(translatedText, "<br/>");
		}

		private void PastTag(RichTextBox target, string tag)
		{
			int index = target.SelectionStart;
			string text = target.Text.Insert(index, tag);
			target.Text = text;
			target.SelectionStart = index + tag.Length;
		}

		private void searchQuery_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				Find();
		}

		private void translatedText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V && !Clipboard.ContainsText())
				e.Handled = true;
			else if (e.KeyCode == Keys.Enter)
				e.Handled = true;
		}

		private void originalText_TextChanged(object sender, EventArgs e)
		{
			if (mainMenuViewHighlight.Checked)
				originalText.HighlightXmlTags();
			else
			{
				originalText.SelectAll();
				originalText.SelectionColor = originalText.ForeColor;
			}

			if (mainMenuViewHighlightWords.Checked && searchQuery.Text != string.Empty &&
					(TranslatableItem.Fields)searchField.SelectedItem == TranslatableItem.Fields.Original)
				originalText.HighlightWord(searchQuery.Text, !searchNotIgnoreCase.Checked);
		}

		private void replaceCancel_Click(object sender, EventArgs e)
		{
			ClearSelectedItem();
			listViewItems = new BindingList<TranslatableItem>(xmlFile.Elements);
			UpdateItems();
		}

		private void replaceAll_Click(object sender, EventArgs e)
		{
			string query = replaceSearchQuery.Text;
			if (query == string.Empty)
				return;

			replaceSearchQuery.Add(query);

			if (replaceSearchQuery.Text == string.Empty)
				replaceSearchQuery.Text = query;

			string replaceQuery = replaceString.Text;

			replaceString.Add(replaceQuery);

			if (replaceString.Text == string.Empty)
				replaceString.Text = replaceQuery;

			ClearSelectedItem();

			listViewItems = new BindingList<TranslatableItem>(xmlFile.Replace(query, replaceQuery, replaceIsRegex.Checked, !replaceNotIgnoreCase.Checked));

			string message = string.Format("Обработано {0} элементов.", listViewItems.Count);
			MessageBox.Show(message, "Операция завершена");
			UpdateItems();
		}

		private void elements_SelectionChanged(object sender, EventArgs e)
		{
			int index = elements.SelectedIndex;
			if (index != -1)
			{
				originalText.Text = listViewItems[index].Original;
				translatedText.Text = listViewItems[index].Translate;
			}
			else
			{
				translatedText.Clear();
				originalText.Clear();
			}
		}
	}
}