using System;

namespace Toolbox.Core
{
    [Flags]
    public enum Categories
    {
        All = 0,
        FileTool = 1,
        SavegameEditor = 1 << 1,
        Mp3Tool = 1 << 2,
    }
}
