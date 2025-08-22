using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Notification
{
    public class NotificationInfoModel
    {
        /// <summary>
        /// Action Id
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// Template Id
        /// </summary>
        public int TemplateId { get; set; }

        /// <summary>
        /// Schema Id
        /// </summary>
        public int SchemaId { get; set; }

        /// <summary>
        /// Schema Type
        /// </summary>
        public string SchemaType { get; set; }

        /// <summary>
        /// Mail Id
        /// </summary>
        public string MailId { get; set; } = string.Empty;

        /// <summary>
        /// Mail Id
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Mail Id
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// attachments
        /// </summary>
        public List<Attachments> Attachments { get; set; }
        /// <summary>
        /// Mail Id for CC
        /// </summary>
        public string MailCC { get; set; }

        /// <summary>
        /// Mail Id for BCC
        /// </summary>
        public string MailBCC { get; set; }
    }
    public class Attachments
    {
        public List<FileList> Files { get; set; }
    }

    public class FileList
    {
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
    }
}
