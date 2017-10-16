using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WinService.Logging.Appenders.MailRecipientManagement
{
    [XmlRoot]
    [Serializable]
    public class MailRecipientGroups
    {
        [XmlElement("MailRecipientGroup")]
        public List<MailRecipientGroup> Recipients { get; set; }
    }


}
