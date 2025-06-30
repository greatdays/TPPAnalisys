

using DeveloperPortal.DataAccess.Entity.Models.Generated;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IAppConfigService
    {

        Task<IEnumerable<AppConfig>> GetOrdersWithCustomersAsync();
    }
}
