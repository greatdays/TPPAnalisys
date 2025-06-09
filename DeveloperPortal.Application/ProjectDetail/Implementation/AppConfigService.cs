using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class AppConfigService : IAppConfigService
    {

        private readonly IAppConfigRepository _appConfigRepository;

        
        public AppConfigService(IAppConfigRepository appConfigRepository)
        {
            _appConfigRepository = appConfigRepository;

        }


        public async Task<IEnumerable<AppConfig>> GetOrdersWithCustomersAsync()
        {

            return await _appConfigRepository.GetAllAppConfigsAsync();
            
        }


    }
}
