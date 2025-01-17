using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace DeveloperPortal.DataAccess.Entity.EntityModels
namespace DeveloperPortal.DataAccess.Entity.Models.Generated
{
    [MetadataType(typeof(ControlViewMasterMD))]
    public partial class ControlViewMaster
    {
        public class ControlViewMasterMD
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Please Select Control Type.")]
            [Display(Name = "Control Type")]
            public int ControlId { get; set; }
            [Required(ErrorMessage = "Please Enter Name.")]
            [StringLength(50)]
            public string Name { get; set; }
            [Display(Name = "Display Name")]
            [StringLength(50)]
            public string DisplayName { get; set; }
            [StringLength(500)]
            public string Comments { get; set; }
            public Nullable<int> LinkDisplayConfigId { get; set; }
            [Display(Name = "SP Detail Display Configuration")]
            public Nullable<int> SPDetailDisplayConfigId { get; set; }
            [Display(Name = "SP Grid Display Configuration")]
            public Nullable<int> SPGridDisplayConfigId { get; set; }
            [Display(Name = "SP Matrix Display Configuration")]
            public Nullable<int> SPMatrixDisplayConfigId { get; set; }
            public Nullable<int> NewsDisplayConfigId { get; set; }
            public Nullable<int> CustomDisplayConfigId { get; set; }
            public Nullable<int> WFNavigationDisplayConfigId { get; set; }
            public Nullable<int> WFLogDisplayConfigId { get; set; }
            public string JsonConfig { get; set; }
        }

        /// <summary>
        /// Get display configuration ID based on Control name.
        /// </summary>
        /// <returns>displayConfigID</returns>
        public int GetDisplayConfigId(ControlViewMaster controlViewMaster)
        {
            int displayConfigId = 0;

            //switch (this.ControlMaster.Name)
            switch (controlViewMaster.ControlMaster.Name)
            {
                case "Links":
                    displayConfigId = null != LinkDisplayConfigId ? (int)LinkDisplayConfigId : 0;
                    break;

                case "SPDetailView":
                    displayConfigId = null != SPDetailDisplayConfigId ? (int)SPDetailDisplayConfigId : 0;
                    break;

                case "SPGridView":
                    displayConfigId = null != SPGridDisplayConfigId ? (int)SPGridDisplayConfigId : 0;
                    break;

                case "SPMatrixView":
                    displayConfigId = null != SPMatrixDisplayConfigId ? (int)SPMatrixDisplayConfigId : 0;
                    break;

                case "News":
                    displayConfigId = null != NewsDisplayConfigId ? (int)NewsDisplayConfigId : 0;
                    break;

                case "Custom":
                    displayConfigId = null != CustomDisplayConfigId ? (int)CustomDisplayConfigId : 0;
                    break;

                case "WorkflowLog":
                    displayConfigId = null != WFLogDisplayConfigId ? (int)WFLogDisplayConfigId : 0;
                    break;

                case "WorkflowNavigation":
                    displayConfigId = null != WFNavigationDisplayConfigId ? (int)WFNavigationDisplayConfigId : 0;
                    break;

                case "SPGroupView":
                    displayConfigId = null != SPGroupDisplayConfigId ? (int)SPGroupDisplayConfigId : 0;
                    break;

                case "WSGridView":
                    displayConfigId = null != WSGridViewDisplayConfigId ? (int)WSGridViewDisplayConfigId : 0;
                    break;


                case "WSDetailView":
                    displayConfigId = null != WSDetailDisplayConfigId ? (int)WSDetailDisplayConfigId : 0;
                    break;

                case "Form":
                    displayConfigId = null != Id ? (int)Id : 0;
                    break;
                case "ContactInformation":
                case "MyTeam":
                case "ActivityLogs":
                case "TimeLines":
                case "CaseAgingQueue":
                case "ImageGallery":
                case "Tiles":
                case "Document":
                    displayConfigId = !string.IsNullOrEmpty(JsonConfig) ? Id : 0;
                    break;
                default:
                    break;
            }

            return displayConfigId; //return
        }

        /// <summary>
        /// Get Display Configuration object based on Control name.
        /// </summary>
        /// <returns>
        /// Display Configuration object
        /// </returns>
        public object GetDisplayConfig(ControlViewMaster controlViewMaster)
        {
            object displayConfiguration = 0;

            //switch (this.ControlMaster.Name)
            switch (controlViewMaster.Name)
            {
                case "Links":
                    if (null != Links_DisplayConfig)
                    {
                        /* Fetch Display Configuration from db to view model */
                        LinksViewModel linksViewModel = new LinksViewModel();
                        linksViewModel.FetchDisplayConfiguration(Links_DisplayConfig);
                        /* Copy Model */
                        displayConfiguration = linksViewModel;
                    }
                    break;

                case "SPDetailView":
                    displayConfiguration = SPDetailView_DisplayConfig;
                    break;

                case "SPGridView":
                    displayConfiguration = SPGridView_DisplayConfig;
                    break;

                case "SPMatrixView":
                    displayConfiguration = SPMatrixView_DisplayConfig;
                    break;

                case "News":
                    displayConfiguration = News_DisplayConfig;
                    break;

                case "Custom":
                    displayConfiguration = Custom_DisplayConfig;
                    break;

                case "WorkflowNavigation":
                    if (null != WFNavigation_DisplayConfig)
                    {
                        /* Fetch Display Configuration from db to view model */
                        WFNavigationViewModel wfNavigationViewModel = new WFNavigationViewModel();
                        wfNavigationViewModel.FetchDisplayConfiguration(WFNavigation_DisplayConfig);
                        /* Copy Model */
                        displayConfiguration = wfNavigationViewModel;
                    }
                    break;

                case "WorkflowLog":
                    if (null != WFLog_DisplayConfig)
                    {
                        /* Fetch Display Configuration from db to view model */
                        WFLogViewModel wfLogViewModel = new WFLogViewModel();
                        wfLogViewModel.FetchDisplayConfiguration(WFNavigation_DisplayConfig);

                        /* Copy Model */
                        displayConfiguration = wfLogViewModel;
                    }
                    break;

                case "SPGroupView":
                    displayConfiguration = SPGroupView_DisplayConfig;
                    break;

                case "WSGridView":
                    displayConfiguration = WSGridView_DisplayConfig;
                    break;

                //case "WSDetailView":
                //    displayConfiguration = WSDetailView_DisplayConfig;
                //    break;
                default:
                    break;
            }

            return displayConfiguration; //return
        }
    }
}
