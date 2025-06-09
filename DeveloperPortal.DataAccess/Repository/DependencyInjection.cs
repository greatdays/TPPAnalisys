using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Repository.Implementation;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperPortal.DataAccess.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IStoredProcedureExecutor, StoredProcedureExecutor>();
            services.AddScoped<IAppConfigRepository, AppConfigRepository>();
            services.AddScoped<IApnpinRepository, ApnpinRepository>();
            services.AddDbContext<AAHREntities>(options =>
    options.UseSqlServer("Data Source=43devdb10;Initial Catalog=AAHRLocal;Integrated Security=true;user id=appACHP;password=BDpwD7@cHP;TrustServerCertificate=true"), ServiceLifetime.Scoped);
            services.AddDbContext<AAHREntitiesHelper>(options =>
    options.UseSqlServer("Data Source=43devdb10;Initial Catalog=AAHRLocal;Integrated Security=true;user id=appACHP;password=BDpwD7@cHP;TrustServerCertificate=true"), ServiceLifetime.Scoped);
            return services;
        }
    }
}
