using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using ComCon.DataAccess.Entity;
using ComCon.DataAccess.ViewModel;
using System.Net.Mail;
using System.Net.Mime;

namespace DeveloperPortal.Models.IDM
{
    public class SendNotification
    {
        /// <summary>
        ///Function to Send Mail
        /// </summary>
        public void SendMail(List<NotificationInfoModel> notificationInfoList, NotificationCredential notificationCredential, string actionName, byte[] file = null, string filename = "", string fileType = "", string filePath = "")
        {
            SmtpClient smtp = new System.Net.Mail.SmtpClient();
            var credential = (System.Net.NetworkCredential)smtp.Credentials;

            if (notificationInfoList != null)
            {
                foreach (var notification in notificationInfoList)
                {
                    if (notification.MailId != null)
                    {
                        string[] MailIds = notification.MailId.Split(',');
                        for (int i = 0; i < MailIds.Count(); i++)
                        {
                            if (MailIds[i] != "" && IsValidEmail(MailIds[i]))
                            {
                                MailMessage mail = new MailMessage();
                                smtp.Host = notificationCredential.Host;
                                smtp.Port = notificationCredential.Port;
                                if (!string.IsNullOrEmpty(notificationCredential.CredentialName) && !string.IsNullOrEmpty(notificationCredential.CredentialPwd))
                                {
                                    smtp.Credentials = new System.Net.NetworkCredential(notificationCredential.CredentialName, notificationCredential.CredentialPwd);
                                }
                                else
                                {
                                    smtp.Credentials = null;
                                }
                                mail.To.Add(MailIds[i]);
                                if (!string.IsNullOrEmpty(notification.MailCC))
                                {
                                    mail.CC.Add(notification.MailCC);
                                }

                                if (!string.IsNullOrEmpty(notification.MailBCC))
                                {
                                    mail.Bcc.Add(notification.MailBCC);
                                }
                                mail.From = new MailAddress(notificationCredential.FromEmailId);
                                mail.Subject = notification.Subject;
                                mail.Body = notification.Body;
                                mail.IsBodyHtml = true;
                                smtp.EnableSsl = notificationCredential.EnableSsl;

                                /*send attachment*/
                                //if (notification.Attachments != null && notification.Attachments.Count() > 0)
                                //{
                                //    foreach (var item in notification.Attachments)
                                //    {
                                //        foreach (var fileItem in item.Files)
                                //        {
                                //            MemoryStream ms = new MemoryStream(fileItem.FileBytes);
                                //            Attachment attachment = new Attachment(ms, fileItem.FileName, fileItem.MimeType);
                                //            mail.Attachments.Add(attachment);
                                //        }
                                //    }

                                //}

                                /*Notification Logs*/
                                NotificationLog notificationLog = new NotificationLog();
                                notificationLog.MailFrom = notificationCredential.FromEmailId;
                                notificationLog.MailTo = MailIds[i];
                                notificationLog.Subject = notification.Subject;
                                notificationLog.Body = notification.Body;
                                notificationLog.Action = actionName;
                                notificationLog.MailCC = notification.MailCC;
                                notificationLog.MailBCC = notification.MailBCC;

                                try
                                {
                                    if (file != null && filename != "" && fileType != "")
                                    {
                                        using (MemoryStream ms = new MemoryStream())
                                        {
                                            ms.Write(file, 0, file.Length);

                                            // Set the position to the beginning of the stream.
                                            ms.Seek(0, SeekOrigin.Begin);

                                            // Create attachment
                                            ContentType contentType = new ContentType();
                                            contentType.MediaType = fileType;
                                            contentType.Name = filename;
                                            Attachment attachment = new Attachment(ms, contentType);

                                            // Add the attachment
                                            mail.Attachments.Add(attachment);
                                            smtp.Send(mail);
                                        }

                                    }
                                    else if (filePath != "")
                                    {

                                        var bytes = File.ReadAllBytes(Path.GetFullPath(filePath));
                                        MemoryStream ms = new MemoryStream(bytes);
                                        Attachment attachment = new Attachment(ms, filename, fileType);
                                        mail.Attachments.Add(attachment);
                                        smtp.Send(mail);


                                    }
                                    else
                                    {
                                        smtp.Send(mail);
                                    }

                                    notificationLog.Status = EmailStatus.Sent.ToString();
                                }
                                catch (Exception ex)
                                {
                                    notificationLog.Status = EmailStatus.Failed.ToString();
                                    notificationLog.Error = ex.Message;
                                }
                                notificationLog.SentOn = DateTime.Now;
                                using (ComConEntities db = new ComConEntities())
                                {
                                    db.NotificationLogs.Add(notificationLog);
                                    db.SaveChanges();
                                }

                            }
                        }
                    }
                }
            }
        }

        #region validate Email
        /// <summary>
        /// validate email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

    #region "Notification Info Model Class"
    /// <summary>
    /// Class used to create list of Notification details
    /// </summary>
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

    public class NotificationCredential
    {
        private IConfiguration _config;
        public NotificationCredential()
        {
            int _portNumber = -1;

            Host = _config["NotificationCredentialConfig:Host"].ToString();
            string port = _config["NotificationCredentialConfig:Port"].ToString();
            int.TryParse(port, out _portNumber);
            Port = _portNumber;
            
            CredentialName = _config["NotificationCredentialConfig:CredentialName"].ToString();
            CredentialPwd = _config["NotificationCredentialConfig:CredentialPwd"].ToString();
            FromEmailId = _config["NotificationCredentialConfig:FromEmailId"].ToString();

            string enableSsl = _config["NotificationCredentialConfig:EnableSsl"].ToString();
            bool bEnableSsl = false;
            bool.TryParse(enableSsl, out bEnableSsl);
            EnableSsl = bEnableSsl;

            /*string ApplicationName = ConfigurationManager.AppSettings["Application"].ToString();

            using (ComConEntities db = new ComConEntities())
            {
                int ApplicationID = db.ApplicationMasters.FirstOrDefault(m => m.Name == ApplicationName).Id;
                var notificationSource = db.NotificationSources.FirstOrDefault(s => s.ApplicationId == ApplicationID);
                Host = notificationSource.Host;
                Port = notificationSource.Port;
                CredentialName = notificationSource.CredentialName;
                CredentialPwd = notificationSource.CredentialPwd;
                FromEmailId = notificationSource.FromEmailId;
                EnableSsl = notificationSource.EnableSsl.HasValue ? notificationSource.EnableSsl.Value : false;
            }*/
        }

        /// <summary>
        /// initialise fromEmail
        /// </summary>
        /// <param name="fromEmail"></param>
        /*public NotificationCredential(string fromEmail = "")
        {
            string ApplicationName = ConfigurationManager.AppSettings["Application"].ToString();

            

            using (ComConEntities db = new ComConEntities())
            {
                int ApplicationID = db.ApplicationMasters.FirstOrDefault(m => m.Name == ApplicationName).Id;
                var notificationSource = db.NotificationSources.FirstOrDefault(s => s.ApplicationId == ApplicationID);
                Host = notificationSource.Host;
                Port = notificationSource.Port;
                CredentialName = notificationSource.CredentialName;
                CredentialPwd = notificationSource.CredentialPwd;
                FromEmailId = fromEmail;
                EnableSsl = notificationSource.EnableSsl.HasValue ? notificationSource.EnableSsl.Value : false;
            }
        }*/

        public string Host { get; set; }
        public int Port { get; set; }
        public string CredentialName { get; set; }
        public string CredentialPwd { get; set; }
        public string FromEmailId { get; set; }
        public bool EnableSsl { get; set; }
    }

    #endregion
}
