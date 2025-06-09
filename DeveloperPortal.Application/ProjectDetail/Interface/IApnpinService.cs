using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Models.Generated;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IApnpinService
    {
        Task<IEnumerable<Apnpin>> GetOrdersWithCustomersAsync();
    }
}
