namespace DeveloperPortal.Domain.ProjectDetail
{

    public class SiteInformationModel
    {
        public int CaseID { get; set; }
        public int RefProjectSiteID { get; set; }
        public int ProjectSiteID { get; set; }
        public int ProjectID { get; set; }
        public string SiteAddress { get; set; }
        public string FileNumber { get; set; }
        public string SiteName { get; set; }
        public string AssigneeName { get; set; }
        public int NoOfBuildings { get; set; }
        public int NoOfUnits { get; set; }
        public string PolicyAnalyst { get; set; }
        public string SiteCaseStatus { get; set; }
        public string SiteCaseType { get; set; }
        //[AllowHtml]
        public string Actions { get; set; }
        public int DocumentControlViewModelId { get; set; }
        public int LogsControlViewModelId { get; set; }
        public int ContactControlViewModelId { get; set; }

    }

    /// <summary>
    /// SiteDataModel
    /// </summary>
    public class SiteDataModel
    {
        public int ProjectId { get; set; }
        public int ProjectSiteID { get; set; }

        public int Id { get; set; }
        public string SiteName { get; set; }
        public string FileNumber { get; set; }
        public string SiteInfomationData { get; set; }
        public int DocumentControlViewModelId { get; set; }
        public int LogsControlViewModelId { get; set; }
        public int ContactControlViewModelId { get; set; }
        public List<string> SiteList { get; set; }
        //public List<FloorPlanInformation> FloorPlanInformation { get; set; }
        //public List<SelectListItem> AccessibleFeatureTypeList { get; set; }
        //public List<SelectListItem> LutTotalBedrooms { get; set; }
        //public List<SelectListItem> LutUnitType { get; set; }
        public List<SiteInformationModel> SiteInformationData { get; set; }
    }

    public class SiteInformationParamModel
    {
        public List<SiteInformationModel> SiteInformationData { get; set; }
        public int CaseId { get; set; }

    }


    public class ProjectSummaryModel
    {
        public int CaseID { get; set; }
        public int RefProjectSiteId { get; set; }
        public int ProjectSiteId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName  { get; set; }
        public string Address { get; set; }
        public string ACHPNumber { get; set; }
        public string ProjectNumber { get; set; }
        public string OccupancyType { get; set; }

        public string Status { get; set; }
        public string CovenantExpirationDate { get; set; }
        public string PorjectType { get; set; }
        public string HIMSNumber { get; set; }
        public string RCSAssignee { get; set; }
        public string CountryAssessor { get; set; }

        public string ServiceRequestNumber { get; set; }
        public string ProjectServiceRequestNumber { get; set; }
        public int? ProjectCaseID { get; set; }
        public int? RefProjectID { get; set; }
        public int? ProjectcasetypeId { get; set; }
        public string ProjectCaseType { get; set; }
        public long ServiceRequestId { get; set; }
        public string AssigneeName { get; set; }
        public string APN { get; set; }
        public string SiteAddress { get; set; }
        public string CaseType { get; set; }
        public string URL { get; set; }
      
        public string AcHPFileProjectNumber { get; set; }
        public string AcHPFileNumber { get; set; }
        public string TypeOfOccupancy { get; set; }
        public string PropertyURL { get; set; }
        public string ProblemCase { get; set; }
        public List<string> ProjectAssessors { get; set; }

        public string AssignedPolicyAnalyst { get; set; }

    }
}
