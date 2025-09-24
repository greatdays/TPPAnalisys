using DeveloperPortal.Domain.Notification;
using DeveloperPortal.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.Notification.Interface
{
    public interface ISendNotificationEmail
    {
        Task SendMail(List<NotificationInfoModel> notificationInfoList, NotificationCredential notificationCredential, string actionName, byte[] file = null, string filename = "", string fileType = "", string filePath = "");
        List<NotificationInfoModel> GetNotificationInfo(string TemplateName, Dictionary<string, string> notificationData, string MailId, string MailCC = null, string MailBCC = null);

        NotificationCredential GetNotificationCrdential(string appName);
        List<ContactIdentifierModel> TPPProjectContactList(int? projectId);
    }
}
