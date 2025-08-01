using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ServiceClient
{
    public class AppConfigService
    {
        private IConfiguration _config;

        public AppConfigService(IConfiguration configuration) { _config = configuration; }

        //public T GetConfigValue<T>(string key, string application = null)
        //{
        //    T value = default;
        //    DataAccess.Entity.AppConfiguration appConfig = new DataAccess.Entity.AppConfiguration(_config);

        //    value = appConfig.GetConfigValue<T>(key, application);
        //    return value;
        //}

        //public string GetConfigValue(string key, string application = null)
        //{
        //    return GetConfigValue<string>(key, application);
        //}

        public ControlViewMaster GetControlViewMasterById(int controlViewId)
        {
            AAHREntities aAHREntities = new AAHREntities();
            ControlViewMaster controlViewMaster = aAHREntities.ControlViewMasters.FirstOrDefault(x => x.Id == controlViewId);

            return controlViewMaster;

        }
    }
}
