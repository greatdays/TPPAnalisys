using DeveloperPortal.DataAccess;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.Models;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application
{
    public class ProjectDetailService
    {
        /// <summary>
        /// GetUnitMaxtrixDetails
        /// </summary>
        /// <param name="gridRequestModel"></param>
        /// <returns></returns>
        public List<UnitDataModel> GetUnitMaxtrixDetails(GridRequestModel gridRequestModel)
        {
            var resultList = new List<UnitDataModel>();
            if(gridRequestModel==null)
            {
                return resultList;
            }

            var metrixData = uspGetUnitsForComplianceMetrix(gridRequestModel.CaseId, gridRequestModel.ProjectId).Result;
            if (metrixData != null && metrixData.Count > 0)
            {
                resultList = metrixData.Select(x => new UnitDataModel
                {
                    APNId = x.APNId,
                    SiteAddressID = x.SiteAddressID,
                    ProjectSiteId = x.ProjectSiteId,
                    ProjectId = x.ProjectId,
                    LevelId = x.LevelId,
                    BuildingId = x.BuildingId,
                    CaseId = x.CaseId,
                    ServiceRequestId = x.ServiceRequestId,
                    PropSnapshotID = x.PropSnapshotID,
                    ACHPNo = x.ACHPNo,
                    UnitID = x.UnitID,
                    UnitNum = x.UnitNum,
                    TotalBedroom = x.TotalBedroom,
                    LutTotalBedroomID = x.LutTotalBedroomID,
                    FloorPlanType = x.FloorPlanType,
                    FloorPlanTypeID = x.FloorPlanTypeID,
                    UnitType = x.UnitType,
                    LutUnitTypeID = x.LutUnitTypeID,
                    ManagersUnit = x.ManagersUnit,
                    IsCSA = x.IsCSA,
                    IsVCA = x.IsVCA,
                    AdditionalAccecibility = x.AdditionalAccecibility,
                    IsCompliant = x.IsCompliant
                }).ToList();
            }
            return resultList;
        }

        /// <summary>
        ///  SetUnitCountDetails
        /// </summary>
        /// <param name="unitModel"></param>
        /// <returns></returns>
        public TotalUnitDataModel SetUnitCountDetails(List<UnitDataModel> unitModel)
        {
            var UnitCountData = new TotalUnitDataModel();
            UnitCountData.StudioCount = unitModel.Count(x => x.TotalBedroom == "Studio");
            UnitCountData.SROCount = unitModel.Count(x => x.TotalBedroom == "SRO");
            UnitCountData.EfficiencyCount = unitModel.Count(x => x.TotalBedroom == "Efficiency");
            UnitCountData.Bedroom1Count = unitModel.Count(x => x.TotalBedroom == "1");
            UnitCountData.Bedroom2Count = unitModel.Count(x => x.TotalBedroom == "2");
            UnitCountData.Bedroom3Count = unitModel.Count(x => x.TotalBedroom == "3");
            UnitCountData.Bedroom4Count = unitModel.Count(x => x.TotalBedroom == "4");
            UnitCountData.Bedroom5Count = unitModel.Count(x => x.TotalBedroom == "5+");
            UnitCountData.ManagerUnitCount = unitModel.Count(x => x.ManagersUnit == true);
            UnitCountData.TotalCount = UnitCountData.SROCount + UnitCountData.StudioCount + UnitCountData.EfficiencyCount
                + UnitCountData.Bedroom1Count
                + UnitCountData.Bedroom2Count
                + UnitCountData.Bedroom3Count
                + UnitCountData.Bedroom4Count
                + UnitCountData.Bedroom5Count
                + UnitCountData.ManagerUnitCount;
            UnitCountData.UnitDesignatedCSACount = unitModel.Count(x => x.IsCSA == true);
            UnitCountData.UnitDesignatedVCACount = unitModel.Count(x => x.IsVCA == true);
            UnitCountData.TotalMobilityUntCount = unitModel.Count(x => x.UnitType == "Mobility");
            UnitCountData.TotalCommunicationUntCount = unitModel.Count(x => x.UnitType == "Hearing/Vision (H/V)");
            UnitCountData.TotalAdaptableUntCount = unitModel.Count() - unitModel.Count(x => x.UnitType == "Mobility" || x.UnitType == "Hearing/Vision (H/V)");
            UnitCountData.TotalCommunicationCount = Math.Round(Convert.ToDouble(UnitCountData.TotalCount) * 0.04, 2);
            UnitCountData.TotalMobilityUnitsVCACount = UnitCountData.UnitDesignatedCSACount;
            UnitCountData.TotalMobilityUnitsCSACount = UnitCountData.UnitDesignatedVCACount;
            //Percentage caalculation
            UnitCountData.TotalMobilityUnitsPer = 0;
            UnitCountData.TotalCommunicationsPer = 0;
            UnitCountData.TotalMobilityUnitsVCAPer = 0;
            UnitCountData.TotalMobilityUnitsCSAPer = 0;
            if (UnitCountData.TotalCount > 0)
            {
                UnitCountData.TotalMobilityUnitsPer = Math.Round(Convert.ToDouble(UnitCountData.TotalMobilityUntCount) / Convert.ToDouble(UnitCountData.TotalCount) * 100, 2);
                UnitCountData.TotalCommunicationsPer = Math.Round(Convert.ToDouble(UnitCountData.TotalCommunicationUntCount) / Convert.ToDouble(UnitCountData.TotalCount) * 100, 2);
                UnitCountData.TotalMobilityUnitsVCAPer = Math.Round(Convert.ToDouble(UnitCountData.TotalMobilityUnitsVCACount) / Convert.ToDouble(UnitCountData.TotalCount) * 100, 2);
                UnitCountData.TotalMobilityUnitsCSAPer = Math.Round(Convert.ToDouble(UnitCountData.TotalMobilityUnitsCSACount) / Convert.ToDouble(UnitCountData.TotalCount) * 100, 2);
            }
            return UnitCountData;
        }

        /// <summary>
        /// Get all construction cases to be displayed on the dashboard
        /// </summary>
        /// <returns>List</returns>
        private async Task<List<uspGetUnitsForComplianceMetrixResult>> uspGetUnitsForComplianceMetrix(int caseId, int projectId)
        {
            AahrdevContext context = new AahrdevContext();
            List<uspGetUnitsForComplianceMetrixResult> result = await context.uspGetUnitsForComplianceMetrix(caseId, projectId);
            return result;
        }
    }
}
