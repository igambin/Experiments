﻿using System;
using System.Collections.Generic;

namespace IG.CommonLogging.LogModels
{
    public interface ILogItem
    {
        string BlobLogMessage { get; set; }
        string BlobName { get; }
        Type DataItemType { get; }
        IEnumerable<string> Errors { get; set; }
        Exception Exception { get; set; }
        bool IsNotifyEMailRecipients { get; }
        string SimpleLogMessage { get; }
        string MailLogMessage { get; set; }
        string MailSubject { get; }
        byte[] PayloadStream { get; set; }
        string RenderErrors { get; }
        string TrackingId { get; }
    }
}