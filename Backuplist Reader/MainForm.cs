using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;

namespace Backuplist_Reader
{
    public partial class MainForm : Form
    {
        private RegistryHelper registry = new RegistryHelper();
        private ListViewColumnSorter lvColumnSorter = new ListViewColumnSorter();

        private List<string> filesToSearch = new List<string>();
        private List<string> foundFiles = new List<string>();

        private string browsePath, copyPath;
        private string openList, saveList;

        private int searchCount = 0;
        private int selectedCount = 0;


        public MainForm()
        { InitializeComponent(); }

        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);
        [DllImport("kernel32.dll")]
        static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

        /* --------------- FORM EVENTS --------------- */
        private void MainForm_Load(object sender, EventArgs e)
        {
            listClb.ListViewItemSorter = lvColumnSorter;

            // https://stackoverflow.com/questions/442817/c-sharp-flickering-listview-on-update
            listClb
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(listClb, true, null);

            logList
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(logList, true, null);

            openList = registry.loadPath(Strings.OpenList);
            saveList = registry.loadPath(Strings.SaveList);
            browsePath = registry.loadPath(Strings.BrowsePath);
            copyPath = registry.loadPath(Strings.CopyPath);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (openList != null) registry.savePath(Strings.OpenList, openList);
            if (saveList != null) registry.savePath(Strings.SaveList, saveList);
            if (browsePath != null) registry.savePath(Strings.BrowsePath, browsePath);
            if (copyPath != null) registry.savePath(Strings.CopyPath, copyPath);
        }
        /* --------------- END OF FORM EVENTS --------------- */

        /* --------------- CONTEXT MENU EVENTS --------------- */
        private void SelectAllTstb_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listClb.Items)
                item.Selected = true;
            SetLog(DateTime.Now.ToString(), "", Strings.SelectAll, Color.Black, FontStyle.Regular);
        }

        private void DeselectAllTstb_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listClb.Items)
                item.Selected = false;
            SetLog(DateTime.Now.ToString(), "", Strings.DeselectAll, Color.Black, FontStyle.Regular);
        }

        private void InvertSelectionTstb_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listClb.Items)
                if (item.Selected) item.Selected = false;
                else item.Selected = true;
            SetLog(DateTime.Now.ToString(), "", Strings.Invert, Color.Black, FontStyle.Regular);
        }
        /* --------------- END OF CONTEXT MENU EVENTS --------------- */

        /* --------------- LOG --------------- */
        private void SetLog(string time, string type, string message, Color color, FontStyle fontStyle)
        {
            ListViewItem logItem = new ListViewItem(new string[] { time, type, message });
            logItem.Font = new Font(logItem.Font, fontStyle);
            logItem.ForeColor = color;

            logList.Items.Add(logItem);

            logList.Columns[colTime.Index].Width = -2;
            logList.Columns[colEvent.Index].Width = -2;
            logList.Columns[ColMessage.Index].Width = -2;
            logList.EnsureVisible(logList.Items.Count - 1);
        }

        private void SetProgressBar(int maximum)
        {
            progressBar.Visible = true;
            progressBar.Maximum = maximum;
            progressBar.Value = 0;
        }


        /* --------------- FIELDS ACTIONS --------------- */
        private void FieldsPrepare(string fileToSearch)
        {
            listClb_ColumnClick(lvChk, new ColumnClickEventArgs(lvChk.Index));
            listClb.Enabled = true;
            SetFilesToSearch(fileToSearch);
            SetProgressBar(filesToSearch.Count);
            searchCount += filesToSearch.Count;
            searchLabel.Text = searchCount.ToString();
            fnameLabel.Text = Path.GetFileName(openList);
            fnameLabel.IsLink = true;
            folderLabel.Text = browsePath;
            folderLabel.IsLink = true;
        }

        private void FieldsRefresh()
        {
            foundLabel.Text = listClb.Items.Count.ToString();
            if (listClb.Items.Count > 1) listClb.EnsureVisible(listClb.Items.Count - 1);
            listClb.Columns[lvName.Index].Width = -2;
            listClb.Columns[lvPath.Index].Width = -2;

            progressBar.Value++;
            progressBar.Refresh();
            statusStrip.Refresh();
        }

        private void FieldsFinally()
        {
            if (listClb.Items.Count > 0) listClb.EnsureVisible(0);
            listClb_ColumnClick(lvName, new ColumnClickEventArgs(lvName.Index));

            selectedLabel.Text = selectedCount.ToString();
            progressBar.Visible = false;
        }

        private void FieldsClear(bool logAlso)
        {
            filesToSearch.Clear();
            foundFiles.Clear();

            listClb.Items.Clear();
            listClb.Enabled = false;

            searchCount = 0;
            selectedCount = 0;

            searchLabel.Text = searchCount.ToString();
            foundLabel.Text = foundFiles.Count.ToString();
            selectedLabel.Text = searchCount.ToString();

            linkGroup.Enabled = false;
            copyGroup.Enabled = false;
            copyInBtn.Enabled = false;
            saveBtn.Enabled = false;

            fnameLabel.Text = Strings.Empty;
            fnameLabel.IsLink = false;
            folderLabel.Text = Strings.Empty;
            folderLabel.IsLink = false;

            if (logAlso)
                logList.Items.Clear();
            else
                SetLog(DateTime.Now.ToString(), "", Strings.ClearFields, Color.Blue, FontStyle.Regular);
        }
        /* --------------- END OF FIELDS ACTIONS --------------- */


        private void SetFilesToSearch(string fileName)
        {
            filesToSearch.Clear();
            string line;
            StreamReader file = new StreamReader(fileName, System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
                if (line.Length > 1) filesToSearch.Add(line);
            file.Close();
        }


        private bool IsFileFound(string searchFile)
        {
            bool isFound = false;

            foreach (string file in foundFiles)
                if (searchFile.Equals(Path.GetFileName(file)))
                {
                    isFound = true;
                    break;
                }

            return isFound;
        }


        private void Search()
        {
            int errorCount = 0;
            int missingCount = 0;

            foreach (string file in filesToSearch)
            {
                try
                {
                    foundFiles.Clear();
                    foundFiles.AddRange(Directory.GetFiles(browsePath, file, SearchOption.AllDirectories));
                    foreach (string item in foundFiles)
                        listClb.Items.Add(new ListViewItem(new string[] { "", Path.GetFileName(item), Path.GetDirectoryName(item) })).Checked = true;
                }
                catch (Exception exeption)
                {
                    SetLog(DateTime.Now.ToString(), Strings.Error, "[ " + exeption.Message + " ] in [ " + file + " ]", Color.Red, FontStyle.Bold);
                    errorCount++;
                    continue;
                }

                if (!IsFileFound(file))
                {
                    SetLog(DateTime.Now.ToString(), Strings.NotFound, file, Color.Red, FontStyle.Regular);
                    missingCount++;
                }

                FieldsRefresh();
            }
            SetLog(DateTime.Now.ToString(), Strings.DoneSearch, "Missing: " + missingCount + "  Errors: " + errorCount, Color.Green, FontStyle.Bold);
        }


        /* --------------- OPEN / SAVE BUTTONS EVENTS --------------- */
        private void openBtn_Click(object sender, EventArgs e)
        {
            openDialog.InitialDirectory = Path.GetDirectoryName(openList);
            openDialog.FileName = Path.GetFileName(openList);
            browserDialog.SelectedPath = browsePath;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                openList = openDialog.FileName;
                SetLog(DateTime.Now.ToString(), Strings.OpenList, openDialog.FileName, Color.Black, FontStyle.Regular);

                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    browsePath = browserDialog.SelectedPath;
                    SetLog(DateTime.Now.ToString(), Strings.Select, browsePath, Color.Black, FontStyle.Regular);

                    FieldsPrepare(openDialog.FileName);
                    Search(); // main method
                    FieldsFinally();
                }
                else
                    SetLog(DateTime.Now.ToString(), Strings.Cancel, "", Color.Blue, FontStyle.Regular);
            }
            else
                SetLog(DateTime.Now.ToString(), Strings.Cancel, "", Color.Blue, FontStyle.Regular);
        }



        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveDialog.InitialDirectory = Path.GetDirectoryName(saveList);
            saveDialog.FileName = Path.GetFileNameWithoutExtension(saveList);

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                saveList = saveDialog.FileName;

                StreamWriter file = new StreamWriter(saveDialog.FileName, false, System.Text.Encoding.Default);
                foreach (ListViewItem item in listClb.Items)
                    if (item.Checked)
                        file.WriteLine(item.SubItems[lvPath.Index].Text + "\\" + item.SubItems[lvName.Index].Text);

                file.Close();

                SetLog(DateTime.Now.ToString(), Strings.SaveList, saveDialog.FileName, Color.Black, FontStyle.Regular);
            }
            else
                SetLog(DateTime.Now.ToString(), Strings.Cancel, "", Color.Blue, FontStyle.Regular);

        }
        /* --------------- END OF OPEN / SAVE BUTTONS EVENTS --------------- */

        /* --------------- COPY / HARDLINK BUTTONS EVENTS --------------- */
        private void copyBtn_Click(object sender, EventArgs e)
        {
            browserDialog.SelectedPath = copyPath;
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                copyPath = browserDialog.SelectedPath;
                SetProgressBar(listClb.Items.Count);
                SetLog(DateTime.Now.ToString(), Strings.Select, browserDialog.SelectedPath, Color.Black, FontStyle.Regular);

                int doneCount = 0;
                foreach (ListViewItem item in listClb.Items)
                {
                    if (item.Checked)
                    {
                        string sourceFileName = item.SubItems[lvPath.Index].Text + "\\" + item.SubItems[lvName.Index].Text;
                        string destFileName = browserDialog.SelectedPath + "\\" + item.SubItems[lvName.Index].Text;

                        if (sender == copyBtn)
                            try
                            {
                                File.Copy(sourceFileName, destFileName, chBoxOverwrite.Checked);
                                SetLog(DateTime.Now.ToString(), Strings.Copy, item.SubItems[lvName.Index].Text, Color.Blue, FontStyle.Regular);
                                doneCount++;
                            }
                            catch (Exception exeption)
                            { SetLog(DateTime.Now.ToString(), Strings.Error, exeption.Message, Color.Red, FontStyle.Bold); }

                        if (sender == linkBtn)
                        {
                            bool ok = false;
                            switch (rbHlink.Checked)
                            {
                                case true:
                                    if (CreateHardLink(destFileName, sourceFileName, IntPtr.Zero)) ok = true;
                                    break;
                                case false:
                                    if (CreateSymbolicLink(destFileName, sourceFileName, 0)) ok = true;
                                    break;
                            }

                            if (ok)
                            {
                                doneCount++;
                                SetLog(DateTime.Now.ToString(), Strings.Create, item.SubItems[lvName.Index].Text, Color.Blue, FontStyle.Regular);
                            }
                            else
                                SetLog(DateTime.Now.ToString(), Strings.Error, item.SubItems[lvName.Index].Text, Color.Red, FontStyle.Bold);
                        }

                        progressBar.Value++;
                        item.Checked = false;
                    }
                }
                if (sender == copyBtn)
                    SetLog(DateTime.Now.ToString(), Strings.DoneCopy, doneCount + " of " + listClb.Items.Count + " files", Color.Green, FontStyle.Bold);

                if (sender == linkBtn)
                    SetLog(DateTime.Now.ToString(), Strings.DoneCreate, doneCount + " of " + listClb.Items.Count + " files", Color.Green, FontStyle.Bold);
            }
            else
                SetLog(DateTime.Now.ToString(), Strings.Cancel, "", Color.Blue, FontStyle.Regular);

            progressBar.Visible = false;
        }
        /* --------------- END OF COPY / HARDLINK BUTTONS EVENTS --------------- */

        /* --------------- COPYIN BUTTON EVENT --------------- */
        private void copyInBtn_Click(object sender, EventArgs e)
        {

            browserDialog.SelectedPath = copyPath;
            if (MessageBox.Show
                (Strings.WarningText,
                Strings.WarningCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    SetProgressBar(listClb.Items.Count);
                    int doneCount = 0;

                    foreach (ListViewItem item in listClb.Items)
                    {
                        if (item.Checked)
                            try
                            {
                                string sourceFileName = browserDialog.SelectedPath + "\\" + item.SubItems[lvName.Index];
                                string destFileName = item.SubItems[lvPath.Index] + "\\" + item.SubItems[lvName.Index];

                                File.Copy(sourceFileName, destFileName, true);

                                SetLog(DateTime.Now.ToString(), Strings.Copy + " In", item.SubItems[lvName.Index].Text, Color.Blue, FontStyle.Regular);
                                item.Checked = false;
                                doneCount++;
                            }
                            catch (Exception eCopyIn)
                            { SetLog(DateTime.Now.ToString(), Strings.Error, eCopyIn.Message, Color.Red, FontStyle.Bold); }

                        progressBar.Value++;
                    }
                    SetLog(DateTime.Now.ToString(), Strings.DoneCopy, doneCount + " of " + listClb.Items.Count + " files", Color.Green, FontStyle.Bold);
                }
                else
                    SetLog(DateTime.Now.ToString(), Strings.Cancel, "", Color.Blue, FontStyle.Regular);

            progressBar.Visible = false;
        }
        /* --------------- END OF COPYIN BUTTON EVENT --------------- */

        /* --------------- CLEAR BUTTON EVENT --------------- */
        private void clearBtn_Click(object sender, EventArgs e)
        {
            FieldsClear(
                (MessageBox.Show
                (Strings.QuestionText,
                Strings.QuestionCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes));
        }
        /* --------------- END OF CLEAR BUTTON EVENT --------------- */

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            logList.Refresh();
            listClb.Focus();
        }

        private void listClb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (listClb.Items[e.Index].Checked)
                selectedCount--;
            else
                selectedCount++;

            selectedLabel.Text = selectedCount.ToString();

            if (selectedCount == 0)
            {
                linkGroup.Enabled = false;
                copyGroup.Enabled = false;
                copyInBtn.Enabled = false;
                saveBtn.Enabled = false;
            }
            else
            {
                linkGroup.Enabled = true;
                copyGroup.Enabled = true;
                copyInBtn.Enabled = true;
                saveBtn.Enabled = true;
            }
        }

        private void fnameLabel_Click(object sender, EventArgs e)
        {
            if (!fnameLabel.Text.Equals(Strings.Empty))
                Process.Start(openList);
        }

        private void folderLabel_Click(object sender, EventArgs e)
        {
            if (!folderLabel.Text.Equals(Strings.Empty))
                Process.Start(browsePath);
        }

        private void listClb_ColumnClick(object sender, ColumnClickEventArgs e)
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

            listClb.Sort();
            listClb.SetSortIcon(lvColumnSorter.SortColumn, lvColumnSorter.Order);
        }

        private void listClb_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Cancel = true;
                e.NewWidth = listClb.Columns[lvChk.Index].Width;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string buffer = "";
            foreach (ListViewItem item in logList.Items)
                if (item.Selected)
                    buffer += item.SubItems[ColMessage.Index].Text + "\n";

            Clipboard.Clear();
            Clipboard.SetText(buffer);
        }

        private void logList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                foreach (ListViewItem item in logList.Items)
                    item.Selected = true;

            if (e.Control && e.Shift && e.KeyCode == Keys.A)
                foreach (ListViewItem item in logList.Items)
                    item.Selected = false;

            if (e.KeyCode == Keys.C && e.Control)
                copyToolStripMenuItem_Click(sender, e);
        }
    }
}
