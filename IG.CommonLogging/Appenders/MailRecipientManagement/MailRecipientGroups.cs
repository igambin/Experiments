using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IG.CommonLogging.Appenders.MailRecipientManagement
{
    [XmlRoot]
    [Serializable]
    public class MailRecipientGroups
    {
        [XmlElement("MailRecipientGroup")]
        public List<MailRecipientGroup> Recipients { get; set; }
    }


}
