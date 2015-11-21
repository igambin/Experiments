﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsToolbox.Tools.Mp3Fixer;
using WinFormsToolbox.Tools.Mp3Fixer.Forms;

namespace Mp3RegexEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mp3FixerMainForm());
        }
    }
}
