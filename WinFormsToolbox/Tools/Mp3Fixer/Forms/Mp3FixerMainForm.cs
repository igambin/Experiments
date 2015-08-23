using ConversionExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinFormsToolbox.Forms;
using WinFormsToolbox.Mp3Fixer.Models;

namespace WinFormsToolbox.Mp3Fixer.Forms
{
    public partial class Mp3FixerMainForm : Form
    {
        private static readonly string CfgDirectory = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile), @".\IG-Tools\");

        private static readonly string Regexfile = Path.Combine(CfgDirectory, @"mp3fixer.cfg");

        List<MyMp3FileInfo> _files;
        BindingSource _bs, _bsc1, _bsc2;

        List<string> _patterns;


        List<string> _columns = new List<string>
        {
            "FileName",
            "TrackName",
            "TrackNo",
            "TrackCount",
            "TrackPerformers",
            "AlbumName",
            "AlbumPerformers",
            "DiscNo",
            "DiscCount",
            "Conductor",
             "Composers",
             "Year",
             "Genres"
        }; 

        string _x1;

        Match _match;

        public Mp3FixerMainForm()
        {
            InitializeComponent();
        }


        private void Form_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(CfgDirectory))
            {
                Directory.CreateDirectory(CfgDirectory);
            }

            _bsc2 = new BindingSource { DataSource = _columns};
            cbInputColumnChooser.DataSource = _bsc2;

            _patterns = new List<string>();
            _bsc1 = new BindingSource {DataSource = _patterns};
            comboBox1.DataSource = _bsc1;

            _files = new List<MyMp3FileInfo>();
            _bs = new BindingSource {DataSource = _files};
            dataGridView1.DataSource = _bs;

            int i = 0;
            _columns.ForEach(
                col =>
                {
                    dataGridView1.Columns[i].DataPropertyName =
                    dataGridView1.Columns[i].HeaderText = col;
                    i++;
                });

            DeserializeRegex();
            
        }

        private void UpdateFileInfo()
        {
            _files.Clear();
            var found = 
                new DirectoryInfo(textBox1.Text)
                    .GetFiles()
                    .Where(x => x.Name.EndsWith(".mp3")).ToList();
            uint idx = 0;
            foreach (FileInfo f in found)
            {
                _files.Add(MyMp3FileInfo.Create(f, ++idx, (uint)found.Count()));
            }
            cbTrackCount.Text = _files.Count().ToString();
            var highestDiscNo = _files.Max(x => x.DiscNo);
            cbDiscCount.Text = (highestDiscNo < 1 ? 1 : highestDiscNo).ToString();
            _bs.ResetBindings(false);
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void CheckValue<TTarget, TMember>(
            TTarget target,
            string patternKey, 
            Expression<Func<TMember>> setterExpr,
            Expression<Action> resetterExpr = null,
            ComboBox tb = null) where TMember : IConvertible
        {
            MemberExpression member = setterExpr.Body as MemberExpression;
            MethodCallExpression resetter = resetterExpr?.Body as MethodCallExpression;

            GroupCollection groups = _match.Groups;

            TMember value = default(TMember);
            if(!string.IsNullOrWhiteSpace(tb?.Text))
            {
                value = tb.Text.GetTOrDefault<TMember>();
            }
            else if(!string.IsNullOrWhiteSpace(groups?[patternKey]?.Value))
            {
                value = groups[patternKey].Value.Trim().GetTOrDefault<TMember>();
            }
            else if(resetter != null) 
            {
                MethodInfo minfo = resetter.Method;
                minfo.Invoke(target, null);
                return;
            }

            (member?.Member as PropertyInfo)?.SetValue(target, value); ;
            
        }

        private void ChooseFolderClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                UpdateFileInfo();
            }
        }

        private void UpdateRegexBoxes()
        {
            SerializeRegex();
            DeserializeRegex();
        }

        private void SerializeRegex() 
        {
            StreamWriter outs = new StreamWriter(Regexfile, false);
            foreach (string s in _patterns)
            {
                if(!s.Equals(string.Empty))
                    outs.WriteLine(string.Format("pattern:{0}", s));
            }
            outs.Flush();
            outs.Close();
        }

        private void DeserializeRegex()
        {
            if (!File.Exists(Regexfile))
            {
                using (var file = File.CreateText(Regexfile))
                {
                    file.WriteLine("pattern:(.+)");
                    file.Flush();
                }
            }

            StreamReader ins = new StreamReader(Regexfile);
            string line;
            _patterns.Clear();
            while((line = ins.ReadLine()) != null ) {
                if (line.StartsWith("pattern:"))
                {
                    _patterns.Add(line.Substring(8));
                }
           }
            ins.Close();
            _bsc1.ResetBindings(false);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                foreach (MyMp3FileInfo mfi in _files)
                {
                    mfi.UpdateMp3Tag();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            UpdateFileInfo();
            _bsc1.ResetBindings(false);

            button3.Enabled = true;
            comboBox1.Enabled = true;
        }

        EditorForm _editor;
        string _editorListType;

        private void editPatternsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _editorListType = "patterns";
            _editor = new EditorForm("Edit Search-Patterns", _patterns.ToArray());
            _editor.CancelButtonClicked += new EventHandler(editor_CancelButtonClicked);
            _editor.SaveButtonClicked += new EventHandler(editor_SaveButtonClicked);
            _editor.ShowDialog();
        }

        private void editor_CancelButtonClicked(object sender, EventArgs e)
        {
            _editor.Close();
        }

        private void bInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"HilfeText...", @"Regex-Howto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Mp3FixerMainForm_Resize(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                _files.ForEach(x => x.SetFullPath());
            } else
            {
                _files.ForEach(x => x.SetShortName());
            }
            _bs.ResetBindings(false);
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void SetterButtonClick(object sender, EventArgs e)
        {
            try {
                var button = sender as Button;
                if (button != null)
                {
                    var propName = button.Name.Substring(4);
                    var comboBox = this.Controls.Find($"cb{propName}", true).First() as ComboBox;

                    var sourcePropertyName = cbInputColumnChooser.SelectedItem as string;


                    Type target = typeof(MyMp3FileInfo);

                    if (comboBox != null && sourcePropertyName != null)
                    {
                        if (string.IsNullOrWhiteSpace(comboBox.Text))
                        {
                            var methodResetter = target.GetMethod($"Reset{propName}");
                            _files.ForEach(x => methodResetter.Invoke(x, null));
                            return;
                        }

                        if (!string.IsNullOrWhiteSpace(comboBox1.Text))
                        {
                            var pattern = new Regex(comboBox1.Text);
                            var propSetter = target.GetProperty(propName);
                            var propGetter = target.GetProperty(sourcePropertyName);

                            foreach (var info in _files)
                            {
                                var input = propGetter.GetValue(info, null) as string ?? string.Empty;
                                _match = pattern.Match(input);
                                if (_match.Success && _match.Groups.Count > 1)
                                {
                                    var newValue = pattern.Replace(input, comboBox.Text);
                                    var newValueType = propSetter.PropertyType;
                                    propSetter.SetValue(info, Convert.ChangeType(newValue, newValueType));
                                }
                            }

                        }
                    }
                    _bs.ResetBindings(false);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, @"Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bResetTrackNo_Click(object sender, EventArgs e)
        {
            uint i = 1;

            foreach (var file in _files.OrderBy(x => x.FileName))
            {
                file.TrackNo = i++;
                file.TrackCount = (uint)_files.Count;
                file.DiscCount = 1;
                file.DiscNo = 1;
                
            }

            _bs.ResetBindings(false);
        }

        private void bResetTrackCount_Click(object sender, EventArgs e)
        {
            var discs = (from f in _files
                        orderby f.FileName
                        group f by f.DiscNo into g
                        select new { disc = g.Key, tracks = g }).ToList();

            foreach (var disc in discs)
            {
                uint i = 1;
                foreach (var track in disc.tracks)
                {
                    track.TrackNo = i++;
                    track.TrackCount = (uint)disc.tracks.Count();
                    track.DiscCount = (uint)discs.Count();
                }
            }

            _bs.ResetBindings(false);
        }

        private void bReplaceTrackArtists_Click(object sender, EventArgs e)
        {
            _files.ForEach(x => x.TrackArtists = x.AlbumArtists);
        }

        private void UpdateMp3Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            comboBox1.Enabled = false;
            _x1 = comboBox1.Text;
            if (!_patterns.Contains(_x1))
                _patterns.Add(_x1);
            UpdateRegexBoxes();
            backgroundWorker1.RunWorkerAsync();
        }

        void editor_SaveButtonClicked(object sender, EventArgs e)
        {
            string[] result = _editor.tbContent.Lines;
            if (_editorListType.Equals("patterns"))
            {
                _patterns.Clear();
                _patterns.AddRange(result);
                
            }
            UpdateRegexBoxes();
            _editor.Close();
        }

        private void LblAboutClick(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Mp3 Regex Tag Editor\n\nAuthor: Ingo Gambin (C) {2012}{(DateTime.Now.Year != 2012 ? " - " + DateTime.Now.Year.ToString() : "")} Simple tool to facilitate mass-edit-actions to mp3 tags within a directory using regular expressions.\n\nThis tool might be handy to unitise the album or disc information of mp3 files.",
                @"About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk
            );
        }
    }
}
