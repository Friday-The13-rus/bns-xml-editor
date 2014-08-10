using System;
using System.Collections.Generic;
using System.Linq;
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

				UpdateItems(xmlFile.Elements);

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
			UpdateItems(xmlFile.Elements);
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

			TranslatableItem.Fields field = GetSearchingField();

			List<TranslatableItem> finded = xmlFile.Find(query, field, searchIsRegex.Checked, !searchNotIgnoreCase.Checked);
			UpdateItems(finded);
		}

		TranslatableItem.Fields GetSearchingField()
		{
			if (searchAliasField.Checked)
				return TranslatableItem.Fields.Alias;
			if (searchOriginalField.Checked)
				return TranslatableItem.Fields.Original;
			if (searchTranslateField.Checked)
				return TranslatableItem.Fields.Translate;

			throw new ApplicationException("Не выбрано ни одно значение радио кнопки для поиска");
		}

		private void UpdateItems(List<TranslatableItem> newElements)
		{
			elements.VirtualListSize = newElements.Count;
			itemsCount.Text = newElements.Count.ToString("N0");
			listViewItems = newElements;
			elements.Refresh();
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
						throw new ArgumentException("Поле не поддерживается.", field.ToString());
				}

				Clipboard.SetText(text, TextDataFormat.UnicodeText);
			}
		}

		private void translatedText_TextChanged(object sender, EventArgs e)
		{
			//if (mainMenuViewHighlightWords.Checked && searchQuery.Text != string.Empty &&
			//		(TranslatableItem.Fields)searchField.SelectedItem == TranslatableItem.Fields.Translate)
			//	translatedText.HighlightWord(searchQuery.Text, !searchNotIgnoreCase.Checked);
		}

		private void tagsContextMenuBr_Click(object sender, EventArgs e)
		{
			translatedText.PastTag("<br/>");
		}

		private void searchQuery_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				Find();
		}

		private void originalText_TextChanged(object sender, EventArgs e)
		{
			if (mainMenuViewHighlightWords.Checked && searchQuery.Text != string.Empty && searchOriginalField.Checked)
				originalText.HighlightWord(searchQuery.Text, !searchNotIgnoreCase.Checked);
		}

		private void replaceCancel_Click(object sender, EventArgs e)
		{
			ClearSelectedItem();
			UpdateItems(xmlFile.Elements);
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

			List<TranslatableItem> result = xmlFile.Replace(query, replaceQuery, replaceIsRegex.Checked, !replaceNotIgnoreCase.Checked);

			string message = string.Format("Обработано {0} элементов.", result.Count);
			MessageBox.Show(message, "Операция завершена");
			UpdateItems(result);
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
				translatedText.ClearUndoRedoList();

				originalText.Clear();
			}
		}

		private void searchField_Click(object sender, EventArgs e)
		{
			SelectSearchFieldControl(sender);
		}

		private void SelectSearchFieldControl(object selectedControl)
		{
			RadioButton currentButton = selectedControl as RadioButton;
			if (currentButton != null)
			{
				foreach (RadioButton contol in searchFieldGroup.Controls.OfType<RadioButton>())
				{
					if (contol.Name != currentButton.Name)
						contol.Checked = false;
				}
			}
		}

		private void mainMenuViewHighlight_CheckedChanged(object sender, EventArgs e)
		{
			originalText.HighlightXmlTags = mainMenuViewHighlight.Checked;
		}
	}
}