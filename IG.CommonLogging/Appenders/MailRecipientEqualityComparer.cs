using System.Collections.Generic;

namespace IG.CommonLogging.Appenders
{
    public class MailRecipientEqualityComparer : IEqualityComparer<MailNotificationAppender.MailRecipient>
    {
        public bool Equals(MailNotificationAppender.MailRecipient x, MailNotificationAppender.MailRecipient y)
            => x.ToAddr.Equals(y.ToAddr);

        public int GetHashCode(MailNotificationAppender.MailRecipient obj)
            => obj.ToAddr.GetHashCode();
    }
}