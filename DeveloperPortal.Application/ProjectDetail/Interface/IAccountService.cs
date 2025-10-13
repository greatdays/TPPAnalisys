using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.Dashboard;
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
        Task<List<VwAspNetRole>> GetUSerRole(int? ApplicationID);
        Task<APNSearch> GetAPNProjectName(String APNNumber);
        Task<bool> CreateProject(ProjectModel projectModel, HttpContext httpContext);

        Task<bool> CreateProjectWithNewAPNandSite(ProjectProvisionRequest provisionModel, HttpContext httpContext);
    }
}
