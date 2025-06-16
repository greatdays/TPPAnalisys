using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Models.Generated;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<List<VwPropertySearch>> GetVwPropertySearchesByFileNumberAsync(string FileNumber);
    }
}
