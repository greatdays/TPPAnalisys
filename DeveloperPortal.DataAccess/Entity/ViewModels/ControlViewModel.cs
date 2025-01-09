using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.ViewModel
{
    public class ControlViewModel : ActionViewModel
    {
        public string ControlName { get; set; }
        public string ControlDescription { get; set; }
        public string ControlRenderURL { get; set; }
        public int ControlViewId { get; set; }
        public string ViewTitle { get; set; }
        public string ViewComments { get; set; }
        public int ControlDisplayConfigId { get; set; }
        public object ControlDisplayConfig { get; set; }

        public int ControlGroupConfigId { get; set; }
        public object ControlGroupConfig { get; set; }

        public string RenderAction { get; set; }
        public string RenderController { get; set; }
        public string RenderArea { get; set; }
        public string JsonConfig { get; set; }
        public List<RoleMaster> ControlRoles { get; set; }
        /// <summary>
        /// Function to fetch control view master list for tab
        /// </summary>
        /// <param name="renderSection"></param>
        /// <param name="tabInfo"></param>
        /// <returns></returns>
        internal static List<ControlViewModel> FetchControlViewList(string renderSection, TabMaster tabInfo)
        {
            List<ControlViewModel> controlViewModelList = new List<ControlViewModel>();
            /* Get views based on role and render section */
            var controlViewsInfo = tabInfo.TabControlViewMaps
                                    .Where(m => m.RenderSection == renderSection)
                                    .OrderBy(m => m.ViewOrder)
                                    .Select(m => new { ControlViews = m.ControlViewMaster, Roles = m.RoleMasters })
                                    .ToList();

            foreach (var controlView in controlViewsInfo)
            {
                /* Create new model */
                ControlViewModel controlViewModel = new ControlViewModel();
                controlViewModel.Populate(controlView.ControlViews, controlView.Roles?.ToList());

                /* Add model to list */
                controlViewModelList.Add(controlViewModel);
            }

            return controlViewModelList;
        }

        /// <summary>
        /// Populate Controlview master 
        /// </summary>
        /// <param name="controlView"></param>
        public void Populate(ControlViewMaster controlView, List<RoleMaster> Roles)
        {
            this.ControlViewId = controlView.Id;
            this.ControlDisplayConfigId = controlView.GetDisplayConfigId();
            this.ControlDisplayConfig = controlView.GetDisplayConfig();
            this.ControlGroupConfigId = controlView.GetDisplayConfigId();
            this.ControlGroupConfig = controlView.GetDisplayConfig();
            this.ViewTitle = controlView.DisplayName ?? controlView.Name;
            this.ControlName = controlView.ControlMaster.Name;
            this.ControlRenderURL = controlView.ControlMaster.RenderAction;
            this.ControlDescription = controlView.ControlMaster.Description;
            this.ViewComments = controlView.Comments;
            this.JsonConfig = controlView.JsonConfig;
            // Split Render Url
            if (!string.IsNullOrEmpty(ControlRenderURL))
            {
                string[] url = ControlRenderURL.Split('/');
                switch (url.Length)
                {
                    case 2:
                        this.RenderController = url[0];
                        this.RenderAction = url[1];
                        break;
                    case 3:
                        this.RenderArea = url[0];
                        this.RenderController = url[1];
                        this.RenderAction = url[2];
                        break;
                    default:
                        break;
                }
                if (url.Length > 1)
                {
                }
            }

            this.ControlRoles = Roles;
        }

        /// <summary>
        /// Get control view model by Control view master name
        /// </summary>
        /// <param name="controlViewMasterName">Control view master name</param>
        /// <returns>Control view model</returns>
        public static ControlViewModel GetControlViewModel(string controlViewMasterName)
        {
            using (var comconDB = new AAHREntities())
            {
                ControlViewMaster controlView = comconDB.ControlViewMasters.FirstOrDefault(m => m.Name == controlViewMasterName);
                ControlViewModel controlViewModel = new ControlViewModel();

                if (controlView != null)
                {
                    controlViewModel.Populate(controlView, null);
                }

                return controlViewModel;
            }
        }

        /// <summary>
        /// Get control view model by Control view  master Id
        /// </summary>
        /// <param name="controlViewMasterName">Control view master name</param>
        /// <returns>Control view model</returns>
        public static ControlViewModel GetControlViewModelById(int controlViewModelId)
        {
            using (var comconDB = new AAHREntities())
            {
                ControlViewMaster controlView = comconDB.ControlViewMasters.FirstOrDefault(m => m.Id == controlViewModelId);
                ControlViewModel controlViewModel = new ControlViewModel();
                if (controlView != null)
                {
                    controlViewModel.Populate(controlView, null);
                }

                return controlViewModel;
            }
        }


    }
}
