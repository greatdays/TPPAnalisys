namespace DeveloperPortal.Models.PlanReview
{
    public class PlanReviewFolder
    {
        /// <summary>
        /// FolderId
        /// </summary>
        public int FolderId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// UploadedBy
        /// </summary>
        public string UploadedBy { get; set; } = string.Empty;

        /// <summary>
        /// Files
        /// </summary>
        public List<PlanReviewFile> Files { get; set; } = new List<PlanReviewFile>();
        /// <summary>
        /// Notes
        /// </summary>
        public List<PlanReviewNote> Notes { get; set; } = new List<PlanReviewNote>();
    }
}
