namespace DeveloperPortal.Models.PlanReview
{
    /// <summary>
    ///Plan Review Note
    /// </summary>
    public class PlanReviewNote
    {
        /// <summary>
        /// FolderId
        /// </summary>
        public int FolderId { get; set; }

        /// <summary>
        /// NoteId
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// UploadedDate
        /// </summary>
        public DateTime UploadedDate { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }
    }
}
