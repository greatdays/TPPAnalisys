using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Models.Account;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Http;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IAccountService
    {

        Task<List<VwPropertySearch>> GetACHPDetails(String FileNumber);
        Task<List<Project>> GetProjectDetailByFileNumberAsync(String FileNumber);

        Task<(List<int> Saved, List<int> NotSaved)> SaveAssnPropContactAsync(List<string> projects, HttpContext httpContext);
        public Task<int> ContactIdentifierSave(ApplicantSignupModel signupModel, string userName, string source = "");
    }
}
