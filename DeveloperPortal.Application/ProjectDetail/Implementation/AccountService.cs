using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Models.Account;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;


        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<List<VwPropertySearch>> GetACHPDetails(String FileNumber)
        {

           var data  = await _accountRepository.GetVwPropertySearchesByFileNumberAsync(FileNumber);

            if (data != null) 
            {
                var result = data.GroupBy(v => v.ProjectSiteId)
                            .Select(g => g.First())
                            .ToList();

                return result;

            }
                
            return new List<VwPropertySearch>(); 

        }
    }
}


