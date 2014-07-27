using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BnsXmlEditor
{
	public partial class MainForm : Form
	{
		BnsTranslateFile xmlFile;

		List<TranslatableItem> listViewItems = new List<TranslatableItem>();

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
				listViewItems = xmlFile.Elements;

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
			listViewItems = xmlFile.Elements;
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

			listViewItems = xmlFile.Find(query, (TranslatableItem.Fields)searchField.SelectedItem, searchIsRegex.Checked, !searchNotIgnoreCase.Checked);
			UpdateItems();
		}

		private void UpdateItems()
		{
			elements.VirtualListSize = listViewItems.Count;
			itemsCount.Text = listViewItems.Count.ToString("N0");
		}

		private void SaveTranslate()
		{
			if (elements.SelectedIndices.Count > 0)
			{
				listViewItems[elements.SelectedIndices[0]].Translate = translatedText.Text;
			}
		}

		private void ClearSelectedItem()
		{
			elements.SelectedIndices.Clear();
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
			if (elements.SelectedIndices.Count > 0)
			{
				string text;
				int index = elements.SelectedIndices[0];
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
			listViewItems = xmlFile.Elements;
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

			listViewItems = xmlFile.Replace(query, replaceQuery, replaceIsRegex.Checked, !replaceNotIgnoreCase.Checked);

			string message = string.Format("Обработано {0} элементов.", listViewItems.Count);
			MessageBox.Show(message, "Операция завершена");
			UpdateItems();
		}

		private void elements_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			TranslatableItem item = listViewItems[e.ItemIndex];
			ListViewItem lvi = new ListViewItem(item.Alias);
			lvi.SubItems.Add(item.Original);
			lvi.SubItems.Add(item.Translate);
			e.Item = lvi;
		}

		private void elements_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (elements.SelectedIndices.Count > 0)
			{
				int index = elements.SelectedIndices[0];
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