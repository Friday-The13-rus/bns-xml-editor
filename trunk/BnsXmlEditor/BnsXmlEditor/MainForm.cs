using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Schema;
using BnsXmlEditor.Properties;
using Core;

namespace BnsXmlEditor
{
	public partial class MainForm : Form
	{
		private readonly TranslateFileBl _xmlFile = new TranslateFileBl();

		List<TranslatableItem> _listViewItems = new List<TranslatableItem>();

		public MainForm()
		{
			SetLanguage();

			InitializeComponent();

			mainMenuSave.Enabled = false;
			mainMenuSaveAs.Enabled = false;
			textControlsContainer.Enabled = false;

			mainMenuViewHighlight.Checked = Settings.Default.HighlightXmlTags;
			mainMenuViewHighlightWords.Checked = Settings.Default.HighlightSearchResults;
		}

		private static void SetLanguage()
		{
			Thread.CurrentThread.CurrentUICulture = 
				new CultureInfo(Settings.Default.Language == "ru-RU" ? Settings.Default.Language : "en-US");
		}

		private void mainMenuOpen_Click(object sender, EventArgs e)
		{
			if (open.ShowDialog() == DialogResult.OK)
			{
				ClearSelectedItem();
				searchQuery.Text = string.Empty;

				try
				{
					_xmlFile.Load(open.FileName);
				}
				catch (XmlSchemaValidationException)
				{
					MessageBox.Show(Resources.InvalidFileFormat);
					return;
				}

				UpdateItems(_xmlFile.GetElements().ToList());

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
			UpdateItems(_xmlFile.GetElements().ToList());
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
				FilterCriteria criteria = new FilterCriteria(searchQuery.Text, field, searchIsRegex.Checked, !searchNotIgnoreCase.Checked);
				List<TranslatableItem> finded = _xmlFile.GetElements(criteria).ToList();
				UpdateItems(finded);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

			throw new ApplicationException(Resources.SearchFieldNotSelected);
		}

		private void UpdateItems(List<TranslatableItem> newElements)
		{
			elements.VirtualListSize = newElements.Count;
			itemsCount.Text = newElements.Count.ToString("N0");
			_listViewItems = newElements;
			elements.Refresh();
		}

		private void SaveTranslate()
		{
			if (elements.SelectedIndices.Count > 0)
			{
				_xmlFile.ElementUpdated(_listViewItems[elements.SelectedIndices[0]], translatedText.Text);
				UpdateUndoRedoButtonsStatus();
			}
		}

		private void ClearSelectedItem()
		{
			elements.SelectedIndices.Clear();
		}

		private void mainMenuSave_Click(object sender, EventArgs e)
		{
			if (translatedText.Focused)
				SaveTranslate();

			_xmlFile.Save();
		}

		private void mainMenuSaveAs_Click(object sender, EventArgs e)
		{
			if (save.ShowDialog() == DialogResult.OK)
			{
				if (translatedText.Focused)
					SaveTranslate();

				_xmlFile.Save(save.FileName);
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
						text = _listViewItems[index].Alias;
						break;

					case TranslatableItem.Fields.Original:
						text = _listViewItems[index].Original;
						break;

					case TranslatableItem.Fields.Translate:
						text = _listViewItems[index].Translate;
						break;

					default:
						throw new ArgumentException(Resources.CopingFieldNotSupported, field.ToString());
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
			UpdateItems(_xmlFile.GetElements().ToList());
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
				ReplaceCriteria criteria = new ReplaceCriteria(query, replaceQuery, replaceIsRegex.Checked, !replaceNotIgnoreCase.Checked);
				List<TranslatableItem> result = _xmlFile.ReplaceTranslate(criteria).ToList();

				string message = string.Format(Resources.ReplaceSuccessMessage, result.Count);
				MessageBox.Show(message, Resources.SuccessCaption);

				UpdateUndoRedoButtonsStatus();
				UpdateItems(result);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void elements_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			TranslatableItem item = _listViewItems[e.ItemIndex];
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

				originalText.Text = _listViewItems[index].Original;
				translatedText.Text = _listViewItems[index].Translate;
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
				foreach (RadioButton control in searchFieldGroup.Controls.OfType<RadioButton>())
				{
					if (control.Name != currentButton.Name)
						control.Checked = false;
				}
			}
		}

		private void mainMenuViewHighlight_CheckedChanged(object sender, EventArgs e)
		{
			originalText.HighlightXmlTags = mainMenuViewHighlight.Checked;

			Settings.Default.HighlightXmlTags = mainMenuViewHighlight.Checked;
			Settings.Default.Save();
		}

		private void goToAutoId_Click(object sender, EventArgs e)
		{
			MoveToAutoId();
		}

		private void MoveToAutoId()
		{
			if (!autoIdValue.Text.All(char.IsDigit))
			{
				MessageBox.Show(Resources.AutoIdContainsOnlyNumbersMessage, Resources.ErrorCaption, MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			int autoId = int.Parse(autoIdValue.Text);
			int index = _listViewItems.FindIndex(el => el.AutoId == autoId);
			if (index == -1)
			{
				string message = string.Format(Resources.ElementNotFoundedMessage, autoIdValue.Text, Environment.NewLine);
				MessageBox.Show(message, Resources.ElementNotFoundedCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			autoIdValue.UpdateHistory();

			elements.SelectedIndices.Clear();
			elements.SelectedIndices.Add(index);
			elements.EnsureVisible(index);
			elements.Select();
		}

		private void autoIdValue_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				MoveToAutoId();
		}

		private void miUndo_Click(object sender, EventArgs e)
		{
			if (_xmlFile.UndoRedoManager.Undo())
			{
				elements.Refresh();
				int index = elements.SelectedIndices[0];
				translatedText.Text = _listViewItems[index].Translate;

				UpdateUndoRedoButtonsStatus();
			}
		}

		private void miRedo_Click(object sender, EventArgs e)
		{
			if (_xmlFile.UndoRedoManager.Redo())
			{
				elements.Refresh();
				int index = elements.SelectedIndices[0];
				translatedText.Text = _listViewItems[index].Translate;

				UpdateUndoRedoButtonsStatus();
			}

		}

		private void UpdateUndoRedoButtonsStatus()
		{
			miUndo.Enabled = !_xmlFile.UndoRedoManager.UndoListIsEmpty;
			miRedo.Enabled = !_xmlFile.UndoRedoManager.RedoListIsEmpty;
		}

		private void mainMenuViewHighlightWords_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.HighlightSearchResults = mainMenuViewHighlightWords.Checked;
			Settings.Default.Save();
		}

		private void mainMenuLanguageEnglish_Click(object sender, EventArgs e)
		{
			ChangeLanguageTo("en-US");
		}

		private static void ChangeLanguageTo(string languageCode)
		{
			Settings.Default.Language = languageCode;
			Settings.Default.Save();

			MessageBox.Show(Resources.LanguageChangedMessage, Resources.SuccessCaption, MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void mainMenuLanguageRussian_Click(object sender, EventArgs e)
		{
			ChangeLanguageTo("ru-RU");
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (translatedText.Focused)
				SaveTranslate();

			if (e.CloseReason != CloseReason.UserClosing || !_xmlFile.HasChanges)
				return;

			DialogResult result = MessageBox.Show(Resources.SaveChangesQuestionMessage, Resources.QuestionCaption, MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Information);
			switch (result)
			{
				case DialogResult.Yes:
					_xmlFile.Save();
					break;
				case DialogResult.Cancel:
					e.Cancel = true;
					break;
			}
		}
	}
}