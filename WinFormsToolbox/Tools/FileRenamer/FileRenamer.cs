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
using WinFormsToolbox.Tools.FileRenamer.Forms;

namespace WinFormsToolbox.Tools.FileRenamer
{
    [Export(typeof(IWinFormsTool))]
    [ExportMetadata("ToolName", "Regex File Renamer")]
    [ExportMetadata("ToolCategory", Categories.FileTool)]
    public class FileRenamer : IWinFormsTool
    {
        public Form GetModuleForm() => new FileRenamerMainForm();

    }
}
