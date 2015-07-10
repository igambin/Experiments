using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopyHelper_DirRemover
{
    public interface IConsoleTool
    {
        Categories Category { get; }

        string Name { get;  }

        string Description { get;  }

        void Run();


    }
}
