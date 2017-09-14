using System;
using System.Collections.Generic;

namespace IG.CommonLogging.LogModels
{
    public interface ISerializingLogItem<TItem> : ILogItem
    {
        TItem DataItem { get; set; }

    }
}