using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeveloperPortal.DataAccess.Entity.Data;
using System.Data.Entity;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IAppConfigRepository
    {


        Task<IEnumerable<AppConfig>> GetAllAppConfigsAsync();
        Task<AppConfig> GetAppConfigByIdAsync(int id);
        Task AddAppConfigAsync(AppConfig appConfig);
        Task UpdateAppConfigAsync(AppConfig appConfig);
        Task DeleteAppConfigAsync(int id);
    }
}
