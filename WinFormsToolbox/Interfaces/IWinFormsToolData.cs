using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Core;

namespace WinFormsToolbox.Interfaces
{
    public interface IWinFormsToolData
    {
        string ToolName { get; }

        Categories ToolCategory { get; }

    }
}
