using BnsXmlEditor.Controls;
namespace BnsXmlEditor
{
	partial class MainForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TabPage searchTab;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.TabPage replaceTab;
			this.searchFieldGroup = new System.Windows.Forms.GroupBox();
			this.searchTranslateField = new System.Windows.Forms.RadioButton();
			this.searchOriginalField = new System.Windows.Forms.RadioButton();
			this.searchAliasField = new System.Windows.Forms.RadioButton();
			this.search = new System.Windows.Forms.Button();
			this.cancelSearch = new System.Windows.Forms.Button();
			this.searchIsRegex = new System.Windows.Forms.CheckBox();
			this.searchQuery = new BnsXmlEditor.Controls.HistoryComboBox();
			this.searchNotIgnoreCase = new System.Windows.Forms.CheckBox();
			this.replaceCancel = new System.Windows.Forms.Button();
			this.replace = new System.Windows.Forms.Button();
			this.replaceAll = new System.Windows.Forms.Button();
			this.replaceIsRegex = new System.Windows.Forms.CheckBox();
			this.replaceNotIgnoreCase = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.replaceString = new BnsXmlEditor.Controls.HistoryComboBox();
			this.replaceSearchQuery = new BnsXmlEditor.Controls.HistoryComboBox();
			this.textControlsContainer = new System.Windows.Forms.SplitContainer();
			this.elements = new System.Windows.Forms.ListView();
			this.autoIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.aliasColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.originalColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.translateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.elementsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.elementsContextMenuAliasCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.searchReplaceTabs = new System.Windows.Forms.TabControl();
			this.moveToIdPage = new System.Windows.Forms.TabPage();
			this.goToAutoId = new System.Windows.Forms.Button();
			this.autoIdValue = new BnsXmlEditor.Controls.HistoryComboBox();
			this.textGroup = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.originalText = new BnsXmlEditor.Controls.ExtendedRichTextBox();
			this.translatedText = new BnsXmlEditor.Controls.ExtendedTextBox();
			this.tagsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tagsContextMenuBr = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.mainMenuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.mainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.miRedo = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuView = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuElementsColumns = new System.Windows.Forms.ToolStripMenuItem();
			this.miAutoIdColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.miAliasColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.miOriginalColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.miTranslatedColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuViewHighlight = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuViewHighlightWords = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuLanguage = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuLanguageRussian = new System.Windows.Forms.ToolStripMenuItem();
			this.open = new System.Windows.Forms.OpenFileDialog();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.itemsCountHint = new System.Windows.Forms.ToolStripStatusLabel();
			this.itemsCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.save = new System.Windows.Forms.SaveFileDialog();
			searchTab = new System.Windows.Forms.TabPage();
			replaceTab = new System.Windows.Forms.TabPage();
			searchTab.SuspendLayout();
			this.searchFieldGroup.SuspendLayout();
			replaceTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textControlsContainer)).BeginInit();
			this.textControlsContainer.Panel1.SuspendLayout();
			this.textControlsContainer.Panel2.SuspendLayout();
			this.textControlsContainer.SuspendLayout();
			this.elementsContextMenu.SuspendLayout();
			this.searchReplaceTabs.SuspendLayout();
			this.moveToIdPage.SuspendLayout();
			this.textGroup.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tagsContextMenu.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// searchTab
			// 
			searchTab.Controls.Add(this.searchFieldGroup);
			searchTab.Controls.Add(this.search);
			searchTab.Controls.Add(this.cancelSearch);
			searchTab.Controls.Add(this.searchIsRegex);
			searchTab.Controls.Add(this.searchQuery);
			searchTab.Controls.Add(this.searchNotIgnoreCase);
			resources.ApplyResources(searchTab, "searchTab");
			searchTab.Name = "searchTab";
			searchTab.UseVisualStyleBackColor = true;
			// 
			// searchFieldGroup
			// 
			this.searchFieldGroup.Controls.Add(this.searchTranslateField);
			this.searchFieldGroup.Controls.Add(this.searchOriginalField);
			this.searchFieldGroup.Controls.Add(this.searchAliasField);
			resources.ApplyResources(this.searchFieldGroup, "searchFieldGroup");
			this.searchFieldGroup.Name = "searchFieldGroup";
			this.searchFieldGroup.TabStop = false;
			// 
			// searchTranslateField
			// 
			resources.ApplyResources(this.searchTranslateField, "searchTranslateField");
			this.searchTranslateField.Name = "searchTranslateField";
			this.searchTranslateField.TabStop = true;
			this.searchTranslateField.UseVisualStyleBackColor = true;
			this.searchTranslateField.Click += new System.EventHandler(this.searchField_Click);
			// 
			// searchOriginalField
			// 
			resources.ApplyResources(this.searchOriginalField, "searchOriginalField");
			this.searchOriginalField.Name = "searchOriginalField";
			this.searchOriginalField.TabStop = true;
			this.searchOriginalField.UseVisualStyleBackColor = true;
			this.searchOriginalField.Click += new System.EventHandler(this.searchField_Click);
			// 
			// searchAliasField
			// 
			resources.ApplyResources(this.searchAliasField, "searchAliasField");
			this.searchAliasField.Checked = true;
			this.searchAliasField.Name = "searchAliasField";
			this.searchAliasField.TabStop = true;
			this.searchAliasField.UseVisualStyleBackColor = true;
			this.searchAliasField.Click += new System.EventHandler(this.searchField_Click);
			// 
			// search
			// 
			resources.ApplyResources(this.search, "search");
			this.search.Name = "search";
			this.search.UseVisualStyleBackColor = true;
			this.search.Click += new System.EventHandler(this.search_Click);
			// 
			// cancelSearch
			// 
			resources.ApplyResources(this.cancelSearch, "cancelSearch");
			this.cancelSearch.Name = "cancelSearch";
			this.cancelSearch.UseVisualStyleBackColor = true;
			this.cancelSearch.Click += new System.EventHandler(this.cancelSearch_Click);
			// 
			// searchIsRegex
			// 
			resources.ApplyResources(this.searchIsRegex, "searchIsRegex");
			this.searchIsRegex.Name = "searchIsRegex";
			this.searchIsRegex.UseVisualStyleBackColor = true;
			// 
			// searchQuery
			// 
			resources.ApplyResources(this.searchQuery, "searchQuery");
			this.searchQuery.HistoryFile = "searchHistory.bin";
			this.searchQuery.HistoryMaxItems = 40;
			this.searchQuery.Name = "searchQuery";
			this.searchQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchQuery_KeyDown);
			// 
			// searchNotIgnoreCase
			// 
			resources.ApplyResources(this.searchNotIgnoreCase, "searchNotIgnoreCase");
			this.searchNotIgnoreCase.Name = "searchNotIgnoreCase";
			this.searchNotIgnoreCase.UseVisualStyleBackColor = true;
			// 
			// replaceTab
			// 
			replaceTab.Controls.Add(this.replaceCancel);
			replaceTab.Controls.Add(this.replace);
			replaceTab.Controls.Add(this.replaceAll);
			replaceTab.Controls.Add(this.replaceIsRegex);
			replaceTab.Controls.Add(this.replaceNotIgnoreCase);
			replaceTab.Controls.Add(this.label1);
			replaceTab.Controls.Add(this.replaceString);
			replaceTab.Controls.Add(this.replaceSearchQuery);
			resources.ApplyResources(replaceTab, "replaceTab");
			replaceTab.Name = "replaceTab";
			replaceTab.UseVisualStyleBackColor = true;
			// 
			// replaceCancel
			// 
			resources.ApplyResources(this.replaceCancel, "replaceCancel");
			this.replaceCancel.Name = "replaceCancel";
			this.replaceCancel.UseVisualStyleBackColor = true;
			this.replaceCancel.Click += new System.EventHandler(this.replaceCancel_Click);
			// 
			// replace
			// 
			resources.ApplyResources(this.replace, "replace");
			this.replace.Name = "replace";
			this.replace.UseVisualStyleBackColor = true;
			// 
			// replaceAll
			// 
			resources.ApplyResources(this.replaceAll, "replaceAll");
			this.replaceAll.Name = "replaceAll";
			this.replaceAll.UseVisualStyleBackColor = true;
			this.replaceAll.Click += new System.EventHandler(this.replaceAll_Click);
			// 
			// replaceIsRegex
			// 
			resources.ApplyResources(this.replaceIsRegex, "replaceIsRegex");
			this.replaceIsRegex.Name = "replaceIsRegex";
			this.replaceIsRegex.UseVisualStyleBackColor = true;
			// 
			// replaceNotIgnoreCase
			// 
			resources.ApplyResources(this.replaceNotIgnoreCase, "replaceNotIgnoreCase");
			this.replaceNotIgnoreCase.Name = "replaceNotIgnoreCase";
			this.replaceNotIgnoreCase.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// replaceString
			// 
			resources.ApplyResources(this.replaceString, "replaceString");
			this.replaceString.FormattingEnabled = true;
			this.replaceString.HistoryFile = "replaceHistory2.bin";
			this.replaceString.HistoryMaxItems = 40;
			this.replaceString.Name = "replaceString";
			// 
			// replaceSearchQuery
			// 
			resources.ApplyResources(this.replaceSearchQuery, "replaceSearchQuery");
			this.replaceSearchQuery.FormattingEnabled = true;
			this.replaceSearchQuery.HistoryFile = "replaceHistory1.bin";
			this.replaceSearchQuery.HistoryMaxItems = 40;
			this.replaceSearchQuery.Name = "replaceSearchQuery";
			// 
			// textControlsContainer
			// 
			resources.ApplyResources(this.textControlsContainer, "textControlsContainer");
			this.textControlsContainer.Name = "textControlsContainer";
			// 
			// textControlsContainer.Panel1
			// 
			this.textControlsContainer.Panel1.Controls.Add(this.elements);
			// 
			// textControlsContainer.Panel2
			// 
			this.textControlsContainer.Panel2.Controls.Add(this.searchReplaceTabs);
			this.textControlsContainer.Panel2.Controls.Add(this.textGroup);
			// 
			// elements
			// 
			this.elements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.autoIdColumn,
            this.aliasColumn,
            this.originalColumn,
            this.translateColumn});
			this.elements.ContextMenuStrip = this.elementsContextMenu;
			resources.ApplyResources(this.elements, "elements");
			this.elements.FullRowSelect = true;
			this.elements.GridLines = true;
			this.elements.HideSelection = false;
			this.elements.MultiSelect = false;
			this.elements.Name = "elements";
			this.elements.UseCompatibleStateImageBehavior = false;
			this.elements.View = System.Windows.Forms.View.Details;
			this.elements.VirtualMode = true;
			this.elements.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.elements_RetrieveVirtualItem);
			this.elements.SelectedIndexChanged += new System.EventHandler(this.elements_SelectedIndexChanged);
			// 
			// autoIdColumn
			// 
			resources.ApplyResources(this.autoIdColumn, "autoIdColumn");
			// 
			// aliasColumn
			// 
			resources.ApplyResources(this.aliasColumn, "aliasColumn");
			// 
			// originalColumn
			// 
			resources.ApplyResources(this.originalColumn, "originalColumn");
			// 
			// translateColumn
			// 
			resources.ApplyResources(this.translateColumn, "translateColumn");
			// 
			// elementsContextMenu
			// 
			this.elementsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elementsContextMenuAliasCopy});
			this.elementsContextMenu.Name = "elementsContextMenu";
			this.elementsContextMenu.ShowImageMargin = false;
			resources.ApplyResources(this.elementsContextMenu, "elementsContextMenu");
			// 
			// elementsContextMenuAliasCopy
			// 
			this.elementsContextMenuAliasCopy.Name = "elementsContextMenuAliasCopy";
			resources.ApplyResources(this.elementsContextMenuAliasCopy, "elementsContextMenuAliasCopy");
			this.elementsContextMenuAliasCopy.Click += new System.EventHandler(this.elementsContextMenuAliasCopy_Click);
			// 
			// searchReplaceTabs
			// 
			resources.ApplyResources(this.searchReplaceTabs, "searchReplaceTabs");
			this.searchReplaceTabs.Controls.Add(searchTab);
			this.searchReplaceTabs.Controls.Add(replaceTab);
			this.searchReplaceTabs.Controls.Add(this.moveToIdPage);
			this.searchReplaceTabs.Name = "searchReplaceTabs";
			this.searchReplaceTabs.SelectedIndex = 0;
			// 
			// moveToIdPage
			// 
			this.moveToIdPage.Controls.Add(this.goToAutoId);
			this.moveToIdPage.Controls.Add(this.autoIdValue);
			resources.ApplyResources(this.moveToIdPage, "moveToIdPage");
			this.moveToIdPage.Name = "moveToIdPage";
			this.moveToIdPage.UseVisualStyleBackColor = true;
			// 
			// goToAutoId
			// 
			resources.ApplyResources(this.goToAutoId, "goToAutoId");
			this.goToAutoId.Name = "goToAutoId";
			this.goToAutoId.UseVisualStyleBackColor = true;
			this.goToAutoId.Click += new System.EventHandler(this.goToAutoId_Click);
			// 
			// autoIdValue
			// 
			resources.ApplyResources(this.autoIdValue, "autoIdValue");
			this.autoIdValue.FormattingEnabled = true;
			this.autoIdValue.HistoryFile = "autoIdHistory.bin";
			this.autoIdValue.HistoryMaxItems = 40;
			this.autoIdValue.Name = "autoIdValue";
			this.autoIdValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.autoIdValue_KeyDown);
			// 
			// textGroup
			// 
			resources.ApplyResources(this.textGroup, "textGroup");
			this.textGroup.Controls.Add(this.tableLayoutPanel1);
			this.textGroup.Name = "textGroup";
			this.textGroup.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.originalText, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.translatedText, 0, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// originalText
			// 
			resources.ApplyResources(this.originalText, "originalText");
			this.originalText.Name = "originalText";
			this.originalText.ReadOnly = true;
			this.originalText.TextChanged += new System.EventHandler(this.originalText_TextChanged);
			// 
			// translatedText
			// 
			resources.ApplyResources(this.translatedText, "translatedText");
			this.translatedText.ContextMenuStrip = this.tagsContextMenu;
			this.translatedText.Name = "translatedText";
			this.translatedText.TextChanged += new System.EventHandler(this.translatedText_TextChanged);
			this.translatedText.Leave += new System.EventHandler(this.translatedText_Leave);
			// 
			// tagsContextMenu
			// 
			this.tagsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagsContextMenuBr});
			this.tagsContextMenu.Name = "tagsContextMenu";
			this.tagsContextMenu.ShowImageMargin = false;
			resources.ApplyResources(this.tagsContextMenu, "tagsContextMenu");
			// 
			// tagsContextMenuBr
			// 
			this.tagsContextMenuBr.Name = "tagsContextMenuBr";
			resources.ApplyResources(this.tagsContextMenuBr, "tagsContextMenuBr");
			this.tagsContextMenuBr.Click += new System.EventHandler(this.tagsContextMenuBr_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuFile,
            this.правкаToolStripMenuItem,
            this.mainMenuView,
            this.mainMenuLanguage});
			resources.ApplyResources(this.mainMenu, "mainMenu");
			this.mainMenu.Name = "mainMenu";
			// 
			// mainMenuFile
			// 
			this.mainMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuOpen,
            this.mainMenuSave,
            this.mainMenuSaveAs,
            this.mainMenuFileSeparator,
            this.mainMenuExit});
			this.mainMenuFile.Name = "mainMenuFile";
			resources.ApplyResources(this.mainMenuFile, "mainMenuFile");
			// 
			// mainMenuOpen
			// 
			this.mainMenuOpen.Name = "mainMenuOpen";
			resources.ApplyResources(this.mainMenuOpen, "mainMenuOpen");
			this.mainMenuOpen.Click += new System.EventHandler(this.mainMenuOpen_Click);
			// 
			// mainMenuSave
			// 
			this.mainMenuSave.Name = "mainMenuSave";
			resources.ApplyResources(this.mainMenuSave, "mainMenuSave");
			this.mainMenuSave.Click += new System.EventHandler(this.mainMenuSave_Click);
			// 
			// mainMenuSaveAs
			// 
			this.mainMenuSaveAs.Name = "mainMenuSaveAs";
			resources.ApplyResources(this.mainMenuSaveAs, "mainMenuSaveAs");
			this.mainMenuSaveAs.Click += new System.EventHandler(this.mainMenuSaveAs_Click);
			// 
			// mainMenuFileSeparator
			// 
			this.mainMenuFileSeparator.Name = "mainMenuFileSeparator";
			resources.ApplyResources(this.mainMenuFileSeparator, "mainMenuFileSeparator");
			// 
			// mainMenuExit
			// 
			this.mainMenuExit.Name = "mainMenuExit";
			resources.ApplyResources(this.mainMenuExit, "mainMenuExit");
			this.mainMenuExit.Click += new System.EventHandler(this.mainMenuExit_Click);
			// 
			// правкаToolStripMenuItem
			// 
			this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUndo,
            this.miRedo});
			this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
			resources.ApplyResources(this.правкаToolStripMenuItem, "правкаToolStripMenuItem");
			// 
			// miUndo
			// 
			resources.ApplyResources(this.miUndo, "miUndo");
			this.miUndo.Name = "miUndo";
			this.miUndo.Click += new System.EventHandler(this.miUndo_Click);
			// 
			// miRedo
			// 
			resources.ApplyResources(this.miRedo, "miRedo");
			this.miRedo.Name = "miRedo";
			this.miRedo.Click += new System.EventHandler(this.miRedo_Click);
			// 
			// mainMenuView
			// 
			this.mainMenuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuElementsColumns,
            this.mainMenuViewHighlight,
            this.mainMenuViewHighlightWords});
			this.mainMenuView.Name = "mainMenuView";
			resources.ApplyResources(this.mainMenuView, "mainMenuView");
			// 
			// mainMenuElementsColumns
			// 
			this.mainMenuElementsColumns.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAutoIdColumn,
            this.miAliasColumn,
            this.miOriginalColumn,
            this.miTranslatedColumn});
			this.mainMenuElementsColumns.Name = "mainMenuElementsColumns";
			resources.ApplyResources(this.mainMenuElementsColumns, "mainMenuElementsColumns");
			// 
			// miAutoIdColumn
			// 
			this.miAutoIdColumn.Checked = true;
			this.miAutoIdColumn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miAutoIdColumn.Name = "miAutoIdColumn";
			resources.ApplyResources(this.miAutoIdColumn, "miAutoIdColumn");
			// 
			// miAliasColumn
			// 
			this.miAliasColumn.Checked = true;
			this.miAliasColumn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miAliasColumn.Name = "miAliasColumn";
			resources.ApplyResources(this.miAliasColumn, "miAliasColumn");
			// 
			// miOriginalColumn
			// 
			this.miOriginalColumn.Checked = true;
			this.miOriginalColumn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miOriginalColumn.Name = "miOriginalColumn";
			resources.ApplyResources(this.miOriginalColumn, "miOriginalColumn");
			// 
			// miTranslatedColumn
			// 
			this.miTranslatedColumn.Checked = true;
			this.miTranslatedColumn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miTranslatedColumn.Name = "miTranslatedColumn";
			resources.ApplyResources(this.miTranslatedColumn, "miTranslatedColumn");
			// 
			// mainMenuViewHighlight
			// 
			this.mainMenuViewHighlight.Checked = true;
			this.mainMenuViewHighlight.CheckOnClick = true;
			this.mainMenuViewHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mainMenuViewHighlight.Name = "mainMenuViewHighlight";
			resources.ApplyResources(this.mainMenuViewHighlight, "mainMenuViewHighlight");
			this.mainMenuViewHighlight.CheckedChanged += new System.EventHandler(this.mainMenuViewHighlight_CheckedChanged);
			// 
			// mainMenuViewHighlightWords
			// 
			this.mainMenuViewHighlightWords.Checked = true;
			this.mainMenuViewHighlightWords.CheckOnClick = true;
			this.mainMenuViewHighlightWords.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mainMenuViewHighlightWords.Name = "mainMenuViewHighlightWords";
			resources.ApplyResources(this.mainMenuViewHighlightWords, "mainMenuViewHighlightWords");
			this.mainMenuViewHighlightWords.CheckedChanged += new System.EventHandler(this.mainMenuViewHighlightWords_CheckedChanged);
			// 
			// mainMenuLanguage
			// 
			this.mainMenuLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuLanguageEnglish,
            this.mainMenuLanguageRussian});
			this.mainMenuLanguage.Name = "mainMenuLanguage";
			resources.ApplyResources(this.mainMenuLanguage, "mainMenuLanguage");
			// 
			// mainMenuLanguageEnglish
			// 
			this.mainMenuLanguageEnglish.Name = "mainMenuLanguageEnglish";
			resources.ApplyResources(this.mainMenuLanguageEnglish, "mainMenuLanguageEnglish");
			this.mainMenuLanguageEnglish.Click += new System.EventHandler(this.mainMenuLanguageEnglish_Click);
			// 
			// mainMenuLanguageRussian
			// 
			this.mainMenuLanguageRussian.Name = "mainMenuLanguageRussian";
			resources.ApplyResources(this.mainMenuLanguageRussian, "mainMenuLanguageRussian");
			this.mainMenuLanguageRussian.Click += new System.EventHandler(this.mainMenuLanguageRussian_Click);
			// 
			// open
			// 
			resources.ApplyResources(this.open, "open");
			this.open.SupportMultiDottedExtensions = true;
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsCountHint,
            this.itemsCount});
			resources.ApplyResources(this.statusBar, "statusBar");
			this.statusBar.Name = "statusBar";
			this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			// 
			// itemsCountHint
			// 
			this.itemsCountHint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.itemsCountHint.Name = "itemsCountHint";
			resources.ApplyResources(this.itemsCountHint, "itemsCountHint");
			this.itemsCountHint.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			// 
			// itemsCount
			// 
			this.itemsCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.itemsCount.Name = "itemsCount";
			resources.ApplyResources(this.itemsCount, "itemsCount");
			// 
			// save
			// 
			this.save.DefaultExt = "xml";
			resources.ApplyResources(this.save, "save");
			this.save.SupportMultiDottedExtensions = true;
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.textControlsContainer);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.mainMenu);
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			searchTab.ResumeLayout(false);
			searchTab.PerformLayout();
			this.searchFieldGroup.ResumeLayout(false);
			this.searchFieldGroup.PerformLayout();
			replaceTab.ResumeLayout(false);
			replaceTab.PerformLayout();
			this.textControlsContainer.Panel1.ResumeLayout(false);
			this.textControlsContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textControlsContainer)).EndInit();
			this.textControlsContainer.ResumeLayout(false);
			this.elementsContextMenu.ResumeLayout(false);
			this.searchReplaceTabs.ResumeLayout(false);
			this.moveToIdPage.ResumeLayout(false);
			this.textGroup.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tagsContextMenu.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem mainMenuFile;
		private System.Windows.Forms.ToolStripMenuItem mainMenuOpen;
		private System.Windows.Forms.ToolStripMenuItem mainMenuSave;
		private System.Windows.Forms.ToolStripMenuItem mainMenuSaveAs;
		private System.Windows.Forms.ToolStripSeparator mainMenuFileSeparator;
		private System.Windows.Forms.ToolStripMenuItem mainMenuExit;
		private System.Windows.Forms.OpenFileDialog open;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripStatusLabel itemsCountHint;
		private System.Windows.Forms.ToolStripStatusLabel itemsCount;
		private System.Windows.Forms.GroupBox textGroup;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.CheckBox searchNotIgnoreCase;
		private System.Windows.Forms.Button cancelSearch;
		private System.Windows.Forms.SaveFileDialog save;
		private System.Windows.Forms.SplitContainer textControlsContainer;
		private System.Windows.Forms.ContextMenuStrip elementsContextMenu;
		private System.Windows.Forms.ToolStripMenuItem elementsContextMenuAliasCopy;
		private HistoryComboBox searchQuery;
		private System.Windows.Forms.ToolStripMenuItem mainMenuView;
		private System.Windows.Forms.ToolStripMenuItem mainMenuViewHighlight;
		private System.Windows.Forms.ContextMenuStrip tagsContextMenu;
		private System.Windows.Forms.ToolStripMenuItem tagsContextMenuBr;
		private System.Windows.Forms.CheckBox searchIsRegex;
		private System.Windows.Forms.ToolStripMenuItem mainMenuViewHighlightWords;
		private System.Windows.Forms.TabControl searchReplaceTabs;
		private System.Windows.Forms.Button replaceCancel;
		private System.Windows.Forms.Button replace;
		private System.Windows.Forms.Button replaceAll;
		private System.Windows.Forms.CheckBox replaceIsRegex;
		private System.Windows.Forms.CheckBox replaceNotIgnoreCase;
		private System.Windows.Forms.Label label1;
		private HistoryComboBox replaceString;
		private HistoryComboBox replaceSearchQuery;
		private System.Windows.Forms.Button search;
		private ExtendedRichTextBox originalText;
		private System.Windows.Forms.ListView elements;
		private System.Windows.Forms.ColumnHeader aliasColumn;
		private System.Windows.Forms.ColumnHeader originalColumn;
		private System.Windows.Forms.ColumnHeader translateColumn;
		private ExtendedTextBox translatedText;
		private System.Windows.Forms.RadioButton searchTranslateField;
		private System.Windows.Forms.RadioButton searchOriginalField;
		private System.Windows.Forms.RadioButton searchAliasField;
		private System.Windows.Forms.GroupBox searchFieldGroup;
		private System.Windows.Forms.TabPage moveToIdPage;
		private System.Windows.Forms.Button goToAutoId;
		private HistoryComboBox autoIdValue;
		private System.Windows.Forms.ColumnHeader autoIdColumn;
		private System.Windows.Forms.ToolStripMenuItem mainMenuElementsColumns;
		private System.Windows.Forms.ToolStripMenuItem miAutoIdColumn;
		private System.Windows.Forms.ToolStripMenuItem miAliasColumn;
		private System.Windows.Forms.ToolStripMenuItem miOriginalColumn;
		private System.Windows.Forms.ToolStripMenuItem miTranslatedColumn;
		private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miUndo;
		private System.Windows.Forms.ToolStripMenuItem miRedo;
		private System.Windows.Forms.ToolStripMenuItem mainMenuLanguage;
		private System.Windows.Forms.ToolStripMenuItem mainMenuLanguageEnglish;
		private System.Windows.Forms.ToolStripMenuItem mainMenuLanguageRussian;
	}
}

