namespace WinFormsToolbox.Mp3Fixer.Forms
{
    partial class Mp3FixerMainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editPatternsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblAbout = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tcDataInput = new System.Windows.Forms.TabControl();
            this.tpAlbum = new System.Windows.Forms.TabPage();
            this.bSetConductor = new System.Windows.Forms.Button();
            this.cbConductor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbDiscCount = new System.Windows.Forms.ComboBox();
            this.bSetDiscCount = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDiscNo = new System.Windows.Forms.ComboBox();
            this.bSetDiscNo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bSetYear = new System.Windows.Forms.Button();
            this.bSetAlbumArtists = new System.Windows.Forms.Button();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.cbAlbumArtists = new System.Windows.Forms.ComboBox();
            this.cbAlbumName = new System.Windows.Forms.ComboBox();
            this.bSetAlbumName = new System.Windows.Forms.Button();
            this.tpTrack = new System.Windows.Forms.TabPage();
            this.bSetComposers = new System.Windows.Forms.Button();
            this.cbComposers = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.bSetGenres = new System.Windows.Forms.Button();
            this.cbGenres = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTrackArtists = new System.Windows.Forms.ComboBox();
            this.cbTrackName = new System.Windows.Forms.ComboBox();
            this.bSetTrackArtists = new System.Windows.Forms.Button();
            this.bSetTrackName = new System.Windows.Forms.Button();
            this.cbTrackCount = new System.Windows.Forms.ComboBox();
            this.bSetTrackCount = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cbTrackNo = new System.Windows.Forms.ComboBox();
            this.bSetTrackNo = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bReplaceTrackArtists = new System.Windows.Forms.Button();
            this.bResetTrackCount = new System.Windows.Forms.Button();
            this.bResetTrackNo = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbInputColumnChooser = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tcDataInput.SuspendLayout();
            this.tpAlbum.SuspendLayout();
            this.tpTrack.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Directory";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(103, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(532, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::WinFormsToolbox.WinFormsResources.folder1;
            this.button1.Location = new System.Drawing.Point(641, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChooseFolderClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Regex-Pattern";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Album Title";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkRed;
            this.button3.Location = new System.Drawing.Point(544, 426);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Update Mp3-Tags";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.UpdateMp3Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(660, 154);
            this.dataGridView1.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(99, 225);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(517, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPatternsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 26);
            // 
            // editPatternsToolStripMenuItem
            // 
            this.editPatternsToolStripMenuItem.Name = "editPatternsToolStripMenuItem";
            this.editPatternsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.editPatternsToolStripMenuItem.Text = "Edit Patterns";
            this.editPatternsToolStripMenuItem.Click += new System.EventHandler(this.editPatternsToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblAbout
            // 
            this.lblAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbout.AutoSize = true;
            this.lblAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblAbout.Location = new System.Drawing.Point(-2, 450);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(28, 12);
            this.lblAbout.TabIndex = 9;
            this.lblAbout.Text = "about";
            this.lblAbout.Click += new System.EventHandler(this.LblAboutClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Album Artists";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Year";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tcDataInput
            // 
            this.tcDataInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcDataInput.Controls.Add(this.tpAlbum);
            this.tcDataInput.Controls.Add(this.tpTrack);
            this.tcDataInput.Controls.Add(this.tabPage1);
            this.tcDataInput.Location = new System.Drawing.Point(12, 252);
            this.tcDataInput.Name = "tcDataInput";
            this.tcDataInput.SelectedIndex = 0;
            this.tcDataInput.Size = new System.Drawing.Size(660, 168);
            this.tcDataInput.TabIndex = 29;
            // 
            // tpAlbum
            // 
            this.tpAlbum.Controls.Add(this.bSetConductor);
            this.tpAlbum.Controls.Add(this.cbConductor);
            this.tpAlbum.Controls.Add(this.label9);
            this.tpAlbum.Controls.Add(this.cbDiscCount);
            this.tpAlbum.Controls.Add(this.bSetDiscCount);
            this.tpAlbum.Controls.Add(this.label5);
            this.tpAlbum.Controls.Add(this.cbDiscNo);
            this.tpAlbum.Controls.Add(this.bSetDiscNo);
            this.tpAlbum.Controls.Add(this.label7);
            this.tpAlbum.Controls.Add(this.bSetYear);
            this.tpAlbum.Controls.Add(this.bSetAlbumArtists);
            this.tpAlbum.Controls.Add(this.cbYear);
            this.tpAlbum.Controls.Add(this.cbAlbumArtists);
            this.tpAlbum.Controls.Add(this.cbAlbumName);
            this.tpAlbum.Controls.Add(this.bSetAlbumName);
            this.tpAlbum.Controls.Add(this.label3);
            this.tpAlbum.Controls.Add(this.label4);
            this.tpAlbum.Controls.Add(this.label6);
            this.tpAlbum.Location = new System.Drawing.Point(4, 22);
            this.tpAlbum.Name = "tpAlbum";
            this.tpAlbum.Padding = new System.Windows.Forms.Padding(3);
            this.tpAlbum.Size = new System.Drawing.Size(652, 142);
            this.tpAlbum.TabIndex = 0;
            this.tpAlbum.Text = "Album/Disc Information";
            this.tpAlbum.UseVisualStyleBackColor = true;
            // 
            // bSetConductor
            // 
            this.bSetConductor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetConductor.Location = new System.Drawing.Point(606, 60);
            this.bSetConductor.Name = "bSetConductor";
            this.bSetConductor.Size = new System.Drawing.Size(40, 21);
            this.bSetConductor.TabIndex = 59;
            this.bSetConductor.Text = "set";
            this.bSetConductor.UseVisualStyleBackColor = true;
            this.bSetConductor.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // cbConductor
            // 
            this.cbConductor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConductor.ContextMenuStrip = this.contextMenuStrip1;
            this.cbConductor.FormattingEnabled = true;
            this.cbConductor.Location = new System.Drawing.Point(83, 60);
            this.cbConductor.Name = "cbConductor";
            this.cbConductor.Size = new System.Drawing.Size(517, 21);
            this.cbConductor.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Conductor";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbDiscCount
            // 
            this.cbDiscCount.ContextMenuStrip = this.contextMenuStrip1;
            this.cbDiscCount.FormattingEnabled = true;
            this.cbDiscCount.Location = new System.Drawing.Point(231, 87);
            this.cbDiscCount.Name = "cbDiscCount";
            this.cbDiscCount.Size = new System.Drawing.Size(74, 21);
            this.cbDiscCount.TabIndex = 56;
            // 
            // bSetDiscCount
            // 
            this.bSetDiscCount.Location = new System.Drawing.Point(311, 87);
            this.bSetDiscCount.Name = "bSetDiscCount";
            this.bSetDiscCount.Size = new System.Drawing.Size(40, 21);
            this.bSetDiscCount.TabIndex = 55;
            this.bSetDiscCount.Text = "set";
            this.bSetDiscCount.UseVisualStyleBackColor = true;
            this.bSetDiscCount.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "of";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbDiscNo
            // 
            this.cbDiscNo.ContextMenuStrip = this.contextMenuStrip1;
            this.cbDiscNo.FormattingEnabled = true;
            this.cbDiscNo.Location = new System.Drawing.Point(83, 87);
            this.cbDiscNo.Name = "cbDiscNo";
            this.cbDiscNo.Size = new System.Drawing.Size(74, 21);
            this.cbDiscNo.TabIndex = 53;
            // 
            // bSetDiscNo
            // 
            this.bSetDiscNo.Location = new System.Drawing.Point(163, 87);
            this.bSetDiscNo.Name = "bSetDiscNo";
            this.bSetDiscNo.Size = new System.Drawing.Size(40, 21);
            this.bSetDiscNo.TabIndex = 52;
            this.bSetDiscNo.Text = "set";
            this.bSetDiscNo.UseVisualStyleBackColor = true;
            this.bSetDiscNo.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Disc #";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bSetYear
            // 
            this.bSetYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetYear.Location = new System.Drawing.Point(606, 114);
            this.bSetYear.Name = "bSetYear";
            this.bSetYear.Size = new System.Drawing.Size(40, 21);
            this.bSetYear.TabIndex = 41;
            this.bSetYear.Text = "set";
            this.bSetYear.UseVisualStyleBackColor = true;
            this.bSetYear.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // bSetAlbumArtists
            // 
            this.bSetAlbumArtists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetAlbumArtists.Location = new System.Drawing.Point(606, 33);
            this.bSetAlbumArtists.Name = "bSetAlbumArtists";
            this.bSetAlbumArtists.Size = new System.Drawing.Size(40, 21);
            this.bSetAlbumArtists.TabIndex = 40;
            this.bSetAlbumArtists.Text = "set";
            this.bSetAlbumArtists.UseVisualStyleBackColor = true;
            this.bSetAlbumArtists.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // cbYear
            // 
            this.cbYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbYear.ContextMenuStrip = this.contextMenuStrip1;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(83, 114);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(517, 21);
            this.cbYear.TabIndex = 35;
            // 
            // cbAlbumArtists
            // 
            this.cbAlbumArtists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlbumArtists.ContextMenuStrip = this.contextMenuStrip1;
            this.cbAlbumArtists.FormattingEnabled = true;
            this.cbAlbumArtists.Location = new System.Drawing.Point(83, 33);
            this.cbAlbumArtists.Name = "cbAlbumArtists";
            this.cbAlbumArtists.Size = new System.Drawing.Size(517, 21);
            this.cbAlbumArtists.TabIndex = 33;
            // 
            // cbAlbumName
            // 
            this.cbAlbumName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlbumName.ContextMenuStrip = this.contextMenuStrip1;
            this.cbAlbumName.FormattingEnabled = true;
            this.cbAlbumName.Location = new System.Drawing.Point(83, 6);
            this.cbAlbumName.Name = "cbAlbumName";
            this.cbAlbumName.Size = new System.Drawing.Size(517, 21);
            this.cbAlbumName.TabIndex = 32;
            // 
            // bSetAlbumName
            // 
            this.bSetAlbumName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetAlbumName.Location = new System.Drawing.Point(606, 6);
            this.bSetAlbumName.Name = "bSetAlbumName";
            this.bSetAlbumName.Size = new System.Drawing.Size(40, 21);
            this.bSetAlbumName.TabIndex = 32;
            this.bSetAlbumName.Text = "set";
            this.bSetAlbumName.UseVisualStyleBackColor = true;
            this.bSetAlbumName.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // tpTrack
            // 
            this.tpTrack.Controls.Add(this.bSetComposers);
            this.tpTrack.Controls.Add(this.cbComposers);
            this.tpTrack.Controls.Add(this.label13);
            this.tpTrack.Controls.Add(this.bSetGenres);
            this.tpTrack.Controls.Add(this.cbGenres);
            this.tpTrack.Controls.Add(this.label8);
            this.tpTrack.Controls.Add(this.cbTrackArtists);
            this.tpTrack.Controls.Add(this.cbTrackName);
            this.tpTrack.Controls.Add(this.bSetTrackArtists);
            this.tpTrack.Controls.Add(this.bSetTrackName);
            this.tpTrack.Controls.Add(this.cbTrackCount);
            this.tpTrack.Controls.Add(this.bSetTrackCount);
            this.tpTrack.Controls.Add(this.label15);
            this.tpTrack.Controls.Add(this.cbTrackNo);
            this.tpTrack.Controls.Add(this.bSetTrackNo);
            this.tpTrack.Controls.Add(this.label12);
            this.tpTrack.Controls.Add(this.label11);
            this.tpTrack.Controls.Add(this.label10);
            this.tpTrack.Location = new System.Drawing.Point(4, 22);
            this.tpTrack.Name = "tpTrack";
            this.tpTrack.Padding = new System.Windows.Forms.Padding(3);
            this.tpTrack.Size = new System.Drawing.Size(652, 142);
            this.tpTrack.TabIndex = 1;
            this.tpTrack.Text = "Track Info";
            this.tpTrack.UseVisualStyleBackColor = true;
            // 
            // bSetComposers
            // 
            this.bSetComposers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetComposers.Location = new System.Drawing.Point(606, 60);
            this.bSetComposers.Name = "bSetComposers";
            this.bSetComposers.Size = new System.Drawing.Size(40, 21);
            this.bSetComposers.TabIndex = 64;
            this.bSetComposers.Text = "set";
            this.bSetComposers.UseVisualStyleBackColor = true;
            this.bSetComposers.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // cbComposers
            // 
            this.cbComposers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComposers.ContextMenuStrip = this.contextMenuStrip1;
            this.cbComposers.FormattingEnabled = true;
            this.cbComposers.Location = new System.Drawing.Point(83, 60);
            this.cbComposers.Name = "cbComposers";
            this.cbComposers.Size = new System.Drawing.Size(517, 21);
            this.cbComposers.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "Composers";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bSetGenres
            // 
            this.bSetGenres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetGenres.Location = new System.Drawing.Point(606, 114);
            this.bSetGenres.Name = "bSetGenres";
            this.bSetGenres.Size = new System.Drawing.Size(40, 21);
            this.bSetGenres.TabIndex = 61;
            this.bSetGenres.Text = "set";
            this.bSetGenres.UseVisualStyleBackColor = true;
            this.bSetGenres.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // cbGenres
            // 
            this.cbGenres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGenres.ContextMenuStrip = this.contextMenuStrip1;
            this.cbGenres.FormattingEnabled = true;
            this.cbGenres.Location = new System.Drawing.Point(83, 114);
            this.cbGenres.Name = "cbGenres";
            this.cbGenres.Size = new System.Drawing.Size(517, 21);
            this.cbGenres.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Genres";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbTrackArtists
            // 
            this.cbTrackArtists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTrackArtists.ContextMenuStrip = this.contextMenuStrip1;
            this.cbTrackArtists.FormattingEnabled = true;
            this.cbTrackArtists.Location = new System.Drawing.Point(83, 33);
            this.cbTrackArtists.Name = "cbTrackArtists";
            this.cbTrackArtists.Size = new System.Drawing.Size(517, 21);
            this.cbTrackArtists.TabIndex = 56;
            // 
            // cbTrackName
            // 
            this.cbTrackName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTrackName.ContextMenuStrip = this.contextMenuStrip1;
            this.cbTrackName.FormattingEnabled = true;
            this.cbTrackName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbTrackName.Location = new System.Drawing.Point(83, 6);
            this.cbTrackName.Name = "cbTrackName";
            this.cbTrackName.Size = new System.Drawing.Size(517, 21);
            this.cbTrackName.TabIndex = 55;
            // 
            // bSetTrackArtists
            // 
            this.bSetTrackArtists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetTrackArtists.Location = new System.Drawing.Point(606, 33);
            this.bSetTrackArtists.Name = "bSetTrackArtists";
            this.bSetTrackArtists.Size = new System.Drawing.Size(40, 21);
            this.bSetTrackArtists.TabIndex = 52;
            this.bSetTrackArtists.Text = "set";
            this.bSetTrackArtists.UseVisualStyleBackColor = true;
            this.bSetTrackArtists.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // bSetTrackName
            // 
            this.bSetTrackName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetTrackName.Location = new System.Drawing.Point(606, 6);
            this.bSetTrackName.Name = "bSetTrackName";
            this.bSetTrackName.Size = new System.Drawing.Size(40, 21);
            this.bSetTrackName.TabIndex = 51;
            this.bSetTrackName.Text = "set";
            this.bSetTrackName.UseVisualStyleBackColor = true;
            this.bSetTrackName.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // cbTrackCount
            // 
            this.cbTrackCount.ContextMenuStrip = this.contextMenuStrip1;
            this.cbTrackCount.FormattingEnabled = true;
            this.cbTrackCount.Location = new System.Drawing.Point(231, 87);
            this.cbTrackCount.Name = "cbTrackCount";
            this.cbTrackCount.Size = new System.Drawing.Size(74, 21);
            this.cbTrackCount.TabIndex = 50;
            // 
            // bSetTrackCount
            // 
            this.bSetTrackCount.Location = new System.Drawing.Point(311, 87);
            this.bSetTrackCount.Name = "bSetTrackCount";
            this.bSetTrackCount.Size = new System.Drawing.Size(40, 21);
            this.bSetTrackCount.TabIndex = 49;
            this.bSetTrackCount.Text = "set";
            this.bSetTrackCount.UseVisualStyleBackColor = true;
            this.bSetTrackCount.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(209, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = "of";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbTrackNo
            // 
            this.cbTrackNo.ContextMenuStrip = this.contextMenuStrip1;
            this.cbTrackNo.FormattingEnabled = true;
            this.cbTrackNo.Location = new System.Drawing.Point(83, 87);
            this.cbTrackNo.Name = "cbTrackNo";
            this.cbTrackNo.Size = new System.Drawing.Size(74, 21);
            this.cbTrackNo.TabIndex = 47;
            // 
            // bSetTrackNo
            // 
            this.bSetTrackNo.Location = new System.Drawing.Point(163, 87);
            this.bSetTrackNo.Name = "bSetTrackNo";
            this.bSetTrackNo.Size = new System.Drawing.Size(40, 21);
            this.bSetTrackNo.TabIndex = 46;
            this.bSetTrackNo.Text = "set";
            this.bSetTrackNo.UseVisualStyleBackColor = true;
            this.bSetTrackNo.Click += new System.EventHandler(this.SetterButtonClick);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Track #";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Track Artists";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Track Title";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bReplaceTrackArtists);
            this.tabPage1.Controls.Add(this.bResetTrackCount);
            this.tabPage1.Controls.Add(this.bResetTrackNo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 142);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Quick Fixes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bReplaceTrackArtists
            // 
            this.bReplaceTrackArtists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bReplaceTrackArtists.Location = new System.Drawing.Point(6, 64);
            this.bReplaceTrackArtists.Name = "bReplaceTrackArtists";
            this.bReplaceTrackArtists.Size = new System.Drawing.Size(640, 23);
            this.bReplaceTrackArtists.TabIndex = 33;
            this.bReplaceTrackArtists.Text = "Replace Track Artists by Album Artists";
            this.bReplaceTrackArtists.UseVisualStyleBackColor = true;
            this.bReplaceTrackArtists.Click += new System.EventHandler(this.bReplaceTrackArtists_Click);
            // 
            // bResetTrackCount
            // 
            this.bResetTrackCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bResetTrackCount.Location = new System.Drawing.Point(6, 35);
            this.bResetTrackCount.Name = "bResetTrackCount";
            this.bResetTrackCount.Size = new System.Drawing.Size(640, 23);
            this.bResetTrackCount.TabIndex = 33;
            this.bResetTrackCount.Text = "Reset Track/Disc Info based on Disc and DiscCount (multiple discs)";
            this.bResetTrackCount.UseVisualStyleBackColor = true;
            this.bResetTrackCount.Click += new System.EventHandler(this.bResetTrackCount_Click);
            // 
            // bResetTrackNo
            // 
            this.bResetTrackNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bResetTrackNo.Location = new System.Drawing.Point(6, 6);
            this.bResetTrackNo.Name = "bResetTrackNo";
            this.bResetTrackNo.Size = new System.Drawing.Size(640, 23);
            this.bResetTrackNo.TabIndex = 33;
            this.bResetTrackNo.Text = "Reset Track/DiscInfo based on the ordered list of file (one disc)";
            this.bResetTrackNo.UseVisualStyleBackColor = true;
            this.bResetTrackNo.Click += new System.EventHandler(this.bResetTrackNo_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 426);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 17);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "use full path for filename";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbInputColumnChooser
            // 
            this.cbInputColumnChooser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInputColumnChooser.FormattingEnabled = true;
            this.cbInputColumnChooser.Location = new System.Drawing.Point(99, 198);
            this.cbInputColumnChooser.Name = "cbInputColumnChooser";
            this.cbInputColumnChooser.Size = new System.Drawing.Size(517, 21);
            this.cbInputColumnChooser.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 201);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Input Column";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Mp3FixerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.cbInputColumnChooser);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tcDataInput);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Mp3FixerMainForm";
            this.Text = "Mp3 Tag Editor";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.Mp3FixerMainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tcDataInput.ResumeLayout(false);
            this.tpAlbum.ResumeLayout(false);
            this.tpAlbum.PerformLayout();
            this.tpTrack.ResumeLayout(false);
            this.tpTrack.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editPatternsToolStripMenuItem;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tcDataInput;
        private System.Windows.Forms.TabPage tpAlbum;
        private System.Windows.Forms.TabPage tpTrack;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbAlbumName;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbAlbumArtists;
        private System.Windows.Forms.ComboBox cbTrackNo;
        private System.Windows.Forms.ComboBox cbTrackCount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbTrackArtists;
        private System.Windows.Forms.ComboBox cbTrackName;
        private System.Windows.Forms.Button bSetYear;
        private System.Windows.Forms.Button bSetAlbumArtists;
        private System.Windows.Forms.Button bSetAlbumName;
        private System.Windows.Forms.Button bSetTrackArtists;
        private System.Windows.Forms.Button bSetTrackName;
        private System.Windows.Forms.Button bSetTrackCount;
        private System.Windows.Forms.Button bSetTrackNo;
        private System.Windows.Forms.Button bSetGenres;
        private System.Windows.Forms.ComboBox cbGenres;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDiscCount;
        private System.Windows.Forms.Button bSetDiscCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDiscNo;
        private System.Windows.Forms.Button bSetDiscNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bSetConductor;
        private System.Windows.Forms.ComboBox cbConductor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bSetComposers;
        private System.Windows.Forms.ComboBox cbComposers;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button bResetTrackNo;
        private System.Windows.Forms.Button bResetTrackCount;
        private System.Windows.Forms.Button bReplaceTrackArtists;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbInputColumnChooser;
        private System.Windows.Forms.Label label14;
    }
}

