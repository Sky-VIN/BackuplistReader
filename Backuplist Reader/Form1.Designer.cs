namespace Backuplist_Reader
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllTstb = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllTstb = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionTstb = new System.Windows.Forms.ToolStripMenuItem();
            this.openBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.clearBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listClb = new System.Windows.Forms.CheckedListBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.logRtb = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fnameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.itemsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.foundLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hardlinkBtn = new System.Windows.Forms.Button();
            this.copyInBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.projectByLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllTstb,
            this.deselectAllTstb,
            this.invertSelectionTstb});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(154, 70);
            // 
            // selectAllTstb
            // 
            this.selectAllTstb.Name = "selectAllTstb";
            this.selectAllTstb.Size = new System.Drawing.Size(153, 22);
            this.selectAllTstb.Text = "Select All";
            this.selectAllTstb.Click += new System.EventHandler(this.selectAllTstb_Click);
            // 
            // deselectAllTstb
            // 
            this.deselectAllTstb.Name = "deselectAllTstb";
            this.deselectAllTstb.Size = new System.Drawing.Size(153, 22);
            this.deselectAllTstb.Text = "Deselect All";
            this.deselectAllTstb.Click += new System.EventHandler(this.deselectAllTstb_Click);
            // 
            // invertSelectionTstb
            // 
            this.invertSelectionTstb.Name = "invertSelectionTstb";
            this.invertSelectionTstb.Size = new System.Drawing.Size(153, 22);
            this.invertSelectionTstb.Text = "Invert Selection";
            this.invertSelectionTstb.Click += new System.EventHandler(this.invertSelectionTstb_Click);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(12, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(85, 23);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "Open list";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select folder to copy / hardlink selected items";
            this.folderBrowserDialog1.Tag = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text files|*.txt|All files|*.*";
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.Title = "Open list file";
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.Location = new System.Drawing.Point(687, 12);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(85, 23);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "Clear fields";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(103, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(85, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save list";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text files | *.txt | All files | *.*";
            this.saveFileDialog1.Tag = "Tag";
            this.saveFileDialog1.Title = "Title";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(6, 48);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listClb);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.logLabel);
            this.splitContainer.Panel2.Controls.Add(this.logRtb);
            this.splitContainer.Size = new System.Drawing.Size(748, 424);
            this.splitContainer.SplitterDistance = 298;
            this.splitContainer.TabIndex = 8;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // listClb
            // 
            this.listClb.CheckOnClick = true;
            this.listClb.ContextMenuStrip = this.contextMenuStrip;
            this.listClb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listClb.HorizontalScrollbar = true;
            this.listClb.Location = new System.Drawing.Point(0, 0);
            this.listClb.Name = "listClb";
            this.listClb.Size = new System.Drawing.Size(748, 298);
            this.listClb.Sorted = true;
            this.listClb.TabIndex = 7;
            this.listClb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listClb_ItemCheck);
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logLabel.Location = new System.Drawing.Point(0, 0);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(43, 13);
            this.logLabel.TabIndex = 0;
            this.logLabel.Text = "Events:";
            this.logLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logRtb
            // 
            this.logRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logRtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logRtb.Location = new System.Drawing.Point(0, 16);
            this.logRtb.Name = "logRtb";
            this.logRtb.ReadOnly = true;
            this.logRtb.Size = new System.Drawing.Size(748, 106);
            this.logRtb.TabIndex = 8;
            this.logRtb.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.fnameLabel,
            this.toolStripStatusLabel2,
            this.folderLabel,
            this.toolStripStatusLabel3,
            this.itemsLabel,
            this.toolStripStatusLabel4,
            this.foundLabel,
            this.toolStripStatusLabel5,
            this.selectedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
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
            this.fnameLabel.Text = "(empty)";
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
            this.folderLabel.Text = "(empty)";
            this.folderLabel.Click += new System.EventHandler(this.folderLabel_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel3.Text = "Items:";
            // 
            // itemsLabel
            // 
            this.itemsLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itemsLabel.Margin = new System.Windows.Forms.Padding(0, 3, 25, 2);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(13, 17);
            this.itemsLabel.Text = "0";
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
            this.groupBox1.Controls.Add(this.hardlinkBtn);
            this.groupBox1.Controls.Add(this.copyInBtn);
            this.groupBox1.Controls.Add(this.copyBtn);
            this.groupBox1.Controls.Add(this.splitContainer);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 478);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // hardlinkBtn
            // 
            this.hardlinkBtn.Enabled = false;
            this.hardlinkBtn.Location = new System.Drawing.Point(6, 19);
            this.hardlinkBtn.Name = "hardlinkBtn";
            this.hardlinkBtn.Size = new System.Drawing.Size(100, 23);
            this.hardlinkBtn.TabIndex = 4;
            this.hardlinkBtn.Text = "Hardlink to...";
            this.hardlinkBtn.UseVisualStyleBackColor = true;
            this.hardlinkBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // copyInBtn
            // 
            this.copyInBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyInBtn.Enabled = false;
            this.copyInBtn.Location = new System.Drawing.Point(654, 19);
            this.copyInBtn.Name = "copyInBtn";
            this.copyInBtn.Size = new System.Drawing.Size(100, 23);
            this.copyInBtn.TabIndex = 6;
            this.copyInBtn.Text = "Copy in...";
            this.copyInBtn.UseVisualStyleBackColor = true;
            this.copyInBtn.Click += new System.EventHandler(this.copyInBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Enabled = false;
            this.copyBtn.Location = new System.Drawing.Point(112, 19);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(100, 23);
            this.copyBtn.TabIndex = 5;
            this.copyBtn.Text = "Copy to...";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // projectByLabel
            // 
            this.projectByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.projectByLabel.AutoSize = true;
            this.projectByLabel.Enabled = false;
            this.projectByLabel.Location = new System.Drawing.Point(633, 522);
            this.projectByLabel.Name = "projectByLabel";
            this.projectByLabel.Size = new System.Drawing.Size(136, 13);
            this.projectByLabel.TabIndex = 0;
            this.projectByLabel.Text = "Daniel Swan © 2015, 2019";
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
            this.progressBar.Size = new System.Drawing.Size(615, 15);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.projectByLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.openBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIN: Backuplist Reader";
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem selectAllTstb;
        private System.Windows.Forms.ToolStripMenuItem deselectAllTstb;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionTstb;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.CheckedListBox listClb;
        private System.Windows.Forms.RichTextBox logRtb;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel fnameLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel folderLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel itemsLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel foundLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button hardlinkBtn;
        private System.Windows.Forms.Button copyInBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Label projectByLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel selectedLabel;
    }
}

