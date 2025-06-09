using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Models.Generated;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IApnpinRepository
    {
        Task<IEnumerable<Apnpin>> GetAllApnpinsAsync();
        Task<Apnpin> GetApnpinByIdAsync(int id);
        Task<Apnpin> AddApnpinAsync(Apnpin apnpin);
        Task<Apnpin> UpdateApnpinAsync(Apnpin apnpin);
        Task<bool> DeleteApnpinAsync(int id);
    }
}
