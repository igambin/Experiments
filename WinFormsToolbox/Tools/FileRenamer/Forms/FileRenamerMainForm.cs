using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinFormsToolbox.Forms;
using WinFormsToolbox.Tools.FileRenamer.Models;

namespace WinFormsToolbox.Tools.FileRenamer.Forms
{
    public partial class FileRenamerMainForm : Form
    {
        private static string cfgDirectory = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile), @".\IG-Tools\");

        private static string regexfile = Path.Combine(cfgDirectory, @"regex.cfg");

        List<MyFileInfo> files;
        BindingSource bs, bsc1, bsc2;

        List<string> patterns;
        List<string> replacements;

        string x1, x2;

        public FileRenamerMainForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(cfgDirectory)) 
                Directory.CreateDirectory(cfgDirectory);

            patterns = new List<string>();
            bsc1 = new BindingSource();
            bsc1.DataSource = patterns;
            comboBox1.DataSource = bsc1;

            replacements = new List<string>();
            bsc2 = new BindingSource();
            bsc2.DataSource = replacements;
            comboBox2.DataSource = bsc2;

            files = new List<MyFileInfo>();
            bs = new BindingSource();
            bs.DataSource = files;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].DataPropertyName = "oldfilename";
            dataGridView1.Columns[1].DataPropertyName = "newfilename";
            dataGridView1.Columns[0].HeaderText = "Actual Filename";
            dataGridView1.Columns[1].HeaderText = "Rename Preview";

            deserializeRegex();
            
        }

        private void updateFileInfo()
        {
            files.Clear();
            foreach (FileInfo f in new DirectoryInfo(textBox1.Text).GetFiles())
            {
                files.Add(new MyFileInfo(f));
            }
            EvaluateFilenamePreview();
            bs.ResetBindings(false);
        }

        private void EvaluateFilenamePreview()
        {
            try
            {
                Regex rex = new Regex(comboBox1.Text);
                if (!comboBox1.Text.Equals(string.Empty) && !comboBox2.Text.Equals(string.Empty) && files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        string x = files[i].oldfilename;
                        try
                        {
                            if (rex.IsMatch(x))
                            {
                                files[i].newfilename = rex.Replace(x, comboBox2.Text);
                            }
                            else
                            {
                                files[i].newfilename = files[i].oldfilename;
                            }
                            comboBox1.BackColor = System.Drawing.SystemColors.Window;
                        }
                        catch (Exception)
                        {
                            comboBox1.BackColor = System.Drawing.Color.MistyRose;
                        }
                    }
                    bs.ResetBindings(false);
                }
            }
            catch { }
        }

        private void chooseFolderClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                updateFileInfo();
            }
        }

        private void showPreviewClick(object sender, EventArgs e)
        {
            EvaluateFilenamePreview();
        }

        private void renameClick(object sender, EventArgs e)
        {
            button3.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            x1 = comboBox1.Text;
            x2 = comboBox2.Text;
            if (!patterns.Contains(x1))
                patterns.Add(x1);
            if (!replacements.Contains(x2))
                replacements.Add(x2);
            updateRegexBoxes();
            backgroundWorker1.RunWorkerAsync();
        }

        private void updateRegexBoxes()
        {
            serializeRegex();
            deserializeRegex();
        }

        private void serializeRegex() 
        {
            StreamWriter outs = new StreamWriter(regexfile, false);
            foreach (string s in patterns)
            {
                if(!s.Equals(string.Empty))
                    outs.WriteLine($"pattern:{s}");
            }
            foreach (string s in replacements)
            {
                if (!s.Equals(string.Empty))
                    outs.WriteLine($"replacement:{s}");
            }
            outs.Flush();
            outs.Close();
        }

        private void deserializeRegex()
        {
            if (!File.Exists(regexfile))
            {
                using (var file = File.CreateText(regexfile))
                {
                    file.WriteLine("pattern:(.*)");
                    file.WriteLine("replacement:${1}");
                    file.Flush();
                }
            }

            StreamReader ins = new StreamReader(regexfile);
            string line;
            patterns.Clear();
            replacements.Clear();
            while((line = ins.ReadLine()) != null ) {
                if (line.StartsWith("pattern:"))
                {
                    patterns.Add(line.Substring(8));
                }
                if (line.StartsWith("replacement:"))
                {
                    replacements.Add(line.Substring(12));
                }
            }
            ins.Close();
            bsc1.ResetBindings(false);
            bsc2.ResetBindings(false);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                foreach (MyFileInfo mfi in files)
                {
                    if (!mfi.newfilename.Equals(mfi.oldfilename))
                    {
                            mfi.Rename();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            updateFileInfo();
            bsc1.ResetBindings(false);
            bsc2.ResetBindings(false);

            button3.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void comboBox_KeyUp(object sender, KeyEventArgs e)
        {
            EvaluateFilenamePreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EvaluateFilenamePreview();
        }


        EditorForm editor;
        string editorListType;

        private void editPatternsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editorListType = "patterns";
            editor = new EditorForm("Edit Search-Patterns", patterns.ToArray());
            editor.CancelButtonClicked += new EventHandler(editor_CancelButtonClicked);
            editor.SaveButtonClicked += new EventHandler(editor_SaveButtonClicked);
            editor.ShowDialog();
        }

        void editor_SaveButtonClicked(object sender, EventArgs e)
        {
            string[] result = editor.tbContent.Lines;
            if (editorListType.Equals("patterns"))
            {
                patterns.Clear();
                patterns.AddRange(result);
                
            }
            else
            {
                replacements.Clear();
                replacements.AddRange(result);
            }
            updateRegexBoxes();
            editor.Close();
        }

        void editor_CancelButtonClicked(object sender, EventArgs e)
        {
            editor.Close();
        }

        private void editReplacementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editorListType = "replacements";
            editor = new EditorForm("Edit Replacement Patterns", replacements.ToArray());
            editor.CancelButtonClicked += new EventHandler(editor_CancelButtonClicked);
            editor.SaveButtonClicked += new EventHandler(editor_SaveButtonClicked);
            editor.ShowDialog();
        }

        private void lblAboutClick(object sender, EventArgs e)
        {
            MessageBox.Show(
                string.Format(
                        "Regex File Renamer\n\nAuthor: Ingo Gambin (C) {0}{1}"
                            + "\n\nSimple tool to facilitate mass-rename-actions to files"
                            + " within a directory using regular expressions.\n\nThis tool"
                            + " might be handy to unitise the names of a set of files. (E."
                            + " g. you have a set of .mp3, .png or .avi files and want to"
                            + " unify their non-unified name-style)."
                            + "\n\nRight-Click on the Pattern or Substitution DropDownLists"
                            + " to modify the accoding lists of stored search- or replacement"
                            + " patterns. On using a set of patterns (hit Rename), the"
                            + " according patterns will automatically be stored.",
                        2012, 
                        DateTime.Now.Year != 2012 ? " - " + DateTime.Now.Year.ToString() 
                                                  : ""
                        ),
                @"About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk
            );
        }
    }
}
