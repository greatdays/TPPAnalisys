using DeveloperPortal.Application.Notification.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.Notification;
using DeveloperPortal.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.Notification.Implementation
{
    public class SendNotificationEmailService : ISendNotificationEmail
    {
        private readonly INotificationRepository notificationRepository;
        public SendNotificationEmailService(INotificationRepository _notificationRepository) 
        { 
            this.notificationRepository = _notificationRepository;
        }
        public  List<NotificationInfoModel> GetNotificationInfo(string TemplateName, Dictionary<string, string> notificationData, string MailId, string MailCC = null, string MailBCC = null)
        {
            List<NotificationInfoModel> notificationInfoModels = new List<NotificationInfoModel>();

            notificationInfoModels =  notificationRepository.GetNotificationInfo(TemplateName, notificationData, MailId, MailCC, MailBCC);

            return notificationInfoModels;
        }
        public async Task SendMail(List<NotificationInfoModel> notificationInfoList, NotificationCredential notificationCredential, string actionName, byte[] file = null, string filename = "", string fileType = "", string filePath = "")
        {
            bool isSave = false;
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
                                notificationLog.MailCc = notification.MailCC;
                                notificationLog.MailBcc = notification.MailBCC;

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

                                    notificationLog.Status = DeveloperPortal.Domain.Notification.EmailStatus.Sent.ToString();
                                }
                                catch (Exception ex)
                                {
                                    notificationLog.Status = DeveloperPortal.Domain.Notification.EmailStatus.Failed.ToString();
                                    notificationLog.Error = ex.Message;
                                }
                                notificationLog.SentOn = DateTime.Now;

                                isSave = await notificationRepository.SaveNotificationLog(notificationLog);

                            }
                        }
                    }
                }
            }
        }
        
        public NotificationCredential GetNotificationCrdential(string appName)
        {
            return notificationRepository.GetNotificationCredential(appName);
        }
        public List<ContactIdentifierModel> TPPProjectContactList(int? projectId)
        {
            return notificationRepository.TPPProjectContactList(projectId);
        }
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
    }
}
