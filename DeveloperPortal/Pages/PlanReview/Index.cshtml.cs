using DeveloperPortal.Models.PlanReview;
using DeveloperPortal.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.PlanReview
{
    /// <summary>
    /// Plan Review home page
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Plan Review Folders
        /// </summary>
        public List<PlanReviewFolder> PlanReviewFolders { get; set; } = new List<PlanReviewFolder>();
        public FolderModel FolderModel { get; set; } = new FolderModel();

        /// <summary>
        /// Get Plan review details
        /// </summary>
        public void OnGet()
        {
            //API call
            //FolderModel = AAHRServiceClient.GetFolderData("https://localhost:44363/", "0AAxyTJOy501BUk9PVA", "ARLT%20Arleta%20Park");
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
