namespace Backuplist_Reader
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
            this.listMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.openBtn = new System.Windows.Forms.Button();
            this.browserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.clearBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listClb = new System.Windows.Forms.ListView();
            this.lvChk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logLabel = new System.Windows.Forms.Label();
            this.logList = new System.Windows.Forms.ListView();
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fnameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.foundLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyGroup = new System.Windows.Forms.GroupBox();
            this.chBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.copyBtn = new System.Windows.Forms.Button();
            this.copyInBtn = new System.Windows.Forms.Button();
            this.linkGroup = new System.Windows.Forms.GroupBox();
            this.rbSlink = new System.Windows.Forms.RadioButton();
            this.rbHlink = new System.Windows.Forms.RadioButton();
            this.linkBtn = new System.Windows.Forms.Button();
            this.projectByLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listMenu.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.logMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.listMenuItemHelp});
            this.listMenu.Name = "contextMenuStrip";
            this.listMenu.Size = new System.Drawing.Size(310, 98);
            // 
            // listMenuItemSelectAll
            // 
            this.listMenuItemSelectAll.Name = "listMenuItemSelectAll";
            this.listMenuItemSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.listMenuItemSelectAll.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemSelectAll.Text = global::Backuplist_Reader.Strings.SelectAll;
            this.listMenuItemSelectAll.Click += new System.EventHandler(this.SelectAllTstb_Click);
            // 
            // listMenuItemDeselectAll
            // 
            this.listMenuItemDeselectAll.Name = "listMenuItemDeselectAll";
            this.listMenuItemDeselectAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.listMenuItemDeselectAll.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemDeselectAll.Text = global::Backuplist_Reader.Strings.DeselectAll;
            this.listMenuItemDeselectAll.Click += new System.EventHandler(this.DeselectAllTstb_Click);
            // 
            // listMenuItemInvert
            // 
            this.listMenuItemInvert.Name = "listMenuItemInvert";
            this.listMenuItemInvert.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemInvert.Text = global::Backuplist_Reader.Strings.Invert;
            this.listMenuItemInvert.Click += new System.EventHandler(this.InvertSelectionTstb_Click);
            // 
            // listMenuItemSeparator
            // 
            this.listMenuItemSeparator.Name = "listMenuItemSeparator";
            this.listMenuItemSeparator.Size = new System.Drawing.Size(306, 6);
            // 
            // listMenuItemHelp
            // 
            this.listMenuItemHelp.Enabled = false;
            this.listMenuItemHelp.Name = "listMenuItemHelp";
            this.listMenuItemHelp.Size = new System.Drawing.Size(309, 22);
            this.listMenuItemHelp.Text = global::Backuplist_Reader.Strings.listMenuHelp;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(12, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(85, 25);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = global::Backuplist_Reader.Strings.OpenList;
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // browserDialog
            // 
            this.browserDialog.Description = "Select folder to copy / hardlink selected items";
            this.browserDialog.Tag = "";
            // 
            // openDialog
            // 
            this.openDialog.Filter = "Text files|*.txt|All files|*.*";
            this.openDialog.ReadOnlyChecked = true;
            this.openDialog.Title = "Open list file";
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.Location = new System.Drawing.Point(687, 12);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(85, 25);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = global::Backuplist_Reader.Strings.ClearFields;
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(103, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(85, 25);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = global::Backuplist_Reader.Strings.SaveList;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Text files | *.txt | All files | *.*";
            this.saveDialog.Tag = "Tag";
            this.saveDialog.Title = "Title";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(6, 57);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listClb);
            this.splitContainer.Panel1MinSize = 30;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.logLabel);
            this.splitContainer.Panel2.Controls.Add(this.logList);
            this.splitContainer.Panel2MinSize = 20;
            this.splitContainer.Size = new System.Drawing.Size(748, 413);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 8;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // listClb
            // 
            this.listClb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listClb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listClb.CheckBoxes = true;
            this.listClb.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvChk,
            this.lvName,
            this.lvPath});
            this.listClb.ContextMenuStrip = this.listMenu;
            this.listClb.Enabled = false;
            this.listClb.FullRowSelect = true;
            this.listClb.Location = new System.Drawing.Point(3, 3);
            this.listClb.Name = "listClb";
            this.listClb.Size = new System.Drawing.Size(742, 294);
            this.listClb.TabIndex = 0;
            this.listClb.UseCompatibleStateImageBehavior = false;
            this.listClb.View = System.Windows.Forms.View.Details;
            this.listClb.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listClb_ColumnClick);
            this.listClb.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listClb_ColumnWidthChanging);
            this.listClb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listClb_ItemCheck);
            // 
            // lvChk
            // 
            this.lvChk.Text = "";
            this.lvChk.Width = 25;
            // 
            // lvName
            // 
            this.lvName.Text = "Name";
            this.lvName.Width = 250;
            // 
            // lvPath
            // 
            this.lvPath.Text = "Path";
            this.lvPath.Width = 250;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logLabel.Location = new System.Drawing.Point(0, 0);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(43, 13);
            this.logLabel.TabIndex = 2;
            this.logLabel.Text = "Events:";
            this.logLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logList
            // 
            this.logList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logList.BackColor = System.Drawing.SystemColors.Control;
            this.logList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colEvent,
            this.ColMessage});
            this.logList.ContextMenuStrip = this.logMenu;
            this.logList.Cursor = System.Windows.Forms.Cursors.Default;
            this.logList.FullRowSelect = true;
            this.logList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.logList.Location = new System.Drawing.Point(3, 16);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(742, 92);
            this.logList.TabIndex = 1;
            this.logList.UseCompatibleStateImageBehavior = false;
            this.logList.View = System.Windows.Forms.View.Details;
            this.logList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.logList_KeyDown);
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
            this.logMenuItemCopy.Text = global::Backuplist_Reader.Strings.Copy;
            this.logMenuItemCopy.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.fnameLabel,
            this.toolStripStatusLabel2,
            this.folderLabel,
            this.toolStripStatusLabel3,
            this.searchLabel,
            this.toolStripStatusLabel4,
            this.foundLabel,
            this.toolStripStatusLabel5,
            this.selectedLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "File name:";
            // 
            // fnameLabel
            // 
            this.fnameLabel.AccessibleDescription = "";
            this.fnameLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fnameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.fnameLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.fnameLabel.Name = "fnameLabel";
            this.fnameLabel.Size = new System.Drawing.Size(44, 17);
            this.fnameLabel.Text = global::Backuplist_Reader.Strings.Empty;
            this.fnameLabel.Click += new System.EventHandler(this.fnameLabel_Click);
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
            this.folderLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.folderLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(44, 17);
            this.folderLabel.Text = global::Backuplist_Reader.Strings.Empty;
            this.folderLabel.Click += new System.EventHandler(this.folderLabel_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel3.Text = "Search:";
            // 
            // searchLabel
            // 
            this.searchLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.searchLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(13, 17);
            this.searchLabel.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel4.Text = "Found:";
            // 
            // foundLabel
            // 
            this.foundLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.foundLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.foundLabel.Name = "foundLabel";
            this.foundLabel.Size = new System.Drawing.Size(13, 17);
            this.foundLabel.Text = "0";
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.copyGroup);
            this.groupBox1.Controls.Add(this.copyInBtn);
            this.groupBox1.Controls.Add(this.linkGroup);
            this.groupBox1.Controls.Add(this.splitContainer);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 476);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // copyGroup
            // 
            this.copyGroup.Controls.Add(this.chBoxOverwrite);
            this.copyGroup.Controls.Add(this.copyBtn);
            this.copyGroup.Enabled = false;
            this.copyGroup.Location = new System.Drawing.Point(8, 8);
            this.copyGroup.Name = "copyGroup";
            this.copyGroup.Size = new System.Drawing.Size(200, 43);
            this.copyGroup.TabIndex = 14;
            this.copyGroup.TabStop = false;
            // 
            // chBoxOverwrite
            // 
            this.chBoxOverwrite.AutoSize = true;
            this.chBoxOverwrite.Location = new System.Drawing.Point(112, 16);
            this.chBoxOverwrite.Name = "chBoxOverwrite";
            this.chBoxOverwrite.Size = new System.Drawing.Size(71, 17);
            this.chBoxOverwrite.TabIndex = 7;
            this.chBoxOverwrite.Text = "Overwrite";
            this.chBoxOverwrite.UseVisualStyleBackColor = true;
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(6, 11);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(100, 25);
            this.copyBtn.TabIndex = 6;
            this.copyBtn.Text = "Copy to...";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // copyInBtn
            // 
            this.copyInBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyInBtn.Enabled = false;
            this.copyInBtn.Location = new System.Drawing.Point(651, 19);
            this.copyInBtn.Name = "copyInBtn";
            this.copyInBtn.Size = new System.Drawing.Size(100, 25);
            this.copyInBtn.TabIndex = 15;
            this.copyInBtn.Text = "Copy in...";
            this.copyInBtn.UseVisualStyleBackColor = true;
            this.copyInBtn.Click += new System.EventHandler(this.copyInBtn_Click);
            // 
            // linkGroup
            // 
            this.linkGroup.Controls.Add(this.rbSlink);
            this.linkGroup.Controls.Add(this.rbHlink);
            this.linkGroup.Controls.Add(this.linkBtn);
            this.linkGroup.Enabled = false;
            this.linkGroup.Location = new System.Drawing.Point(214, 8);
            this.linkGroup.Name = "linkGroup";
            this.linkGroup.Size = new System.Drawing.Size(275, 43);
            this.linkGroup.TabIndex = 12;
            this.linkGroup.TabStop = false;
            // 
            // rbSlink
            // 
            this.rbSlink.AutoSize = true;
            this.rbSlink.Location = new System.Drawing.Point(178, 15);
            this.rbSlink.Name = "rbSlink";
            this.rbSlink.Size = new System.Drawing.Size(67, 17);
            this.rbSlink.TabIndex = 12;
            this.rbSlink.Text = "Symbolic";
            this.rbSlink.UseVisualStyleBackColor = true;
            // 
            // rbHlink
            // 
            this.rbHlink.AutoSize = true;
            this.rbHlink.Checked = true;
            this.rbHlink.Location = new System.Drawing.Point(112, 15);
            this.rbHlink.Name = "rbHlink";
            this.rbHlink.Size = new System.Drawing.Size(64, 17);
            this.rbHlink.TabIndex = 11;
            this.rbHlink.TabStop = true;
            this.rbHlink.Text = "Hardlink";
            this.rbHlink.UseVisualStyleBackColor = true;
            // 
            // linkBtn
            // 
            this.linkBtn.Location = new System.Drawing.Point(6, 11);
            this.linkBtn.Name = "linkBtn";
            this.linkBtn.Size = new System.Drawing.Size(100, 25);
            this.linkBtn.TabIndex = 5;
            this.linkBtn.Text = "Link to...";
            this.linkBtn.UseVisualStyleBackColor = true;
            this.linkBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // projectByLabel
            // 
            this.projectByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.projectByLabel.AutoSize = true;
            this.projectByLabel.Enabled = false;
            this.projectByLabel.Location = new System.Drawing.Point(606, 522);
            this.projectByLabel.Name = "projectByLabel";
            this.projectByLabel.Size = new System.Drawing.Size(166, 13);
            this.projectByLabel.TabIndex = 0;
            this.projectByLabel.Text = "Daniel Swan © 2015, 2019, 2020";
            this.projectByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 522);
            this.progressBar.MarqueeAnimationSpeed = 1000;
            this.progressBar.Maximum = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(588, 15);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.projectByLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.openBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIN: Backuplist Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.listMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.logMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.copyGroup.ResumeLayout(false);
            this.copyGroup.PerformLayout();
            this.linkGroup.ResumeLayout(false);
            this.linkGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.ContextMenuStrip listMenu;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemDeselectAll;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemInvert;
        private System.Windows.Forms.FolderBrowserDialog browserDialog;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel fnameLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel folderLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel searchLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel foundLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label projectByLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel selectedLabel;
        private System.Windows.Forms.GroupBox linkGroup;
        private System.Windows.Forms.RadioButton rbSlink;
        private System.Windows.Forms.RadioButton rbHlink;
        private System.Windows.Forms.Button linkBtn;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.ListView logList;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colEvent;
        private System.Windows.Forms.ColumnHeader ColMessage;
        private System.Windows.Forms.ContextMenuStrip logMenu;
        private System.Windows.Forms.ToolStripMenuItem logMenuItemCopy;
        private System.Windows.Forms.ToolStripSeparator listMenuItemSeparator;
        private System.Windows.Forms.ToolStripMenuItem listMenuItemHelp;
        private System.Windows.Forms.ListView listClb;
        private System.Windows.Forms.ColumnHeader lvChk;
        private System.Windows.Forms.ColumnHeader lvName;
        private System.Windows.Forms.ColumnHeader lvPath;
        private System.Windows.Forms.GroupBox copyGroup;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button copyInBtn;
        private System.Windows.Forms.CheckBox chBoxOverwrite;
    }
}

