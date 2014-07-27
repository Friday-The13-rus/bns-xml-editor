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
			System.Windows.Forms.TabPage replaceTab;
			this.search = new System.Windows.Forms.Button();
			this.cancelSearch = new System.Windows.Forms.Button();
			this.searchIsRegex = new System.Windows.Forms.CheckBox();
			this.searchFieldHint = new System.Windows.Forms.Label();
			this.searchQuery = new BnsXmlEditor.HistoryComboBox();
			this.searchField = new System.Windows.Forms.ComboBox();
			this.searchNotIgnoreCase = new System.Windows.Forms.CheckBox();
			this.replaceCancel = new System.Windows.Forms.Button();
			this.replace = new System.Windows.Forms.Button();
			this.replaceAll = new System.Windows.Forms.Button();
			this.replaceIsRegex = new System.Windows.Forms.CheckBox();
			this.replaceNotIgnoreCase = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.replaceString = new BnsXmlEditor.HistoryComboBox();
			this.replaceSearchQuery = new BnsXmlEditor.HistoryComboBox();
			this.elementsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.elementsContextMenuAliasCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.tagsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tagsContextMenuBr = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.mainMenuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.mainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuView = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuViewHighlight = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuViewHighlightWords = new System.Windows.Forms.ToolStripMenuItem();
			this.open = new System.Windows.Forms.OpenFileDialog();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.itemsCountHint = new System.Windows.Forms.ToolStripStatusLabel();
			this.itemsCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.save = new System.Windows.Forms.SaveFileDialog();
			this.textControlsContainer = new System.Windows.Forms.SplitContainer();
			this.elements = new BrightIdeasSoftware.FastObjectListView();
			this.aliasColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.originalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.translateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.searchReplaceTabs = new System.Windows.Forms.TabControl();
			this.textGroup = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.translatedText = new BnsXmlEditor.ExtendedRichTextBox();
			this.originalText = new BnsXmlEditor.ExtendedRichTextBox();
			searchTab = new System.Windows.Forms.TabPage();
			replaceTab = new System.Windows.Forms.TabPage();
			searchTab.SuspendLayout();
			replaceTab.SuspendLayout();
			this.elementsContextMenu.SuspendLayout();
			this.tagsContextMenu.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.statusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textControlsContainer)).BeginInit();
			this.textControlsContainer.Panel1.SuspendLayout();
			this.textControlsContainer.Panel2.SuspendLayout();
			this.textControlsContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.elements)).BeginInit();
			this.searchReplaceTabs.SuspendLayout();
			this.textGroup.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// searchTab
			// 
			searchTab.Controls.Add(this.search);
			searchTab.Controls.Add(this.cancelSearch);
			searchTab.Controls.Add(this.searchIsRegex);
			searchTab.Controls.Add(this.searchFieldHint);
			searchTab.Controls.Add(this.searchQuery);
			searchTab.Controls.Add(this.searchField);
			searchTab.Controls.Add(this.searchNotIgnoreCase);
			searchTab.Location = new System.Drawing.Point(4, 22);
			searchTab.Name = "searchTab";
			searchTab.Padding = new System.Windows.Forms.Padding(3);
			searchTab.Size = new System.Drawing.Size(427, 114);
			searchTab.TabIndex = 0;
			searchTab.Text = "Поиск";
			searchTab.UseVisualStyleBackColor = true;
			// 
			// search
			// 
			this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.search.Location = new System.Drawing.Point(265, 85);
			this.search.Name = "search";
			this.search.Size = new System.Drawing.Size(75, 23);
			this.search.TabIndex = 12;
			this.search.Text = "Найти";
			this.search.UseVisualStyleBackColor = true;
			this.search.Click += new System.EventHandler(this.search_Click);
			// 
			// cancelSearch
			// 
			this.cancelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelSearch.Location = new System.Drawing.Point(346, 85);
			this.cancelSearch.Name = "cancelSearch";
			this.cancelSearch.Size = new System.Drawing.Size(75, 23);
			this.cancelSearch.TabIndex = 4;
			this.cancelSearch.Text = "Сброс";
			this.cancelSearch.UseVisualStyleBackColor = true;
			this.cancelSearch.Click += new System.EventHandler(this.cancelSearch_Click);
			// 
			// searchIsRegex
			// 
			this.searchIsRegex.AutoSize = true;
			this.searchIsRegex.Location = new System.Drawing.Point(135, 33);
			this.searchIsRegex.Name = "searchIsRegex";
			this.searchIsRegex.Size = new System.Drawing.Size(146, 17);
			this.searchIsRegex.TabIndex = 11;
			this.searchIsRegex.Text = "Регулярное выражение";
			this.searchIsRegex.UseVisualStyleBackColor = true;
			// 
			// searchFieldHint
			// 
			this.searchFieldHint.Location = new System.Drawing.Point(6, 53);
			this.searchFieldHint.Name = "searchFieldHint";
			this.searchFieldHint.Size = new System.Drawing.Size(97, 23);
			this.searchFieldHint.TabIndex = 9;
			this.searchFieldHint.Text = "Поле для поиска";
			this.searchFieldHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// searchQuery
			// 
			this.searchQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchQuery.HistoryFile = "searchHistory.bin";
			this.searchQuery.HistoryMaxItems = 20;
			this.searchQuery.ImeMode = System.Windows.Forms.ImeMode.On;
			this.searchQuery.Location = new System.Drawing.Point(6, 6);
			this.searchQuery.Name = "searchQuery";
			this.searchQuery.Size = new System.Drawing.Size(415, 21);
			this.searchQuery.TabIndex = 10;
			this.searchQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchQuery_KeyDown);
			// 
			// searchField
			// 
			this.searchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.searchField.Location = new System.Drawing.Point(109, 55);
			this.searchField.Name = "searchField";
			this.searchField.Size = new System.Drawing.Size(121, 21);
			this.searchField.TabIndex = 2;
			// 
			// searchNotIgnoreCase
			// 
			this.searchNotIgnoreCase.AutoSize = true;
			this.searchNotIgnoreCase.Location = new System.Drawing.Point(9, 33);
			this.searchNotIgnoreCase.Name = "searchNotIgnoreCase";
			this.searchNotIgnoreCase.Size = new System.Drawing.Size(120, 17);
			this.searchNotIgnoreCase.TabIndex = 1;
			this.searchNotIgnoreCase.Text = "С учетом регистра";
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
			replaceTab.Location = new System.Drawing.Point(4, 22);
			replaceTab.Name = "replaceTab";
			replaceTab.Padding = new System.Windows.Forms.Padding(3);
			replaceTab.Size = new System.Drawing.Size(427, 114);
			replaceTab.TabIndex = 1;
			replaceTab.Text = "Замена";
			replaceTab.UseVisualStyleBackColor = true;
			// 
			// replaceCancel
			// 
			this.replaceCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.replaceCancel.Location = new System.Drawing.Point(346, 85);
			this.replaceCancel.Name = "replaceCancel";
			this.replaceCancel.Size = new System.Drawing.Size(75, 23);
			this.replaceCancel.TabIndex = 16;
			this.replaceCancel.Text = "Сброс";
			this.replaceCancel.UseVisualStyleBackColor = true;
			this.replaceCancel.Click += new System.EventHandler(this.replaceCancel_Click);
			// 
			// replace
			// 
			this.replace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.replace.Location = new System.Drawing.Point(170, 85);
			this.replace.Name = "replace";
			this.replace.Size = new System.Drawing.Size(75, 23);
			this.replace.TabIndex = 15;
			this.replace.Text = "Заменить";
			this.replace.UseVisualStyleBackColor = true;
			this.replace.Visible = false;
			// 
			// replaceAll
			// 
			this.replaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.replaceAll.Location = new System.Drawing.Point(251, 85);
			this.replaceAll.Name = "replaceAll";
			this.replaceAll.Size = new System.Drawing.Size(88, 23);
			this.replaceAll.TabIndex = 14;
			this.replaceAll.Text = "Заменить все";
			this.replaceAll.UseVisualStyleBackColor = true;
			this.replaceAll.Click += new System.EventHandler(this.replaceAll_Click);
			// 
			// replaceIsRegex
			// 
			this.replaceIsRegex.AutoSize = true;
			this.replaceIsRegex.Location = new System.Drawing.Point(136, 61);
			this.replaceIsRegex.Name = "replaceIsRegex";
			this.replaceIsRegex.Size = new System.Drawing.Size(146, 17);
			this.replaceIsRegex.TabIndex = 13;
			this.replaceIsRegex.Text = "Регулярное выражение";
			this.replaceIsRegex.UseVisualStyleBackColor = true;
			// 
			// replaceNotIgnoreCase
			// 
			this.replaceNotIgnoreCase.AutoSize = true;
			this.replaceNotIgnoreCase.Location = new System.Drawing.Point(10, 61);
			this.replaceNotIgnoreCase.Name = "replaceNotIgnoreCase";
			this.replaceNotIgnoreCase.Size = new System.Drawing.Size(120, 17);
			this.replaceNotIgnoreCase.TabIndex = 12;
			this.replaceNotIgnoreCase.Text = "С учетом регистра";
			this.replaceNotIgnoreCase.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 21);
			this.label1.TabIndex = 2;
			this.label1.Text = "Заменить на:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// replaceString
			// 
			this.replaceString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.replaceString.FormattingEnabled = true;
			this.replaceString.HistoryFile = "replaceHistory2.bin";
			this.replaceString.HistoryMaxItems = 20;
			this.replaceString.Location = new System.Drawing.Point(89, 34);
			this.replaceString.Name = "replaceString";
			this.replaceString.Size = new System.Drawing.Size(332, 21);
			this.replaceString.TabIndex = 1;
			// 
			// replaceSearchQuery
			// 
			this.replaceSearchQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.replaceSearchQuery.FormattingEnabled = true;
			this.replaceSearchQuery.HistoryFile = "replaceHistory1.bin";
			this.replaceSearchQuery.HistoryMaxItems = 20;
			this.replaceSearchQuery.Location = new System.Drawing.Point(6, 6);
			this.replaceSearchQuery.Name = "replaceSearchQuery";
			this.replaceSearchQuery.Size = new System.Drawing.Size(415, 21);
			this.replaceSearchQuery.TabIndex = 0;
			// 
			// elementsContextMenu
			// 
			this.elementsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elementsContextMenuAliasCopy});
			this.elementsContextMenu.Name = "elementsContextMenu";
			this.elementsContextMenu.ShowImageMargin = false;
			this.elementsContextMenu.Size = new System.Drawing.Size(143, 26);
			// 
			// elementsContextMenuAliasCopy
			// 
			this.elementsContextMenuAliasCopy.Name = "elementsContextMenuAliasCopy";
			this.elementsContextMenuAliasCopy.Size = new System.Drawing.Size(142, 22);
			this.elementsContextMenuAliasCopy.Text = "Копировать Alias";
			this.elementsContextMenuAliasCopy.Click += new System.EventHandler(this.elementsContextMenuAliasCopy_Click);
			// 
			// tagsContextMenu
			// 
			this.tagsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagsContextMenuBr});
			this.tagsContextMenu.Name = "tagsContextMenu";
			this.tagsContextMenu.ShowImageMargin = false;
			this.tagsContextMenu.Size = new System.Drawing.Size(123, 26);
			// 
			// tagsContextMenuBr
			// 
			this.tagsContextMenuBr.Name = "tagsContextMenuBr";
			this.tagsContextMenuBr.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.tagsContextMenuBr.Size = new System.Drawing.Size(122, 22);
			this.tagsContextMenuBr.Text = "<br/>";
			this.tagsContextMenuBr.Click += new System.EventHandler(this.tagsContextMenuBr_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuFile,
            this.mainMenuView});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(803, 24);
			this.mainMenu.TabIndex = 0;
			this.mainMenu.Text = "Главное меню";
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
			this.mainMenuFile.Size = new System.Drawing.Size(48, 20);
			this.mainMenuFile.Text = "Файл";
			// 
			// mainMenuOpen
			// 
			this.mainMenuOpen.Name = "mainMenuOpen";
			this.mainMenuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mainMenuOpen.Size = new System.Drawing.Size(216, 22);
			this.mainMenuOpen.Text = "Открыть";
			this.mainMenuOpen.Click += new System.EventHandler(this.mainMenuOpen_Click);
			// 
			// mainMenuSave
			// 
			this.mainMenuSave.Name = "mainMenuSave";
			this.mainMenuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mainMenuSave.Size = new System.Drawing.Size(216, 22);
			this.mainMenuSave.Text = "Сохранить";
			this.mainMenuSave.Click += new System.EventHandler(this.mainMenuSave_Click);
			// 
			// mainMenuSaveAs
			// 
			this.mainMenuSaveAs.Name = "mainMenuSaveAs";
			this.mainMenuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
			this.mainMenuSaveAs.Size = new System.Drawing.Size(216, 22);
			this.mainMenuSaveAs.Text = "Сохранить как";
			this.mainMenuSaveAs.Click += new System.EventHandler(this.mainMenuSaveAs_Click);
			// 
			// mainMenuFileSeparator
			// 
			this.mainMenuFileSeparator.Name = "mainMenuFileSeparator";
			this.mainMenuFileSeparator.Size = new System.Drawing.Size(213, 6);
			// 
			// mainMenuExit
			// 
			this.mainMenuExit.Name = "mainMenuExit";
			this.mainMenuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.mainMenuExit.Size = new System.Drawing.Size(216, 22);
			this.mainMenuExit.Text = "Выход";
			this.mainMenuExit.Click += new System.EventHandler(this.mainMenuExit_Click);
			// 
			// mainMenuView
			// 
			this.mainMenuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuViewHighlight,
            this.mainMenuViewHighlightWords});
			this.mainMenuView.Name = "mainMenuView";
			this.mainMenuView.Size = new System.Drawing.Size(39, 20);
			this.mainMenuView.Text = "Вид";
			// 
			// mainMenuViewHighlight
			// 
			this.mainMenuViewHighlight.Checked = true;
			this.mainMenuViewHighlight.CheckOnClick = true;
			this.mainMenuViewHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mainMenuViewHighlight.Name = "mainMenuViewHighlight";
			this.mainMenuViewHighlight.Size = new System.Drawing.Size(249, 22);
			this.mainMenuViewHighlight.Text = "Подсвечивать Xml теги";
			// 
			// mainMenuViewHighlightWords
			// 
			this.mainMenuViewHighlightWords.Checked = true;
			this.mainMenuViewHighlightWords.CheckOnClick = true;
			this.mainMenuViewHighlightWords.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mainMenuViewHighlightWords.Name = "mainMenuViewHighlightWords";
			this.mainMenuViewHighlightWords.Size = new System.Drawing.Size(249, 22);
			this.mainMenuViewHighlightWords.Text = "Подсвечивать результат поиска";
			// 
			// open
			// 
			this.open.Filter = "Xml file|*.xml";
			this.open.SupportMultiDottedExtensions = true;
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsCountHint,
            this.itemsCount});
			this.statusBar.Location = new System.Drawing.Point(0, 454);
			this.statusBar.Name = "statusBar";
			this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.statusBar.Size = new System.Drawing.Size(803, 22);
			this.statusBar.TabIndex = 8;
			this.statusBar.Text = "StatusBar";
			// 
			// itemsCountHint
			// 
			this.itemsCountHint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.itemsCountHint.Name = "itemsCountHint";
			this.itemsCountHint.Size = new System.Drawing.Size(187, 17);
			this.itemsCountHint.Text = "Количество элементов в списке:";
			this.itemsCountHint.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			// 
			// itemsCount
			// 
			this.itemsCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.itemsCount.Name = "itemsCount";
			this.itemsCount.Size = new System.Drawing.Size(13, 17);
			this.itemsCount.Text = "0";
			// 
			// save
			// 
			this.save.DefaultExt = "xml";
			this.save.Filter = "Xml file|*.xml";
			this.save.SupportMultiDottedExtensions = true;
			// 
			// textControlsContainer
			// 
			this.textControlsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textControlsContainer.Location = new System.Drawing.Point(12, 28);
			this.textControlsContainer.Name = "textControlsContainer";
			// 
			// textControlsContainer.Panel1
			// 
			this.textControlsContainer.Panel1.Controls.Add(this.elements);
			this.textControlsContainer.Panel1MinSize = 300;
			// 
			// textControlsContainer.Panel2
			// 
			this.textControlsContainer.Panel2.Controls.Add(this.searchReplaceTabs);
			this.textControlsContainer.Panel2.Controls.Add(this.textGroup);
			this.textControlsContainer.Panel2MinSize = 320;
			this.textControlsContainer.Size = new System.Drawing.Size(779, 423);
			this.textControlsContainer.SplitterDistance = 326;
			this.textControlsContainer.SplitterWidth = 5;
			this.textControlsContainer.TabIndex = 14;
			// 
			// elements
			// 
			this.elements.AllColumns.Add(this.aliasColumn);
			this.elements.AllColumns.Add(this.originalColumn);
			this.elements.AllColumns.Add(this.translateColumn);
			this.elements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.aliasColumn,
            this.originalColumn,
            this.translateColumn});
			this.elements.ContextMenuStrip = this.elementsContextMenu;
			this.elements.Dock = System.Windows.Forms.DockStyle.Fill;
			this.elements.FullRowSelect = true;
			this.elements.GridLines = true;
			this.elements.HideSelection = false;
			this.elements.Location = new System.Drawing.Point(0, 0);
			this.elements.MultiSelect = false;
			this.elements.Name = "elements";
			this.elements.ShowGroups = false;
			this.elements.Size = new System.Drawing.Size(326, 423);
			this.elements.TabIndex = 0;
			this.elements.UseCompatibleStateImageBehavior = false;
			this.elements.View = System.Windows.Forms.View.Details;
			this.elements.VirtualMode = true;
			this.elements.SelectionChanged += new System.EventHandler(this.elements_SelectionChanged);
			// 
			// aliasColumn
			// 
			this.aliasColumn.CellPadding = null;
			this.aliasColumn.Text = "Alias";
			this.aliasColumn.Width = 300;
			// 
			// originalColumn
			// 
			this.originalColumn.CellPadding = null;
			this.originalColumn.Text = "Original";
			this.originalColumn.Width = 300;
			// 
			// translateColumn
			// 
			this.translateColumn.CellPadding = null;
			this.translateColumn.Text = "Translate";
			this.translateColumn.Width = 300;
			// 
			// searchReplaceTabs
			// 
			this.searchReplaceTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchReplaceTabs.Controls.Add(searchTab);
			this.searchReplaceTabs.Controls.Add(replaceTab);
			this.searchReplaceTabs.Location = new System.Drawing.Point(3, 4);
			this.searchReplaceTabs.Name = "searchReplaceTabs";
			this.searchReplaceTabs.SelectedIndex = 0;
			this.searchReplaceTabs.Size = new System.Drawing.Size(435, 140);
			this.searchReplaceTabs.TabIndex = 14;
			// 
			// textGroup
			// 
			this.textGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textGroup.Controls.Add(this.tableLayoutPanel1);
			this.textGroup.Location = new System.Drawing.Point(3, 150);
			this.textGroup.Name = "textGroup";
			this.textGroup.Size = new System.Drawing.Size(435, 270);
			this.textGroup.TabIndex = 13;
			this.textGroup.TabStop = false;
			this.textGroup.Text = "Текст";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.translatedText, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.originalText, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(429, 251);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// translatedText
			// 
			this.translatedText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.translatedText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.translatedText.ContextMenuStrip = this.tagsContextMenu;
			this.translatedText.DetectUrls = false;
			this.translatedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.translatedText.Location = new System.Drawing.Point(3, 128);
			this.translatedText.Name = "translatedText";
			this.translatedText.Size = new System.Drawing.Size(423, 120);
			this.translatedText.TabIndex = 6;
			this.translatedText.Text = "";
			this.translatedText.TextChanged += new System.EventHandler(this.translatedText_TextChanged);
			this.translatedText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.translatedText_KeyDown);
			this.translatedText.Leave += new System.EventHandler(this.translatedText_Leave);
			// 
			// originalText
			// 
			this.originalText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.originalText.Location = new System.Drawing.Point(3, 3);
			this.originalText.Name = "originalText";
			this.originalText.ReadOnly = true;
			this.originalText.Size = new System.Drawing.Size(423, 119);
			this.originalText.TabIndex = 7;
			this.originalText.Text = "";
			this.originalText.TextChanged += new System.EventHandler(this.originalText_TextChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(803, 476);
			this.Controls.Add(this.textControlsContainer);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.mainMenu);
			this.MainMenuStrip = this.mainMenu;
			this.MinimumSize = new System.Drawing.Size(819, 514);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bns Xml Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			searchTab.ResumeLayout(false);
			searchTab.PerformLayout();
			replaceTab.ResumeLayout(false);
			replaceTab.PerformLayout();
			this.elementsContextMenu.ResumeLayout(false);
			this.tagsContextMenu.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.textControlsContainer.Panel1.ResumeLayout(false);
			this.textControlsContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textControlsContainer)).EndInit();
			this.textControlsContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.elements)).EndInit();
			this.searchReplaceTabs.ResumeLayout(false);
			this.textGroup.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
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
		private System.Windows.Forms.Label searchFieldHint;
		private System.Windows.Forms.ComboBox searchField;
		private System.Windows.Forms.Button cancelSearch;
		private System.Windows.Forms.SaveFileDialog save;
		private System.Windows.Forms.SplitContainer textControlsContainer;
		private System.Windows.Forms.ContextMenuStrip elementsContextMenu;
		private System.Windows.Forms.ToolStripMenuItem elementsContextMenuAliasCopy;
		private HistoryComboBox searchQuery;
		private ExtendedRichTextBox translatedText;
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
		private BrightIdeasSoftware.FastObjectListView elements;
		private BrightIdeasSoftware.OLVColumn aliasColumn;
		private BrightIdeasSoftware.OLVColumn originalColumn;
		private BrightIdeasSoftware.OLVColumn translateColumn;
	}
}

