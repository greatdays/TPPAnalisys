using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Notification
{
    public class NotificationCredential
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string CredentialName { get; set; }
        public string CredentialPwd { get; set; }
        public string FromEmailId { get; set; }
        public bool EnableSsl { get; set; }
    }
    public enum EmailStatus
    {
        Sent,
        Failed
    }

}
