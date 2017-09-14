using System;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Core;
using WinFormsToolbox.Interfaces;
using System.Windows.Forms;
using WinFormsToolbox.Models;
using WinFormsToolbox.Tools.Mp3Fixer.Forms;

namespace WinFormsToolbox.Tools.Mp3Fixer
{
    [Export(typeof(IWinFormsTool))]
    [ExportMetadata("ToolName", "MP3 Regex Editor")]
    [ExportMetadata("ToolCategory", Categories.Mp3Tool)]
    public class Mp3TagFixer : IWinFormsTool
    {
        public Form GetModuleForm() => new Mp3FixerMainForm();

    }
}
