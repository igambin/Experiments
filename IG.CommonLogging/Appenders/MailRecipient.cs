using System.Collections.Generic;
using System.Linq;
using log4net.Appender;

namespace IG.CommonLogging.Appenders
{
    public partial class MailNotificationAppender : AppenderSkeleton
    {
        public class MailRecipientGroup
        {
            public string EndpointName { get; set; }
            public string Recipients { get; set; }
            public string SubjectPrefix { get; set; }
            public string Sender { get; set; }


            public List<string> RecipientList
                => Recipients?.Split(';').Select(x => x.Trim()).ToList() ?? new List<string>();


            public string PrefixSubject(string subject, int maxLength)
            {
                var result = $"{SubjectPrefix?.Trim() ?? ""} {subject}".Trim();
                return result.Length > maxLength ? result.Substring(0, maxLength - 3) + "..." : result;
            } 
        }

    }
}
