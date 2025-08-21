using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Models.Account;
using DeveloperPortal.Models.Common;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using NetTopologySuite.Index.HPRtree;

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


        public async Task<List<Project>> GetProjectDetailByFileNumberAsync(String FileNumber)
        {

            var data = await _accountRepository.GetProjectDetailByFileNumberAsync(FileNumber);

            if (data != null)
            {
                return  data;
            }

            return new List<Project>();

        }


        public async Task<(List<int> Saved, List<int> NotSaved)> SaveAssnPropContactAsync(List<string> projects, HttpContext httpContext)
        {
            var userId =  UserSession.GetUserSession(httpContext).UserID;
            var userName =  UserSession.GetUserSession(httpContext).UserName;

             var userName1  =   UserSession.GetUserSession(httpContext).UserName;

            var lutContactType = await _accountRepository.GetLutPropContactAssnTypes("Developer");

            var savedProjects = new List<int>();
            var notSavedProjects = new List<int>();

            foreach (var item in projects)
            {
                int projectId = int.Parse(item);

                var popContact = new AssnPropContact
                {
                    IdentifierType = "Project",
                    ContactIdentifierId = userId,
                    LutContactTypeId = lutContactType.LutContactTypeId,
                    Status = "pending approval",
                    Source = "AAHRDeveloperPortal",
                    ProjectId = projectId
                };

                bool isSaved = await _accountRepository.AddPropContactIfNotExistsAsync(popContact, userName);

                if (isSaved)
                    savedProjects.Add(projectId);
                else
                    notSavedProjects.Add(projectId);
            }

            return (savedProjects, notSavedProjects);
        }


    
    }
}


