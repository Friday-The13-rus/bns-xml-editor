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
			searchQuery.UpdateHistory();

			ClearSelectedItem();

			TranslatableItem.Fields field = GetSearchingField();
			try
			{
				List<TranslatableItem> finded = xmlFile.Find(searchQuery.Text, field, searchIsRegex.Checked, !searchNotIgnoreCase.Checked);
				UpdateItems(finded);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
			replaceSearchQuery.UpdateHistory();
			replaceString.UpdateHistory();

			ClearSelectedItem();

			string query = replaceSearchQuery.Text;
			string replaceQuery = replaceString.Text;
			try
			{
				List<TranslatableItem> result = xmlFile.Replace(query, replaceQuery, replaceIsRegex.Checked, !replaceNotIgnoreCase.Checked);

				string message = string.Format("Обработано {0} элементов.", result.Count);
				MessageBox.Show(message, "Операция завершена");
				UpdateItems(result);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void elements_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			TranslatableItem item = listViewItems[e.ItemIndex];
			ListViewItem lvi = new ListViewItem(item.AutoId.ToString());
			lvi.SubItems.Add(item.Alias);
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

		private void goToAutoId_Click(object sender, EventArgs e)
		{
			MoveToAutoId();
		}

		private void MoveToAutoId()
		{
			int autoId = int.Parse(autoIdValue.Text);
			int index = listViewItems.FindIndex(el => el.AutoId == autoId);
			if (index == -1)
			{
				string message = string.Format("Элемент с autoId {0} не найден.{1}Проверьте введенное значение или сбросьте фильтрацию.", autoIdValue.Text, Environment.NewLine);
				MessageBox.Show(message, "Элемент не найден", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			autoIdValue.UpdateHistory();

			elements.SelectedIndices.Clear();
			elements.SelectedIndices.Add(index);
			elements.EnsureVisible(index);
			elements.Select();
		}

		private void autoIdValue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
			{
				e.Handled = true;
			}
		}

		private void autoIdValue_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				MoveToAutoId();
		}
	}
}