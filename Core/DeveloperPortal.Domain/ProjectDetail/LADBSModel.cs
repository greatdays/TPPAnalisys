using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.ProjectDetail
{

    class LADBSModel
    {
    }

    public class PcisPermitDetail
    {
        public string PermitNumber { get; set; }
        public string Department { get; set; }
        public string ProjectAddress { get; set; }
        public string PlanCheckNumber { get; set; }
        public bool Valid { get; set; }
        public string ValidMessage { get; set; }
        public List<PcisPermitProjectDetails> ProjectDetailsList { get; set; }
        public List<PcisPermitPermitInfo> PermitInfoList { get; set; }
        public List<PcisPermitPlanCheckInfo> PlanCheckInfoList { get; set; }
        public List<PcisPermitHistory> PermitHistoryList { get; set; }
        public List<PcisPermitClearances> PermitClearanceList { get; set; }
        public List<PcisPermitInspectionInfo> PermitInspInfoList { get; set; }
        public List<PcisPermitPendingInsp> PermitPendingInspInfoList { get; set; }
        public List<PcisPermitCompletedInsp> PermitCompletedInpsList { get; set; }
        public List<CFOSingleStatus> CofOList { get; set; }
        public bool Delete { get; set; }
    }

    public class PcisPermitProjectDetails
    {
        public string Grp { get; set; }
        public string Typ { get; set; }
        public string Sub_Typ { get; set; }
        public string Zone_Use { get; set; }
        public string Use_Desc { get; set; }
        public string Issue_Y_N { get; set; }
        public DateTime? Issue_Date { get; set; }
        public string Issue_Offc { get; set; }
        public string Crnt_Stat { get; set; }
        public DateTime? Crnt_Stat_Date { get; set; }
        public string Work_Des { get; set; }
        public string Eplan_Y_N { get; set; }
        public string Eplan_Id { get; set; }
    }

    public class PcisPermitPermitInfo
    {
        public string Caegp_Title { get; set; }
        public string Caegp_Name { get; set; }
        public string Caegp_Addr1 { get; set; }
        public string Caegp_Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class PcisPermitPlanCheckInfo
    {
        public string Vtype { get; set; }
        public string Pln_Picked_Up_By { get; set; }
        public string Vt { get; set; }
    }

    public class PcisPermitHistory
    {
        public string Doc_Status { get; set; }
        public DateTime? Doc_Date { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime? Rec_Date { get; set; }
    }

    public class PcisPermitClearances
    {
        public string Condition { get; set; }
        public DateTime? Stat_Date { get; set; }
        public string Status { get; set; }
        public string Stat_Name { get; set; }
        public string Status_Actual { get; set; }
        public int Status_Icon { get; set; }
        public string Dept_Code { get; set; }
        public string Dept_Name { get; set; }
        public string Comment { get; set; }
        public string Comment_Long { get; set; }
    }

    public class PcisPermitInspectionInfo
    {
        public string Insp_Name_Phone { get; set; }
        public string Off_Hours { get; set; }
    }

    public class PcisPermitPendingInsp
    {
        public string Insp_Type { get; set; }
        public DateTime? Insp_Date { get; set; }
        public string Time_Frame { get; set; }
        public string Cnfrm { get; set; }
    }

    public class PcisPermitCompletedInsp
    {
        public string Insp_Type_C { get; set; }
        public DateTime? Insp_Date_C { get; set; }
        public string Status_C { get; set; }
        public string Insp_Name_C { get; set; }
        public DateTime? G6_Act_DD { get; set; }
    }

    public class CFOSingleStatus
    {
        public string CFO_Date { get; set; }
        public string CFO_Number { get; set; }
        public string CFO_Description { get; set; }
        public string CFO_Status { get; set; }
    }

}
