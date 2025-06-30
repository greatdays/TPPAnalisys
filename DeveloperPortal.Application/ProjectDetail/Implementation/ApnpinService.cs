using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class ApnpinService : IApnpinService
    {

        private readonly IApnpinRepository _apnpinRepository;


        public ApnpinService(IApnpinRepository apnpinRepository)
        {
            
            _apnpinRepository = apnpinRepository;

        }


        public async Task<IEnumerable<Apnpin>> GetOrdersWithCustomersAsync()
        {

            return await _apnpinRepository.GetAllApnpinsAsync();

        }
    }
}
