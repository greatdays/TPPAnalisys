using DeveloperPortal.Models.PlanReview;
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

        /// <summary>
        /// Get Plan review details
        /// </summary>
        public void OnGet()
        {

            for (int i = 0; i < 4; i++)
            {
                var planReviewFolder = new PlanReviewFolder();

                planReviewFolder.FolderId = i + 1;
                planReviewFolder.Name = "Folder #" + planReviewFolder.FolderId;
                planReviewFolder.Files.Add(new PlanReviewFile()
                {
                    FolderId = planReviewFolder.FolderId,
                    FileId = 1,
                    UploadedDate = DateTime.Now,
                    ShareWithNAC = false,
                    UploadedBy = "jigneshkumar.hirpara@lacity.org",
                    Name = "Achp Approve.pdf",
                    FilePath = "Achp Approve.pdf",
                    Category = "ACHP Approved"

                });
                planReviewFolder.Files.Add(new PlanReviewFile()
                {
                    FolderId = planReviewFolder.FolderId,
                    FileId = 2,
                    UploadedDate = DateTime.Now,
                    ShareWithNAC = false,
                    UploadedBy = "jigneshkumar.hirpara@lacity.org",
                    Name = "Financial.pdf",
                    FilePath = "Financial.pdf",
                    Category = "Other"

                });
                planReviewFolder.Files.Add(new PlanReviewFile()
                {
                    FolderId = planReviewFolder.FolderId,
                    FileId = 3,
                    UploadedDate = DateTime.Now,
                    ShareWithNAC = false,
                    UploadedBy = "jigneshkumar.hirpara@lacity.org",
                    Name = "Covenant.pdf",
                    FilePath = "Covenant.pdf",
                    Category = "Other"

                });
                planReviewFolder.Notes.Add(new PlanReviewNote()
                {
                    FolderId = planReviewFolder.FolderId,
                    NoteId = 1,
                    UploadedDate = DateTime.Now,
                    Name = "Jignesh",
                    Note = "Thi Plan is not approved"
                });
                planReviewFolder.Notes.Add(new PlanReviewNote()
                {
                    FolderId = planReviewFolder.FolderId,
                    NoteId = 1,
                    UploadedDate = DateTime.Now,
                    Name = "Jignesh",
                    Note = "Reviewd Plan drawing"
                });
                PlanReviewFolders.Add(planReviewFolder);
            }
        }

    }
}
