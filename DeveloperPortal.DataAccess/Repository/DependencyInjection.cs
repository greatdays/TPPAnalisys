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
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IProjectDetailRepository, ProjectDetailRepository>();
            services.AddScoped<IFloorPlanTypeRepository, FloorPlanTypeRepository>();
            services.AddScoped<IBuildingIntakeRepository, BuildingIntakeRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IFundingSourceRepository, FundingSourceRepository>();
            
            return services;
        }
    }
}
