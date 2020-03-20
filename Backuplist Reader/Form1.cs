using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;

namespace Backuplist_Reader
{
    public partial class Form1 : Form
    {
        private int selectedCount = 0;
        private string log;
        private string openPath, browsePath, copyPath;
        private List<string> filesToSearch = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void setFilesToSearch(string fileName)
        {
            filesToSearch.Clear();

            string line;
            StreamReader file = new StreamReader(fileName);

            while ((line = file.ReadLine()) != null)
                filesToSearch.Add(line);

            file.Close();
        }

        private void fillFields(string searhPath)
        {
            listClb.Items.Clear();
            selectedCount = 0;
            setProgressBar(filesToSearch.Count);

            foreach (string file in filesToSearch)
            {
                listClb.Items.AddRange(Directory.GetFiles(searhPath, file, SearchOption.AllDirectories));

                foundLabel.Text = Convert.ToString(listClb.Items.Count);

                progressBar.Value++;
                progressBar.Refresh();

                listClb.Refresh();
                statusStrip1.Refresh();
            }

            for (int i = 0; i < filesToSearch.Count; i++)
            {
                bool b = false;
                for (int j = 0; j < listClb.Items.Count; j++)
                    if (filesToSearch[i] == Path.GetFileName(listClb.GetItemText(listClb.Items[j])))
                    {
                        b = true;
                        break;
                    }

                if (!b)
                {
                    log = DateTime.Now + ": NOT FOUND " + filesToSearch[i] + "\n";
                    setLog(log, Color.Red);
                }
            }

            for (int i = 0; i < listClb.Items.Count; i++)
                listClb.SetItemChecked(i, true);

            log = DateTime.Now + ": Done.\n\n";
            setLog(log, Color.Green);

            progressBar.Visible = false;
            hardlinkBtn.Enabled = true;
            copyBtn.Enabled = true;
            copyInBtn.Enabled = true;
            saveBtn.Enabled = true;
        }

        private void setLog(string logString, Color color)
        {
            logRtb.AppendText(logString);
            int i = 0;
            while (i <= logRtb.Text.Length - logString.Length)
            {
                i = logRtb.Text.IndexOf(logString, i);
                if (i < 0) break;
                logRtb.SelectionStart = i;
                logRtb.SelectionLength = logString.Length;
                logRtb.SelectionColor = color;
                i += logString.Length;
            }
            logRtb.SelectionStart = logRtb.Text.Length;
            logRtb.ScrollToCaret();
            logRtb.Refresh();
        }

        private void setProgressBar(int maximum)
        {
            progressBar.Visible = true;
            progressBar.Maximum = maximum;
            progressBar.Value = 0;
        }

        /* --------------- CONTEXT MENU EVENTS --------------- */
        private void selectAllTstb_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listClb.Items.Count; i++)
                listClb.SetItemChecked(i, true);
            setLog(DateTime.Now + ": Select All\n", Color.Black);
        }

        private void deselectAllTstb_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listClb.Items.Count; i++)
                listClb.SetItemChecked(i, false);
            setLog(DateTime.Now + ": Deselect All\n", Color.Black);
        }

        private void invertSelectionTstb_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listClb.Items.Count; i++)
                if (listClb.GetItemChecked(i))
                    listClb.SetItemChecked(i, false);
                else
                    listClb.SetItemChecked(i, true);
            setLog(DateTime.Now + ": Invert Selection\n", Color.Black);
        }
        /* --------------- END OF CONTEXT MENU EVENTS --------------- */

        /* --------------- OPEN / SAVE BUTTONS EVENTS --------------- */
        private void openBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = openPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                log = DateTime.Now + ": Open file: " + openFileDialog1.FileName + "\n";
                setLog(log, Color.Black);

                openPath = openFileDialog1.FileName;

                folderBrowserDialog1.SelectedPath = browsePath;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    log = DateTime.Now + ": Select folder: " + folderBrowserDialog1.SelectedPath + "\n";
                    setLog(log, Color.Black);

                    setFilesToSearch(openFileDialog1.FileName);

                    itemsLabel.Text = Convert.ToString(filesToSearch.Count);
                    fnameLabel.Text = Path.GetFileName(openFileDialog1.FileName);
                    fnameLabel.IsLink = true;
                    folderLabel.Text = folderBrowserDialog1.SelectedPath;
                    folderLabel.IsLink = true;

                    fillFields(folderBrowserDialog1.SelectedPath);
                }
                else
                {
                    log = DateTime.Now + ": Cancel selecting folder\n";
                    setLog(log, Color.Blue);
                }
            }
            else
            {
                log = DateTime.Now + ": Cancel opening file\n";
                setLog(log, Color.Blue);
            }
            browsePath = folderBrowserDialog1.SelectedPath;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                log = DateTime.Now + ": List saved in " + saveFileDialog1.FileName + "\n";
                setLog(log, Color.Black);

                StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < listClb.Items.Count; i++)
                    file.Write(listClb.GetItemText(listClb.Items[i]) + "\n");

                file.Close();
            }
            else
            {
                log = DateTime.Now + ": Cancel saving list\n";
                setLog(log, Color.Blue);
            }
        }
        /* --------------- END OF OPEN / SAVE BUTTONS EVENTS --------------- */

        /* --------------- COPY / HARDLINK BUTTONS EVENTS --------------- */
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

        private void copyBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = copyPath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (sender == copyBtn)
                    log = DateTime.Now + ": Selected folder to copy " + folderBrowserDialog1.SelectedPath + "\n";
                else
                    if (sender == hardlinkBtn)
                        log = DateTime.Now + ": Selected folder to create hardlinks '" + folderBrowserDialog1.SelectedPath + "'\n";

                setLog(log, Color.Black);

                setProgressBar(listClb.Items.Count);
                int doneCount = 0;
                for (int i = 0; i < listClb.Items.Count; i++)
                {
                    if (listClb.GetItemCheckState(i) == CheckState.Checked)
                        try
                        {
                            string sourceFileName = listClb.GetItemText(listClb.Items[i]);
                            string destFileName = folderBrowserDialog1.SelectedPath + "\\" + Path.GetFileName(listClb.GetItemText(listClb.Items[i]));

                            if (sender == copyBtn)
                                File.Copy(sourceFileName, destFileName, false);
                            else
                                if (sender == hardlinkBtn)
                                    CreateHardLink(destFileName, sourceFileName, IntPtr.Zero);

                            listClb.SetItemChecked(i, false);

                            if (sender == copyBtn)
                                log = DateTime.Now + ": Copied: " + Path.GetFileName(listClb.GetItemText(listClb.Items[i])) + "\n";
                            else
                                if (sender == hardlinkBtn)
                                    log = DateTime.Now + ": HardLink created: " + Path.GetFileName(listClb.GetItemText(listClb.Items[i])) + "\n";

                            setLog(log, Color.Blue);

                            doneCount++;
                        }
                        catch (Exception eCopyTo)
                        {
                            log = DateTime.Now + ": Error: " + eCopyTo.Message + "\n";
                            setLog(log, Color.Red);
                        }
                    progressBar.Value++;
                }

                if (sender == copyBtn)
                    log = DateTime.Now + ": Copy Done " + doneCount + " of " + listClb.Items.Count + " files\n\n";
                else
                    if (sender == hardlinkBtn)
                        log = DateTime.Now + ": Creating Done " + doneCount + " of " + listClb.Items.Count + " files\n\n";

                setLog(log, Color.Green);

                copyPath = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                if (sender == copyBtn)
                    log = DateTime.Now + ": Copy canceled\n";
                else
                    if (sender == hardlinkBtn)
                        log = DateTime.Now + ": Creating canceled\n";

                setLog(log, Color.Blue);
            }
            progressBar.Visible = false;
        }
        /* --------------- END OF COPY / HARDLINK BUTTONS EVENTS --------------- */

        /* --------------- COPYIN BUTTON EVENT --------------- */
        private void copyInBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = copyPath;
            if (MessageBox.Show("Are you sure you want this?", "VIN: Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    setProgressBar(listClb.Items.Count);
                    int doneCount = 0;

                    for (int i = 0; i < listClb.Items.Count; i++)
                    {
                        try
                        {
                            string sourceFileName = folderBrowserDialog1.SelectedPath + "\\" + Path.GetFileName(listClb.GetItemText(listClb.Items[i]));
                            string destFileName = listClb.GetItemText(listClb.Items[i]);

                            File.Copy(sourceFileName, destFileName, true);

                            listClb.SetItemChecked(i, false);

                            log = DateTime.Now + ": Copied: " + Path.GetFileName(listClb.GetItemText(listClb.Items[i])) + "\n";
                            setLog(log, Color.Blue);

                            doneCount++;
                        }
                        catch (Exception eCopyIn)
                        {
                            log = DateTime.Now + ": Error: " + eCopyIn.Message + "\n";
                            setLog(log, Color.Red);
                        }
                        progressBar.Value++;
                    }
                    log = DateTime.Now + ": Copy Done " + doneCount + " of " + listClb.Items.Count + " files\n\n";
                    setLog(log, Color.Green);
                }
                else
                {
                    log = DateTime.Now + ": CopyIn canceled\n";
                    setLog(log, Color.Blue);
                }
            progressBar.Visible = false;
        }
        /* --------------- END OF COPYIN BUTTON EVENT --------------- */

        /* --------------- CLEAR BUTTON EVENT --------------- */
        private void clearBtn_Click(object sender, EventArgs e)
        {
            listClb.Items.Clear();
            selectedLabel.Text = "0";
            fnameLabel.Text = "(empty)";
            fnameLabel.IsLink = false;
            folderLabel.Text = "(empty)";
            folderLabel.IsLink = false;
            itemsLabel.Text = "0";
            foundLabel.Text = "0";
            statusStrip1.Refresh();

            hardlinkBtn.Enabled = false;
            copyBtn.Enabled = false;
            copyInBtn.Enabled = false;
            saveBtn.Enabled = false;

            log = DateTime.Now + ": Fields is clear\n";
            setLog(log, Color.Blue);

            if (MessageBox.Show("Do you want clear Events too?", "VIN: Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                logRtb.Clear();
        }
        /* --------------- END OF CLEAR BUTTON EVENT --------------- */

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            listClb.Focus();
        }

        private void listClb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (listClb.GetItemChecked(e.Index))
                selectedCount--;
            else
                selectedCount++;

            selectedLabel.Text = Convert.ToString(selectedCount);
        }

        private void fnameLabel_Click(object sender, EventArgs e)
        {
            if (!fnameLabel.Text.Equals("(empty)"))
                Process.Start(openPath);
        }

        private void folderLabel_Click(object sender, EventArgs e)
        {
            if (!folderLabel.Text.Equals("(empty)"))
                Process.Start(browsePath);
        }
    }
}
