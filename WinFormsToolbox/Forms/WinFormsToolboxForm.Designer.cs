namespace WinFormsToolbox.Forms
{
    partial class WinFormsToolboxForm
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
            this.CategoryChooser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.ToolChooser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CategoryChooser
            // 
            this.CategoryChooser.FormattingEnabled = true;
            this.CategoryChooser.Location = new System.Drawing.Point(103, 12);
            this.CategoryChooser.Name = "CategoryChooser";
            this.CategoryChooser.Size = new System.Drawing.Size(235, 21);
            this.CategoryChooser.TabIndex = 1;
            this.CategoryChooser.SelectedIndexChanged += new System.EventHandler(this.CategoryChooser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Category";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ToolChooser);
            this.panel1.Controls.Add(this.CategoryChooser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 106);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ToolChooser
            // 
            this.ToolChooser.FormattingEnabled = true;
            this.ToolChooser.Location = new System.Drawing.Point(103, 39);
            this.ToolChooser.Name = "ToolChooser";
            this.ToolChooser.Size = new System.Drawing.Size(235, 21);
            this.ToolChooser.TabIndex = 3;
            this.ToolChooser.SelectedIndexChanged += new System.EventHandler(this.ToolChooser_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose Tool";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // WinFormsToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 99);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(370, 138);
            this.MinimumSize = new System.Drawing.Size(370, 138);
            this.Name = "WinFormsToolboxForm";
            this.Text = "WinForms Toolbox";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox CategoryChooser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ToolChooser;
        private System.Windows.Forms.Label label2;
    }
}

