using DeveloperPortal.Models.PlanReview;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DeveloperPortal.Pages.PlanReview
{
    /// <summary>
    /// Plan Review home page
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfigurationRoot Configuration { get; set; }
        /// <summary>
        /// Plan Review Folders
        /// </summary>
        public List<PlanReviewFolder> PlanReviewFolders { get; set; } = new List<PlanReviewFolder>();
        /// <summary>
        /// FolderModel
        /// </summary>
        public FolderModel FolderModel { get; set; } = new FolderModel();

        /// <summary>
        /// Get Plan review details
        /// </summary>
        /// 
        
        public void OnGet([FromQuery(Name = "CaseDetailId")] string CaseDetailId, [FromQuery(Name = "projectId")] int projectId)
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = configBuilder.Build();

            try
            {
                //API call
                var url = Configuration.GetSection("AAHRApiSettings:URL").Value;
                var googleDrive = Configuration.GetSection("AAHRApiSettings:GoogleDrive").Value;
                FolderModel = AAHRServiceClient.GetFolderData(url, googleDrive, "ARLT%20Arleta%20Park");
                return;
            }
            catch
            {
                //Ignore for testing
            }

            var folderModelList = new FolderModel();
            for (int i = 0; i < 4; i++)
            {

                var planReviewFolder = new FolderModel();
                planReviewFolder.ID = (i + 1).ToString();
                planReviewFolder.Name = "Folder #" + planReviewFolder.ID;
                planReviewFolder.Files.Add(new FileModel()
                {
                    ID = planReviewFolder.ID,
                    UploadedDate = DateTime.Now,
                    ShareWithNAC = false,
                    UploadedBy = "jigneshkumar.hirpara@lacity.org",
                    Name = "Achp Approve.pdf",
                    Link = "Achp Approve.pdf",

                });
                planReviewFolder.Files.Add(new FileModel()
                {
                    ID = planReviewFolder.ID,

                    UploadedDate = DateTime.Now,
                    ShareWithNAC = false,
                    UploadedBy = "jigneshkumar.hirpara@lacity.org",
                    Name = "Financial.pdf",
                    Link = "Financial.pdf",

                });
                planReviewFolder.Files.Add(new FileModel()
                {
                    ID = planReviewFolder.ID,
                    UploadedDate = DateTime.Now,
                    ShareWithNAC = false,
                    UploadedBy = "jigneshkumar.hirpara@lacity.org",
                    Name = "Covenant.pdf",
                    Link = "Covenant.pdf",
                });

                //planReviewFolder.Notes.Add(new PlanReviewNote()
                //{
                //    FolderId = planReviewFolder.FolderId,
                //    NoteId = 1,
                //    UploadedDate = DateTime.Now,
                //    Name = "Jignesh",
                //    Note = "Thi Plan is not approved"
                //});
                //planReviewFolder.Notes.Add(new PlanReviewNote()
                //{
                //    FolderId = planReviewFolder.FolderId,
                //    NoteId = 1,
                //    UploadedDate = DateTime.Now,
                //    Name = "Jignesh",
                //    Note = "Reviewd Plan drawing"
                //});
                //PlanReviewFolders.Add(planReviewFolder);

                folderModelList.Folders.Add(planReviewFolder);

            }
            FolderModel = folderModelList;
        }

    }
}
