namespace BackuplistReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listMenuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.listMenuItemDeselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.listMenuItemInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.listMenuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.listMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.listMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.openListBtn = new System.Windows.Forms.Button();
            this.browserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.clearFieldsBtn = new System.Windows.Forms.Button();
            this.saveListBtn = new System.Windows.Forms.Button();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mainListView = new System.Windows.Forms.ListView();
            this.lvChk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSubFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabs = new System.Windows.Forms.TabControl();
            this.logPage = new System.Windows.Forms.TabPage();
            this.logListView = new System.Windows.Forms.ListView();
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.inSearchLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.foundLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dublicatesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainGroup = new System.Windows.Forms.GroupBox();
            this.copyGroup = new System.Windows.Forms.GroupBox();
            this.overwriteChb = new System.Windows.Forms.CheckBox();
            this.copyToBtn = new System.Windows.Forms.Button();
            this.copyInBtn = new System.Windows.Forms.Button();
            this.linkGroup = new System.Windows.Forms.GroupBox();
            this.symlinkRadio = new System.Windows.Forms.RadioButton();
            this.hardlinkRadio = new System.Windows.Forms.RadioButton();
            this.linkToBtn = new System.Windows.Forms.Button();
            this.projectByLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.listMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabs.SuspendLayout();
            this.logPage.SuspendLayout();
            this.logMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainGroup.SuspendLayout();
            this.copyGroup.SuspendLayout();
            this.linkGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // listMenu
            // 
            this.listMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listMenuItemSelectAll,
            this.listMenuItemDeselectAll,
            this.listMenuItemInvert,
            this.listMenuItemSeparator,
            this.listMenuItemDelete,
            this.toolStripMenuItem1,
            this.listMenuItemHelp});
            this.listMenu.Name = "contextMenuStrip";
            this.listMenu.Size = new System.Drawing.Size(310, 126);
            // 
            // listMenuItemSelectAll
            // 
            this.listMenuItemSelectAll.Name = "listMenuItemSelectAll";
            this.listMenuItemSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.listMenuItemSelectAll.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemSelectAll.Text = global::BackuplistReader.Strings.SelectAll;
            this.listMenuItemSelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // listMenuItemDeselectAll
            // 
            this.listMenuItemDeselectAll.Name = "listMenuItemDeselectAll";
            this.listMenuItemDeselectAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.listMenuItemDeselectAll.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemDeselectAll.Text = global::BackuplistReader.Strings.DeselectAll;
            this.listMenuItemDeselectAll.Click += new System.EventHandler(this.DeselectAll_Click);
            // 
            // listMenuItemInvert
            // 
            this.listMenuItemInvert.Name = "listMenuItemInvert";
            this.listMenuItemInvert.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemInvert.Text = global::BackuplistReader.Strings.Invert;
            this.listMenuItemInvert.Click += new System.EventHandler(this.InvertSelection_Click);
            // 
            // listMenuItemSeparator
            // 
            this.listMenuItemSeparator.Name = "listMenuItemSeparator";
            this.listMenuItemSeparator.Size = new System.Drawing.Size(306, 6);
            // 
            // listMenuItemDelete
            // 
            this.listMenuItemDelete.Name = "listMenuItemDelete";
            this.listMenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.listMenuItemDelete.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemDelete.Text = "Delete";
            this.listMenuItemDelete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(306, 6);
            // 
            // listMenuItemHelp
            // 
            this.listMenuItemHelp.Enabled = false;
            this.listMenuItemHelp.Name = "listMenuItemHelp";
            this.listMenuItemHelp.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemHelp.Text = global::BackuplistReader.Strings.ListMenuHelp;
            // 
            // openListBtn
            // 
            this.openListBtn.Location = new System.Drawing.Point(12, 12);
            this.openListBtn.Name = "openListBtn";
            this.openListBtn.Size = new System.Drawing.Size(85, 25);
            this.openListBtn.TabIndex = 0;
            this.openListBtn.Text = global::BackuplistReader.Strings.OpenList;
            this.openListBtn.UseVisualStyleBackColor = true;
            this.openListBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // browserDialog
            // 
            this.browserDialog.Description = "Select folder to copy / hardlink selected items";
            this.browserDialog.Tag = global::BackuplistReader.Strings.FileExist;
            // 
            // openDialog
            // 
            this.openDialog.Filter = "Daniel\'s Backuplist files|*.dbf|Text files|*.txt|All files|*.*";
            this.openDialog.ReadOnlyChecked = true;
            this.openDialog.Title = "Open list file";
            // 
            // clearFieldsBtn
            // 
            this.clearFieldsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearFieldsBtn.Location = new System.Drawing.Point(911, 12);
            this.clearFieldsBtn.Name = "clearFieldsBtn";
            this.clearFieldsBtn.Size = new System.Drawing.Size(85, 25);
            this.clearFieldsBtn.TabIndex = 2;
            this.clearFieldsBtn.Text = global::BackuplistReader.Strings.ClearFields;
            this.clearFieldsBtn.UseVisualStyleBackColor = true;
            this.clearFieldsBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // saveListBtn
            // 
            this.saveListBtn.Enabled = false;
            this.saveListBtn.Location = new System.Drawing.Point(103, 12);
            this.saveListBtn.Name = "saveListBtn";
            this.saveListBtn.Size = new System.Drawing.Size(85, 25);
            this.saveListBtn.TabIndex = 1;
            this.saveListBtn.Text = global::BackuplistReader.Strings.SaveList;
            this.saveListBtn.UseVisualStyleBackColor = true;
            this.saveListBtn.Click += new System.EventHandler(this.SaveListBtn_Click);
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Text files|*.txt|All files|*.*";
            this.saveDialog.Title = "Title";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(6, 57);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.mainListView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabs);
            this.splitContainer.Panel2MinSize = 20;
            this.splitContainer.Size = new System.Drawing.Size(972, 572);
            this.splitContainer.SplitterDistance = 430;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 3;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer_SplitterMoved);
            // 
            // mainListView
            // 
            this.mainListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainListView.CheckBoxes = true;
            this.mainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvChk,
            this.lvExt,
            this.lvName,
            this.lvSubFolder,
            this.lvPath});
            this.mainListView.ContextMenuStrip = this.listMenu;
            this.mainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainListView.Enabled = false;
            this.mainListView.FullRowSelect = true;
            this.mainListView.Location = new System.Drawing.Point(0, 0);
            this.mainListView.Margin = new System.Windows.Forms.Padding(0);
            this.mainListView.Name = "mainListView";
            this.mainListView.Size = new System.Drawing.Size(972, 430);
            this.mainListView.TabIndex = 0;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.View = System.Windows.Forms.View.Details;
            this.mainListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MainListView_ColumnClick);
            this.mainListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.MainListView_ColumnWidthChanging);
            this.mainListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.mainListView_ItemChecked);
            // 
            // lvChk
            // 
            this.lvChk.Text = "";
            this.lvChk.Width = 25;
            // 
            // lvExt
            // 
            this.lvExt.Text = "Type";
            this.lvExt.Width = 50;
            // 
            // lvName
            // 
            this.lvName.Text = "Name";
            this.lvName.Width = 250;
            // 
            // lvSubFolder
            // 
            this.lvSubFolder.Text = "Destination Sub Folder";
            this.lvSubFolder.Width = 200;
            // 
            // lvPath
            // 
            this.lvPath.Text = "Source Path";
            this.lvPath.Width = 400;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.logPage);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Margin = new System.Windows.Forms.Padding(0);
            this.tabs.Multiline = true;
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(972, 137);
            this.tabs.TabIndex = 0;
            this.tabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabs_KeyDown);
            this.tabs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabs_MouseDoubleClick);
            // 
            // logPage
            // 
            this.logPage.BackColor = System.Drawing.SystemColors.Control;
            this.logPage.Controls.Add(this.logListView);
            this.logPage.Location = new System.Drawing.Point(4, 22);
            this.logPage.Margin = new System.Windows.Forms.Padding(0);
            this.logPage.Name = "logPage";
            this.logPage.Size = new System.Drawing.Size(964, 111);
            this.logPage.TabIndex = 0;
            this.logPage.Text = "Events";
            // 
            // logListView
            // 
            this.logListView.BackColor = System.Drawing.SystemColors.Window;
            this.logListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colEvent,
            this.ColMessage});
            this.logListView.ContextMenuStrip = this.logMenu;
            this.logListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListView.FullRowSelect = true;
            this.logListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.logListView.Location = new System.Drawing.Point(0, 0);
            this.logListView.Margin = new System.Windows.Forms.Padding(0);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(964, 111);
            this.logListView.TabIndex = 0;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // colTime
            // 
            this.colTime.Width = 75;
            // 
            // colEvent
            // 
            this.colEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colEvent.Width = 150;
            // 
            // ColMessage
            // 
            this.ColMessage.Width = 250;
            // 
            // logMenu
            // 
            this.logMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logMenuItemCopy});
            this.logMenu.Name = "logContextMenuStrip";
            this.logMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // logMenuItemCopy
            // 
            this.logMenuItemCopy.Name = "logMenuItemCopy";
            this.logMenuItemCopy.Size = new System.Drawing.Size(100, 22);
            this.logMenuItemCopy.Text = "Copy";
            this.logMenuItemCopy.Click += new System.EventHandler(this.LogMenuItemCopy_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.fileLabel,
            this.toolStripStatusLabel2,
            this.folderLabel,
            this.toolStripStatusLabel3,
            this.inSearchLabel,
            this.toolStripStatusLabel4,
            this.foundLabel,
            this.toolStripStatusLabel6,
            this.dublicatesLabel,
            this.toolStripStatusLabel5,
            this.selectedLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 708);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "File name:";
            // 
            // fileLabel
            // 
            this.fileLabel.AccessibleDescription = global::BackuplistReader.Strings.FileExist;
            this.fileLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(44, 17);
            this.fileLabel.Text = global::BackuplistReader.Strings.Empty;
            this.fileLabel.Click += new System.EventHandler(this.FileLabel_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel2.Text = "Search in:";
            // 
            // folderLabel
            // 
            this.folderLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.folderLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(44, 17);
            this.folderLabel.Text = global::BackuplistReader.Strings.Empty;
            this.folderLabel.Click += new System.EventHandler(this.FolderLabel_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel3.Text = "In search:";
            // 
            // inSearchLabel
            // 
            this.inSearchLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.inSearchLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.inSearchLabel.Name = "inSearchLabel";
            this.inSearchLabel.Size = new System.Drawing.Size(13, 17);
            this.inSearchLabel.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel4.Text = "Found:";
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.Easter);
            // 
            // foundLabel
            // 
            this.foundLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.foundLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.foundLabel.Name = "foundLabel";
            this.foundLabel.Size = new System.Drawing.Size(13, 17);
            this.foundLabel.Text = "0";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel6.Text = "Dublicates:";
            // 
            // dublicatesLabel
            // 
            this.dublicatesLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dublicatesLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.dublicatesLabel.Name = "dublicatesLabel";
            this.dublicatesLabel.Size = new System.Drawing.Size(13, 17);
            this.dublicatesLabel.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel5.Text = "Selected:";
            // 
            // selectedLabel
            // 
            this.selectedLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectedLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(13, 17);
            this.selectedLabel.Text = "0";
            // 
            // mainGroup
            // 
            this.mainGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroup.Controls.Add(this.copyGroup);
            this.mainGroup.Controls.Add(this.copyInBtn);
            this.mainGroup.Controls.Add(this.linkGroup);
            this.mainGroup.Controls.Add(this.splitContainer);
            this.mainGroup.Location = new System.Drawing.Point(12, 43);
            this.mainGroup.Name = "mainGroup";
            this.mainGroup.Size = new System.Drawing.Size(984, 635);
            this.mainGroup.TabIndex = 3;
            this.mainGroup.TabStop = false;
            // 
            // copyGroup
            // 
            this.copyGroup.Controls.Add(this.overwriteChb);
            this.copyGroup.Controls.Add(this.copyToBtn);
            this.copyGroup.Enabled = false;
            this.copyGroup.Location = new System.Drawing.Point(8, 8);
            this.copyGroup.Name = "copyGroup";
            this.copyGroup.Size = new System.Drawing.Size(200, 43);
            this.copyGroup.TabIndex = 0;
            this.copyGroup.TabStop = false;
            // 
            // overwriteChb
            // 
            this.overwriteChb.AutoSize = true;
            this.overwriteChb.Location = new System.Drawing.Point(112, 16);
            this.overwriteChb.Name = "overwriteChb";
            this.overwriteChb.Size = new System.Drawing.Size(71, 17);
            this.overwriteChb.TabIndex = 1;
            this.overwriteChb.Text = "Overwrite";
            this.overwriteChb.UseVisualStyleBackColor = true;
            // 
            // copyToBtn
            // 
            this.copyToBtn.Location = new System.Drawing.Point(6, 11);
            this.copyToBtn.Name = "copyToBtn";
            this.copyToBtn.Size = new System.Drawing.Size(100, 25);
            this.copyToBtn.TabIndex = 0;
            this.copyToBtn.Text = "Copy to...";
            this.copyToBtn.UseVisualStyleBackColor = true;
            this.copyToBtn.Click += new System.EventHandler(this.CopyAndLinkBtn_Click);
            // 
            // copyInBtn
            // 
            this.copyInBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyInBtn.Enabled = false;
            this.copyInBtn.Location = new System.Drawing.Point(875, 19);
            this.copyInBtn.Name = "copyInBtn";
            this.copyInBtn.Size = new System.Drawing.Size(100, 25);
            this.copyInBtn.TabIndex = 1;
            this.copyInBtn.Text = "Copy in...";
            this.copyInBtn.UseVisualStyleBackColor = true;
            this.copyInBtn.Visible = false;
            this.copyInBtn.Click += new System.EventHandler(this.CopyAndLinkBtn_Click);
            // 
            // linkGroup
            // 
            this.linkGroup.Controls.Add(this.symlinkRadio);
            this.linkGroup.Controls.Add(this.hardlinkRadio);
            this.linkGroup.Controls.Add(this.linkToBtn);
            this.linkGroup.Enabled = false;
            this.linkGroup.Location = new System.Drawing.Point(214, 8);
            this.linkGroup.Name = "linkGroup";
            this.linkGroup.Size = new System.Drawing.Size(275, 43);
            this.linkGroup.TabIndex = 0;
            this.linkGroup.TabStop = false;
            // 
            // symlinkRadio
            // 
            this.symlinkRadio.AutoSize = true;
            this.symlinkRadio.Location = new System.Drawing.Point(178, 15);
            this.symlinkRadio.Name = "symlinkRadio";
            this.symlinkRadio.Size = new System.Drawing.Size(67, 17);
            this.symlinkRadio.TabIndex = 2;
            this.symlinkRadio.Text = "Symbolic";
            this.symlinkRadio.UseVisualStyleBackColor = true;
            // 
            // hardlinkRadio
            // 
            this.hardlinkRadio.AutoSize = true;
            this.hardlinkRadio.Checked = true;
            this.hardlinkRadio.Location = new System.Drawing.Point(112, 15);
            this.hardlinkRadio.Name = "hardlinkRadio";
            this.hardlinkRadio.Size = new System.Drawing.Size(64, 17);
            this.hardlinkRadio.TabIndex = 1;
            this.hardlinkRadio.TabStop = true;
            this.hardlinkRadio.Text = "Hardlink";
            this.hardlinkRadio.UseVisualStyleBackColor = true;
            // 
            // linkToBtn
            // 
            this.linkToBtn.Location = new System.Drawing.Point(6, 11);
            this.linkToBtn.Name = "linkToBtn";
            this.linkToBtn.Size = new System.Drawing.Size(100, 25);
            this.linkToBtn.TabIndex = 0;
            this.linkToBtn.Text = "Link to...";
            this.linkToBtn.UseVisualStyleBackColor = true;
            this.linkToBtn.Click += new System.EventHandler(this.CopyAndLinkBtn_Click);
            // 
            // projectByLabel
            // 
            this.projectByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.projectByLabel.AutoSize = true;
            this.projectByLabel.Enabled = false;
            this.projectByLabel.Location = new System.Drawing.Point(800, 686);
            this.projectByLabel.Name = "projectByLabel";
            this.projectByLabel.Size = new System.Drawing.Size(196, 13);
            this.projectByLabel.TabIndex = 7;
            this.projectByLabel.Text = "Daniel Swan © 2015, 2019, 2020, 2022";
            this.projectByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(93, 680);
            this.progressBar.Maximum = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(701, 25);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Location = new System.Drawing.Point(12, 680);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 25);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.projectByLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.saveListBtn);
            this.Controls.Add(this.clearFieldsBtn);
            this.Controls.Add(this.mainGroup);
            this.Controls.Add(this.openListBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIN: Backuplist Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_Resize);
            this.listMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.logPage.ResumeLayout(false);
            this.logMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainGroup.ResumeLayout(false);
            this.copyGroup.ResumeLayout(false);
            this.copyGroup.PerformLayout();
            this.linkGroup.ResumeLayout(false);
            this.linkGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openListBtn;
        private System.Windows.Forms.ContextMenuStrip listMenu;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemDeselectAll;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemInvert;
        private System.Windows.Forms.FolderBrowserDialog browserDialog;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Button clearFieldsBtn;
        private System.Windows.Forms.Button saveListBtn;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel fileLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel folderLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel inSearchLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel foundLabel;
        private System.Windows.Forms.GroupBox mainGroup;
        private System.Windows.Forms.Label projectByLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel selectedLabel;
        private System.Windows.Forms.GroupBox linkGroup;
        private System.Windows.Forms.RadioButton symlinkRadio;
        private System.Windows.Forms.RadioButton hardlinkRadio;
        private System.Windows.Forms.Button linkToBtn;
        private System.Windows.Forms.ContextMenuStrip logMenu;
        private System.Windows.Forms.ToolStripMenuItem logMenuItemCopy;
        private System.Windows.Forms.ToolStripSeparator listMenuItemSeparator;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemHelp;
        private System.Windows.Forms.ColumnHeader lvChk;
        private System.Windows.Forms.ColumnHeader lvName;
        private System.Windows.Forms.ColumnHeader lvPath;
        private System.Windows.Forms.GroupBox copyGroup;
        private System.Windows.Forms.Button copyToBtn;
        private System.Windows.Forms.Button copyInBtn;
        private System.Windows.Forms.CheckBox overwriteChb;
        private System.Windows.Forms.ColumnHeader lvSubFolder;
        private System.Windows.Forms.ColumnHeader lvExt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel dublicatesLabel;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ListView mainListView;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage logPage;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colEvent;
        private System.Windows.Forms.ColumnHeader ColMessage;
    }
}

