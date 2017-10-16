using System.Collections.Generic;

namespace WinService.Logging.Appenders
{
    public partial class MailNotificationAppender
    {

        public class MailRecipientEqualityComparer : IEqualityComparer<MailRecipient>
        {
            public bool Equals(MailRecipient x, MailRecipient y)
                => x.ToAddr.Equals(y.ToAddr);

            public int GetHashCode(MailRecipient obj)
                => obj.ToAddr.GetHashCode();
        }
    }
}