using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface INotificationRepository
    {
        Task<bool> SaveNotificationLog(NotificationLog notificationLog);
        Task<List<NotificationInfoModel>> GetNotificationInfo(string TemplateName, Dictionary<string, string> notificationData, string MailId,
            string MailCC = null, string MailBCC = null);
    }
}
