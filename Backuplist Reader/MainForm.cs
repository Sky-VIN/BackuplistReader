using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace BackuplistReader
{
    public partial class MainForm : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private ListViewColumnSorter lvColumnSorter = new ListViewColumnSorter();
        private List<Data.BackupListItem> BackupList = new List<Data.BackupListItem>();

        private int inSearchCount = 0;
        private int selectedCount;
        private int errorCount;
        private int missingCount;
        private int doneCount;

        private string errorMessage;

        private PressedButton pressedButton;
        private enum PressedButton : byte { OpenList, CopyTo, LinkTo };

        private LogSize logSize = LogSize.Collapsed;
        private enum LogSize : byte { Collapsed, Opened, Expanded };

        private byte easter = 0;

        /* --------------- LOG --------------- */
        private void SetLog(string time, string type, string message, Color color, FontStyle fontStyle)
        {
            this.Invoke((MethodInvoker)delegate
                {
                    ListViewItem logItem = new ListViewItem(new string[] { time, type, message });
                    logItem.Font = new Font(logItem.Font, fontStyle);
                    logItem.ForeColor = color;
                    logListView.Items.Add(logItem);
                    logListView.EnsureVisible(logListView.Items.Count - 1);
                    AlignLogListFields();
                });
        }
        /* --------------- END OF LOG --------------- */


        /* --------------- FORM AND CONTROLS --------------- */
        public MainForm()
        {
            InitializeComponent();
            InitialBackgroundWorker();
        }

        private void InitialBackgroundWorker()
        {
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += DoWork;
            worker.ProgressChanged += ProcessChanged;
            worker.RunWorkerCompleted += RunWorkerCompleted;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            mainListView.ListViewItemSorter = lvColumnSorter;

            /* Avoid flickering ListView on update * https://stackoverflow.com/a/42389596/5521566 */
            mainListView
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(mainListView, true, null);

            logListView
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(logListView, true, null);

            Data.Load();

            /* make log window collapsed */
            splitContainer.SplitterDistance = splitContainer.Height;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        { Data.Save(); }


        private void OnResize()
        {
            logListView.Refresh();
            mainListView.Focus();
        }
        
        private void SplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        { OnResize(); }
        
        private void MainForm_Resize(object sender, EventArgs e)
        { OnResize(); }


        private void mainListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            selectedLabel.Text = mainListView.CheckedItems.Count.ToString();
            if (!worker.IsBusy)
                EnableActionButtons(mainListView.CheckedItems.Count > 0);
        }


        private void FileLabel_Click(object sender, EventArgs e)
        {
            if (!fileLabel.Text.Equals(Strings.Empty))
                Process.Start(Data.Values.OpenList);
        }


        private void FolderLabel_Click(object sender, EventArgs e)
        {
            if (!folderLabel.Text.Equals(Strings.Empty))
                Process.Start(Data.Values.BrowsePath);
        }


        private void MainListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvColumnSorter.SortColumn)
            {
                if (lvColumnSorter.Order == SortOrder.Ascending) lvColumnSorter.Order = SortOrder.Descending;
                else lvColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                lvColumnSorter.SortColumn = e.Column;
                lvColumnSorter.Order = SortOrder.Ascending;
            }

            mainListView.Sort();
            mainListView.SetSortIcon(lvColumnSorter.SortColumn, lvColumnSorter.Order);
        }


        private void MainListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            /* prohibit checkBox Column change size */
            if (e.ColumnIndex == lvChk.Index)
            {
                e.Cancel = true;
                e.NewWidth = mainListView.Columns[lvChk.Index].Width;
            }
        }


        private void tabs_MouseDoubleClick(object sender, MouseEventArgs e)
        { ChangeLogWindowSize(); }


        private void tabs_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyData == Keys.Space) ChangeLogWindowSize(); }


        private void ChangeLogWindowSize()
        {
            /* make log window 1/4 of window */
            if (logSize == LogSize.Collapsed)
            {
                splitContainer.SplitterDistance = splitContainer.Height - (splitContainer.Height / 4);
                logSize = LogSize.Opened;
            }

            /* make log window collapsed */
            else if (logSize == LogSize.Expanded)
            {
                splitContainer.SplitterDistance = splitContainer.Height;
                logSize = LogSize.Collapsed;
            }

            /* make log window expanded */
            else
            {
                splitContainer.SplitterDistance = 25;
                logSize = LogSize.Expanded;
            }
        }
        /* --------------- END OF FORM AND CONTROLS --------------- */


        /* --------------- MAIN METHOD --------------- */
        private void ActionStart(object sender)
        {
            /* main action check */
            /* the difference between CopyTo and CopyIn will be set when creating the BackupList at the bottom of the code */
            if (sender == copyToBtn || sender == copyInBtn) pressedButton = PressedButton.CopyTo;
            if (sender == linkToBtn) pressedButton = PressedButton.LinkTo;
            if (sender == openListBtn) pressedButton = PressedButton.OpenList;

            /* preparing fields */
            Preparing();

            /* only OpenList button doesnt need to create BackupList */
            if (pressedButton != PressedButton.OpenList)
                CreateBackupList(sender);

            /* run action */
            worker.RunWorkerAsync();
        }
        /* --------------- END OF MAIN METHOD --------------- */


        /* --------------- BACKGROUND WORKER --------------- */
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            if (pressedButton == PressedButton.OpenList) Search(sender, e);
            else CopyAndLink(sender, e);
        }


        private void ProcessChanged(object sender, ProgressChangedEventArgs e)
        {
            if (pressedButton == PressedButton.OpenList) AppendFoundFile(sender, e);
            else UncheckSuccessfulItem(sender, e);
        }


        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (pressedButton == PressedButton.OpenList) SearchCompleted(sender, e);
            else CopyAndLinkCompleted(sender, e);

            FieldsFinally();
        }


        private void CancelBtn_Click(object sender, EventArgs e)
        { if (worker.IsBusy) worker.CancelAsync(); }
        /* --------------- END OF BACKGROUND WORKER --------------- */


        /* --------------- SEARCHING --------------- */
        private void Search(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker w = sender as BackgroundWorker;

            errorCount = 0;
            missingCount = 0;

            foreach (string searchFile in Data.Values.FilesToSearch)
            {
                /* stop process when pressed cancel */
                if (w.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }


                /* try/catch block need to avoid illegal characters in path error */
                try
                {
                    string searchFileName = Path.GetFileName(searchFile);

                    /* searching */
                    errorMessage = FileHelper.SearchFiles(searchFile);

                    if (errorMessage != null)
                    {
                        SetLog(
                            DateTime.Now.ToString(),
                            Strings.Error,
                            "[ " + errorMessage + " ] in [ " + searchFileName + " ]",
                            Color.Red,
                            FontStyle.Bold);

                        errorCount++;
                    }
                    else
                        if (Data.Values.FoundFiles.Count > 0)
                        {
                            /* append found files */
                            Parallel.ForEach(Data.Values.FoundFiles, foundFile =>
                                /* report worker to append found file */
                                w.ReportProgress(0, FileHelper.GenerateItem(searchFile, foundFile)));
                        }
                        else
                        {
                            SetLog(DateTime.Now.ToString(), Strings.NotFound, searchFileName, Color.Red, FontStyle.Regular);
                            missingCount++;
                        }
                }
                catch (Exception error)
                {
                    SetLog(
                        DateTime.Now.ToString(),
                        Strings.Error,
                        "[ " + error.Message + " ] in [ " + searchFile + " ]",
                        Color.Red,
                        FontStyle.Bold);

                    errorCount++;
                }

                /* grow progress bar */
                this.Invoke((MethodInvoker)
                    delegate { progressBar.Value++; });
            }
        }


        private void AppendFoundFile(object sender, ProgressChangedEventArgs e)
        {
            /* Append found file to list*/
            mainListView.Items.Add(new ListViewItem(e.UserState as string[])).Checked = true;

            /* select last item */
            mainListView.EnsureVisible(mainListView.Items.Count - 1);

            /* write amound of found files */
            foundLabel.Text = mainListView.Items.Count.ToString();

            /* increase or decrease columns depending items length */
            AlignMainListFields();
        }


        private void SearchCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /* writing cancel in log */
            if (e.Cancelled)
                SetLog(
                    DateTime.Now.ToString(),
                    Strings.SearchingCancel,
                    "Missing: " + missingCount + "  Errors: " + errorCount,
                    Color.Orange,
                    FontStyle.Bold);

            /* writing error in log */
            else if (e.Error != null)
                SetLog(
                    DateTime.Now.ToString(),
                    Strings.Error,
                    e.Error.Message,
                    Color.Red,
                    FontStyle.Bold);

            /* writing result in log */
            else
                SetLog(
                    DateTime.Now.ToString(),
                    Strings.SearchDone,
                    "Missing: " + missingCount + "  Errors: " + errorCount,
                    Color.Green,
                    FontStyle.Bold);
        }


        private void FindDublicates()
        {
            if (mainListView.Items.Count == 0)
                return;

            int dublicates = 0;
            string source;
            string compare;

            /* paint all elements on default color */
            foreach (ListViewItem item in mainListView.Items)
                item.BackColor = SystemColors.Window;

            for (int i = 0; i < mainListView.Items.Count - 1; i++)
            {
                source = mainListView.Items[i].SubItems[lvName.Index].Text;

                for (int j = i + 1; j < mainListView.Items.Count; j++)
                {
                    compare = mainListView.Items[j].SubItems[lvName.Index].Text;

                    if (source.ToLower() == compare.ToLower())
                    {
                        /* paint dublicates */
                        mainListView.Items[i].BackColor = Color.MistyRose;
                        mainListView.Items[j].BackColor = Color.MistyRose;
                        dublicates++;
                    }
                }
            }
            dublicatesLabel.Text = dublicates.ToString();
        }
        /* --------------- END OF SEARCHING --------------- */


        /* --------------- COPY AND LINK --------------- */
        private void CreateBackupList(object sender)
        {
            string sourceAddress;
            string destinationAddress;

            BackupList.Clear();

            foreach (ListViewItem item in mainListView.CheckedItems)
            {
                /* set the difference between CopyTo and CopyIn */
                if (sender == copyInBtn)
                {
                    sourceAddress =
                        FileHelper.GetSourceAddress(item.SubItems[lvName.Index].Text, Data.Values.CopyPath);

                    destinationAddress =
                        FileHelper.GetSourceAddress(item.SubItems[lvName.Index].Text, item.SubItems[lvPath.Index].Text);

                    /* always overwrite files when copying in... */
                    overwriteChb.Checked = true;
                }
                else
                {
                    sourceAddress =
                        FileHelper.GetSourceAddress(item.SubItems[lvName.Index].Text, item.SubItems[lvPath.Index].Text);

                    destinationAddress =
                        FileHelper.GetDestinationAddress(item.SubItems[lvName.Index].Text, item.SubItems[lvSubFolder.Index].Text);
                }

                BackupList.Add(new Data.BackupListItem(item.Index, sourceAddress, destinationAddress));
            }
        }


        private void CopyAndLink(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            doneCount = 0;

            foreach (Data.BackupListItem item in BackupList)
            {
                /* stop process when pressed cancel */
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                string logEvent = "";

                switch (pressedButton)
                {
                    case PressedButton.CopyTo:
                        errorMessage = FileHelper.CopyTo(item.sourceAddress, item.destinationAddress, overwriteChb.Checked);
                        logEvent = Strings.Copied;
                        break;

                    case PressedButton.LinkTo:
                        errorMessage = FileHelper.LinkTo(item.sourceAddress, item.destinationAddress, hardlinkRadio.Checked);
                        logEvent = Strings.Create;
                        break;
                }

                if (errorMessage != null)
                    SetLog(
                        DateTime.Now.ToString(),
                        Strings.Error,
                        "[ " + errorMessage + " ] in [ " + Path.GetFileName(item.sourceAddress) + " ]",
                        Color.Red,
                        FontStyle.Bold);
                else
                {
                    SetLog(DateTime.Now.ToString(), logEvent, Path.GetFileName(item.sourceAddress), Color.Blue, FontStyle.Regular);
                    doneCount++;

                    /* report worker to uncheck successful item */
                    worker.ReportProgress(item.index);
                }

                /* grow progress bar */
                this.Invoke((MethodInvoker)
                    delegate { progressBar.Value++; });
            }
        }


        private void UncheckSuccessfulItem(object sender, ProgressChangedEventArgs e)
        {
            /* show successful item for beauty */
            mainListView.EnsureVisible(e.ProgressPercentage);

            /* uncheck successful item */
            mainListView.Items[e.ProgressPercentage].Checked = false;
        }


        private void CopyAndLinkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string cancel = "";
            string done = "";

            switch (pressedButton)
            {
                case PressedButton.CopyTo:
                    cancel = Strings.CopyCancel;
                    done = Strings.CopyDone;
                    break;

                case PressedButton.LinkTo:
                    cancel = Strings.CreateCancel;
                    done = Strings.CreateDone;
                    break;
            }

            /* writing cancel in log */
            if (e.Cancelled)
                SetLog(
                    DateTime.Now.ToString(),
                    cancel,
                    doneCount + " of " + selectedCount + " selected files",
                    Color.Orange,
                    FontStyle.Bold);

                /* writing error in log */
            else if (e.Error != null)
                SetLog(
                    DateTime.Now.ToString(),
                    Strings.Error,
                    e.Error.Message,
                    Color.Red,
                    FontStyle.Bold);

            /* writing result in log */
            else
                SetLog(
                    DateTime.Now.ToString(),
                    done,
                    doneCount + " of " + selectedCount + " selected files",
                    Color.Green,
                    FontStyle.Bold);

            FieldsFinally();
        }
        /* --------------- END OF COPY AND LINK --------------- */


        /* --------------- FIELDS ACTIONS --------------- */
        private void AlignMainListFields()
        {
            mainListView.Columns[lvExt.Index].Width = -2;
            mainListView.Columns[lvName.Index].Width = -2;
            mainListView.Columns[lvPath.Index].Width = -2;
            mainListView.Columns[lvSubFolder.Index].Width = -2;
        }


        private void AlignLogListFields()
        {
            logListView.Columns[colTime.Index].Width = -2;
            logListView.Columns[colEvent.Index].Width = -2;
            logListView.Columns[ColMessage.Index].Width = -2;
        }


        private void EnableActionButtons(bool check)
        {
            linkGroup.Enabled = check;
            copyGroup.Enabled = check;
            copyInBtn.Enabled = check;
            saveListBtn.Enabled = check;
        }


        private void SetProgressBar(int maximum)
        {
            cancelBtn.Visible = true;
            cancelBtn.Focus();

            progressBar.Visible = true;
            progressBar.Maximum = maximum;
            progressBar.Value = 0;
        }


        private void Preparing()
        {
            /* Initially equal to the number of CheckedItems. */
            selectedCount = mainListView.CheckedItems.Count;
            int progressCount = selectedCount;

            if (pressedButton == PressedButton.OpenList)
            {
                /* load searching files */
                errorMessage = FileHelper.SetFilesToSearch();

                if (errorMessage != null)
                {
                    SetLog(DateTime.Now.ToString(), Strings.Error, errorMessage, Color.Red, FontStyle.Bold);
                    return;
                }

                /* fill in the fields from the getting data */
                progressCount = Data.Values.FilesToSearch.Count;
                inSearchCount += progressCount;
                inSearchLabel.Text = inSearchCount.ToString();
                fileLabel.Text = Path.GetFileName(Data.Values.OpenList);
                fileLabel.IsLink = true;
                folderLabel.Text = Data.Values.BrowsePath;
                folderLabel.IsLink = true;
            }

            /* hide close button in the corner of the window */
            ControlBox = false;

            /* set sort on checkboxes */
            MainListView_ColumnClick(lvChk, new ColumnClickEventArgs(lvChk.Index));
            mainListView.Enabled = false;

            SetProgressBar(progressCount);

            /* disable unnecessary buttons */
            EnableActionButtons(false);
            openListBtn.Enabled = false;
            clearFieldsBtn.Enabled = false;
        }


        private void FieldsFinally()
        {
            /* show close button in the corner of the window */
            ControlBox = true;

            /* enable buttons */
            openListBtn.Enabled = true;
            clearFieldsBtn.Enabled = true;
            EnableActionButtons(mainListView.CheckedItems.Count > 0);

            /* disable controls for the process */
            cancelBtn.Visible = false;
            progressBar.Visible = false;

            if (mainListView.Items.Count > 1)
            {
                /* enable list*/
                mainListView.Enabled = true;

                /*sort list by name */
                MainListView_ColumnClick(lvName, new ColumnClickEventArgs(lvName.Index));

                /* select first item */
                mainListView.EnsureVisible(0);

                /* list active and can scrolling */
                mainListView.Focus();
            }

            selectedLabel.Text = mainListView.CheckedItems.Count.ToString();

            FindDublicates();
            AlignMainListFields();
        }


        private void ClearFields(bool logAlso)
        {
            mainListView.Items.Clear();
            mainListView.Enabled = false;

            inSearchCount = 0;

            inSearchLabel.Text = Strings.Zero;
            foundLabel.Text = Strings.Zero;
            dublicatesLabel.Text = Strings.Zero;
            selectedLabel.Text = Strings.Zero;

            linkGroup.Enabled = false;
            copyGroup.Enabled = false;
            copyInBtn.Enabled = false;
            saveListBtn.Enabled = false;

            fileLabel.Text = Strings.Empty;
            fileLabel.IsLink = false;
            folderLabel.Text = Strings.Empty;
            folderLabel.IsLink = false;

            if (logAlso)
                logListView.Items.Clear();
            else
                SetLog(DateTime.Now.ToString(), "", Strings.ClearFields, Color.Blue, FontStyle.Regular);

            AlignMainListFields();
            AlignLogListFields();
        }
        /* --------------- END OF FIELDS ACTIONS --------------- */


        /* --------------- OPEN LIST BUTTON --------------- */
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            /* setup saved data to open dialog window */
            openDialog.InitialDirectory = Path.GetDirectoryName(Data.Values.OpenList);
            openDialog.FileName = Path.GetFileName(Data.Values.OpenList);
            browserDialog.SelectedPath = Data.Values.BrowsePath;

            /* open a file selection dialog winodw with a search list */
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Data.Values.OpenList = openDialog.FileName;
                SetLog(DateTime.Now.ToString(), Strings.OpenList, openDialog.FileName, Color.Black, FontStyle.Regular);

                /* open the search path selection dialog */
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    Data.Values.BrowsePath = browserDialog.SelectedPath;
                    SetLog(DateTime.Now.ToString(), Strings.Select, Data.Values.BrowsePath, Color.Black, FontStyle.Regular);

                    /* main action */
                    ActionStart(sender);
                    return;
                }
            }

            SetLog(DateTime.Now.ToString(), Strings.Cancel, "", Color.Blue, FontStyle.Regular);
        }
        /* --------------- END OF OPEN LIST BUTTON --------------- */


        /* --------------- SAVE LIST BUTTON --------------- */
        private void SaveListBtn_Click(object sender, EventArgs e)
        {
            /* setup saved data to open dialog window */
            saveDialog.InitialDirectory = Path.GetDirectoryName(Data.Values.SaveList);
            saveDialog.FileName = Path.GetFileNameWithoutExtension(Data.Values.SaveList);

            /* open a selection dialog window to save list */
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Data.Values.SaveList = saveDialog.FileName;

                /* main action */
                SaveList();
                return;
            }

            SetLog(DateTime.Now.ToString(), Strings.Cancel, "", Color.Blue, FontStyle.Regular);
        }


        private void SaveList()
        {
            List<string> list = new List<string>();

            /* creating list for save */
            foreach (ListViewItem item in mainListView.CheckedItems)
                list.Add(item.SubItems[lvPath.Index].Text + "\\" + item.SubItems[lvName.Index].Text);

            errorMessage = FileHelper.SaveList(list);

            if (errorMessage != null)
                SetLog(DateTime.Now.ToString(), Strings.Error, errorMessage, Color.Red, FontStyle.Bold);
            else
                SetLog(DateTime.Now.ToString(), Strings.SaveList, Data.Values.SaveList, Color.Black, FontStyle.Regular);
        }
        /* --------------- END OF SAVE LIST BUTTON --------------- */


        /* --------------- COPY / HARDLINK BUTTONS --------------- */
        private void CopyAndLinkBtn_Click(object sender, EventArgs e)
        {
            /* show warning when pressed CopyIn button */
            if (sender == copyInBtn)
                if (MessageBox.Show(
                    Strings.WarningCopyInText,
                    Strings.WarningCaption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

            browserDialog.SelectedPath = Data.Values.CopyPath;
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                Data.Values.CopyPath = browserDialog.SelectedPath;
                SetLog(DateTime.Now.ToString(), Strings.Select, Data.Values.CopyPath, Color.Black, FontStyle.Regular);

                /* main action */
                ActionStart(sender);
                return;
            }

            SetLog(DateTime.Now.ToString(), Strings.Cancel, "", Color.Blue, FontStyle.Regular);
        }
        /* --------------- END OF COPY / HARDLINK BUTTONS --------------- */


        /* --------------- CLEAR BUTTON --------------- */
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            /* ask about clearing events */
            DialogResult result =
                MessageBox.Show(Strings.ClearEventsQuestionText,
                Strings.QuestionCaption,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Cancel)
                ClearFields(result == DialogResult.Yes);
        }
        /* --------------- END OF CLEAR BUTTON --------------- */


        /* --------------- CONTEXT MENU --------------- */
        private void SelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in mainListView.Items)
                item.Selected = true;

            SetLog(DateTime.Now.ToString(), "", Strings.SelectAll, Color.Black, FontStyle.Regular);
        }


        private void DeselectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in mainListView.CheckedItems)
                item.Selected = false;

            SetLog(DateTime.Now.ToString(), "", Strings.DeselectAll, Color.Black, FontStyle.Regular);
        }


        private void InvertSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in mainListView.Items)
                if (item.Selected) item.Selected = false;
                else item.Selected = true;

            SetLog(DateTime.Now.ToString(), "", Strings.Invert, Color.Black, FontStyle.Regular);
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in mainListView.Items)
                if (item.Selected)
                {
                    item.Remove();
                    SetLog(DateTime.Now.ToString(), Strings.Delete, item.SubItems[lvName.Index].Text, Color.Orange, FontStyle.Regular);
                }

            foundLabel.Text = mainListView.Items.Count.ToString();
            selectedLabel.Text = mainListView.CheckedItems.Count.ToString();

            EnableActionButtons(mainListView.Items.Count > 0);
            FindDublicates();
        }


        private void LogMenuItemCopy_Click(object sender, EventArgs e)
        {
            string buffer = "";

            /* Append only messages */
            foreach (ListViewItem item in logListView.Items)
                if (item.Selected)
                    buffer += item.SubItems[ColMessage.Index].Text + "\n";

            if (!buffer.Equals(""))
            {
                Clipboard.Clear();
                Clipboard.SetText(buffer);
            }
        }


        private void LogList_KeyDown(object sender, KeyEventArgs e)
        {
            /* Ctrl + A = Select all */
            if (e.Control && e.KeyCode == Keys.A)
                foreach (ListViewItem item in logListView.Items)
                    item.Selected = true;

            /* Ctrl + Shift + A = Deselect all*/
            if (e.Control && e.Shift && e.KeyCode == Keys.A)
                foreach (ListViewItem item in logListView.Items)
                    item.Selected = false;

            /* Ctrl + C = Copy */
            if (e.KeyCode == Keys.C && e.Control)
                LogMenuItemCopy_Click(sender, e);
        }
        /* --------------- END OF CONTEXT MENU --------------- */


        private void Easter(object sender, EventArgs e)
        {
            easter++;
            if (easter == 10) copyInBtn.Visible = true;
        }
    }
}
