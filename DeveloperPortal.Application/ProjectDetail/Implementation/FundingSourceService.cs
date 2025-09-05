using System.Net.Http.Headers;
using System.Net.Http.Json;
using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Models.Common;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static DeveloperPortal.Domain.PropertySnapshot.Constants;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class FundingSourceService : IFundingSourceService
    {
        public readonly IAccountRepository _accountRepository;
        private IConfiguration _config;


        public FundingSourceService(IAccountRepository accountRepository, IConfiguration config)
        {
            _accountRepository = accountRepository;
            _config = config;
        }
        
    
    }
}


