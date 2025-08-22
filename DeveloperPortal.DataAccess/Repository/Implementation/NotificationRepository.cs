using DeveloperPortal.Constants;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.Notification;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AAHREntities _context;
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public Dictionary<string, string> NotificationData = new Dictionary<string, string>();
        public NotificationRepository(AAHREntities context)
        {
            _context = context;
        }
        public async Task<bool> SaveNotificationLog(NotificationLog notificationLog)
        {
            bool isSuccess = false;
            if (notificationLog != null)
            {
                await _context.NotificationLogs.AddAsync(notificationLog);
                isSuccess = true;
            }
            return isSuccess;
        }
        public List<NotificationInfoModel> GetNotificationInfo(string TemplateName, Dictionary<string, string> notificationData, string MailId,
            string MailCC = null, string MailBCC = null)
        {
            List<NotificationInfoModel> notificationInfoList = new List<NotificationInfoModel>();
            dictionary = notificationData;

            var NotificationDetails =  _context.NotificationTemplates.Where(s => s.Name == TemplateName).ToList();
            foreach (var notificationDetail in NotificationDetails)
            {
                NotificationInfoModel notificationModel = new NotificationInfoModel();
                notificationModel.MailId = MailId;
                notificationModel.MailBCC = MailBCC;
                notificationModel.MailCC = MailCC;
                notificationModel.Subject = PrepareSubject(notificationDetail.EmailSubject);
                notificationModel.Body = PrepareBody(notificationDetail.EmailBody);
                notificationModel.Body = PrepareFooterAndCommonText(notificationModel.Body);
                notificationInfoList.Add(notificationModel);
            }
            return notificationInfoList;
        }
        public NotificationCredential GetNotificationCredential(string appName)
        {
            NotificationCredential notificationCredential = new NotificationCredential();

            int? ApplicationID =  _context.ApplicationMasters.FirstOrDefault(m => m.Name == appName)?.Id;
            var notificationSource =  _context.NotificationSources.FirstOrDefault(s => s.ApplicationId == ApplicationID);
            notificationCredential.Host = notificationSource.Host;
            notificationCredential.Port = notificationSource.Port;
            notificationCredential.CredentialName = notificationSource.CredentialName;
            notificationCredential.CredentialPwd = notificationSource.CredentialPwd;
            notificationCredential.FromEmailId = notificationSource.FromEmailId;
            notificationCredential.EnableSsl = notificationSource.EnableSsl.HasValue ? notificationSource.EnableSsl.Value : false;

            return notificationCredential;
        }
        public string PrepareSubject(string emailSubject)
        {
            if (dictionary != null)
            {
                foreach (var item in dictionary)
                {
                    emailSubject = emailSubject.Replace("[" + item.Key + "]", item.Value);
                }
            }

            return emailSubject;
        }
        public string PrepareBody(string emailBody)
        {
            if (dictionary != null)
            {
                foreach (var item in dictionary)
                {
                    emailBody = emailBody.Replace("[" + item.Key + "]", item.Value);
                }
            }

            return emailBody;
        }
        public string PrepareFooterAndCommonText(string body)
        {
            string emailFooter = string.Empty;

            if (body.Contains("[Program Footer]"))
            {
                emailFooter = _context.NotificationTemplates.Where(m => m.Name == EmailTemplateConstant.ProgramFooterTemplate).SingleOrDefault().EmailBody;
                body = body.Replace("[Program Footer]", emailFooter);

            }
            if (body.Contains("[System Footer]"))
            {
                emailFooter = _context.NotificationTemplates.Where(m => m.Name == EmailTemplateConstant.SystemFooterTemplate).SingleOrDefault().EmailBody;
                body = body.Replace("[System Footer]", emailFooter);

            }

            foreach (var item in EmailTemplateConstant.EmailConstants)
            {
                body = body.Replace("[" + item.Key + "]", item.Value);
            }

            return body;
        }
    }
}
