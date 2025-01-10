using DeveloperPortal.DataAccess.Entity.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity
{
    
    internal class IAppSettings
    {
    }

    public class AppConfig
    {
        private IConfiguration _config;

        public AppConfig(IConfiguration configuration)
        {
            _config = configuration;
        }
        /// <summary>
        /// Retrieve a setting from SQL Server.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="application"></param>
        /// <returns></returns>
        private List<AppConfigs> GetSettingFromSql()
        {
            List<AppConfigs> appConfigList = new List<AppConfigs>();
            using (AAHREntities db = new AAHREntities())
            {
                appConfigList = db.AppConfigs.OrderBy(o => o.Name).Select(s => new AppConfigs
                {
                    Key = s.Name,
                    Value = s.Value,
                    ApplicationID = s.ApplicationID,
                    Application = s.ApplicationMaster.Name
                }).ToList();

                return appConfigList;

            }
        }

        /// <summary>
        /// Get Value of the given key using IAppSettings (LiteDB or SQL Server).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="application">Optional if application is set in App.config AppSettings</param>
        /// <returns>Returns value of the specified type</returns>
        public T GetConfigValue<T>(string key, string application = null)
        {
            string KeyValue = "";
            if (string.IsNullOrEmpty(application))
            {
                //application = ConfigurationManager.AppSettings["Application"];
                application = _config["IDMSettings:IDMPath"].ToString();
            }


            var valueCollection = GetAppConfigs();
            KeyValue = valueCollection.Where(x => x.Key.Equals(key) && x.Application.Equals(application)).Select(s => s.Value).FirstOrDefault();

            if (string.IsNullOrEmpty(KeyValue))
            {
                KeyValue = valueCollection.Where(x => x.Key.Equals(key) && x.ApplicationID.Equals(1)).Select(s => s.Value).FirstOrDefault();

            }
            T value = default(T);

            try
            {
                value = (KeyValue != null ? (T)Convert.ChangeType(KeyValue, typeof(T)) : default(T));

            }
            catch (InvalidCastException exception)
            {
                throw new InvalidCastException($"Invalid cast exception for key: {key}, expected type: {typeof(T).Name}", exception);
            }

            return value;
        }

        public List<AppConfigs> GetAppConfigs()
        {

            // Try to get the value from LiteDB first
            //var valueCollection = GetSettingFromLiteDb();
            var valueCollection = new List<AppConfigs>();

            // If the key does not exist in LiteDB, fallback to SQL Server
            if (valueCollection == null || valueCollection.Count == 0)
            {
                valueCollection = GetSettingFromSql();

                // If the key is found in SQL Server, store it in LiteDB for future use
                if (valueCollection != null && valueCollection.Count > 0)
                {
                    //StoreSettingInLiteDb(valueCollection);
                }
            }

            return valueCollection;
        }
    }

    public class AppConfigs
    {
        public int ApplicationID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Application { get; set; }
    }
}
