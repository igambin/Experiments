using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsToolbox.Forms
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }

        public EditorForm(string[] input)
            : this()
        {
            tbContent.Lines = input;
        }

        public EditorForm(string title, string[] input)
            : this(input)
        {
            Name = title;
        }


        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        private void tsbSaveClicked(object sender, EventArgs e)
        {
            SaveButtonClicked(this, new EventArgs());
        }

        private void tsbCancelClicked(object sender, EventArgs e)
        {
            CancelButtonClicked(this, new EventArgs());
        }
    }
}
