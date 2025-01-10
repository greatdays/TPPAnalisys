using DeveloperPortal.DataAccess.Entity.EntityModels.IDM;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.Models.IDM;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.ViewModel
{
    public class WFNavigationViewModel
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _config;

        public WFNavigationViewModel(IConfiguration configuration)
        {
            _config = configuration;
        }
        #region Members

        public string NavigationStyle { get; set; }
        public bool isNoStateWorkflow { get; set; }
        public string CurrentState { get; set; }
        public bool isFavourite { get; set; }
        public bool isFavouriteProperty { get; set; }
        public bool hideActionButton { get; set; }
        public List<NavigationItem> NavigationItems { get; set; }
        public List<PropertySiteModel> ProjectSiteModel { get; set; }

        #endregion //Members

        /// <summary>
        /// Default constructor.
        /// </summary>
        public WFNavigationViewModel()
        {
            this.NavigationItems = new List<NavigationItem>();
        }

        public WFNavigationViewModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Constructor for rendering navigation Control with particular state with bulk actions
        /// </summary>
        /// <param name="navigationControl">Navigation Control Name</param>
        /// <param name="state">state of case</param>
        public WFNavigationViewModel(string navigationControl, string state)
        {
            ControlViewModel controlViewModel = new ControlViewModel(_config);
            ControlViewModel controlView = controlViewModel.GetControlViewModel(navigationControl);

            WFNavigationViewModel wfNavigationViewModel = (WFNavigationViewModel)controlView.ControlDisplayConfig;

            this.NavigationStyle = wfNavigationViewModel.NavigationStyle;
            this.isNoStateWorkflow = wfNavigationViewModel.isNoStateWorkflow;
            this.NavigationItems = wfNavigationViewModel.NavigationItems;

            this.CurrentState = state;
            this.NavigationItems = this.NavigationItems
                                    .Where(m => m.IsBulk && ((m.SourceState == this.CurrentState)
                                    || (null == m.SourceState && null == m.DestinationState))
                                    )
                                    .ToList();

            /* Apply Case condition if any */
            var navigationItems = this.NavigationItems.Where(m => m.Condition != null);
            foreach (var navigationItem in navigationItems)
            {
                ApplyCaseCondition(navigationItem);
            }

            /* Update list after applying condtion */
            this.NavigationItems = this.NavigationItems
                                    .Where(m => m.IsRemove != true)
                                    .ToList();
        }

        /// <summary>
        /// Fetch Display configuration from database table supplied and copy/parse it to View Model.
        /// </summary>
        /// <param name="displayConfiguration"></param>
        public void FetchDisplayConfiguration(WFNavigation_DisplayConfig displayConfiguration)
        {
            /* Copy Navigation Attributes */
            this.NavigationStyle = displayConfiguration.NavigationStyle;

            /* Check if Workflow is no state */
            if (0 == displayConfiguration.WF_Definition.WF_State.Count)
            {
                this.isNoStateWorkflow = true;
            }
            else
            {
                this.isNoStateWorkflow = false;
            }

            /* Fetch user roles from session */
            UserSession userSession = new UserSession(_httpContextAccessor);
            List<string> rolesFromSession = userSession.GetUserSession().Roles;

            /* Fetch Actions */
            var actions = displayConfiguration.WF_Definition.WF_Action
                            .Where(m => m.IsVisible == true && m.IsDeleted == false)
                            .OrderBy(m => m.ViewOrder);

            /* Fetch Navigation Items */
            foreach (WF_Action action in actions)
            {
                /* Apply Role */
                if (0 != action.RoleMasters1.Count && rolesFromSession != null)
                {
                    /* if current role is not permiited, move to next action */
                    if (false == action.RoleMasters1.Select(r => r.Name.Trim()).Any
                            (role => rolesFromSession.Contains(role.Trim())))
                    {
                        continue;
                    }
                }

                /* Create a navigation item */
                NavigationItem navigationItem = new NavigationItem(action);

                /* Add to list */
                this.NavigationItems.Add(navigationItem);
            }
        } //public void FetchDisplayConfiguration(WFNavigation_DisplayConfig displayConfiguration)

        /// <summary>
        /// Fetch Parameter values from Application context
        /// </summary>
        /// <param name="id">Case ID</param>
        public void FetchParameterValues(string id)
        {
            /* If it is not a No State workflow, fetch current state and actions */
            if (!this.isNoStateWorkflow && !string.IsNullOrEmpty(id))
            {
                /* Get Case */
                Case currentCase = Case.GetCase(id);

                /* Fetch State and filter based on it */
                this.CurrentState = currentCase.Status;

                // Combine filtering and removal of invalid items in one step
                this.NavigationItems = this.NavigationItems
                    .Where(m => !m.IsBulk &&
                                ((m.SourceState == this.CurrentState) ||
                                (m.SourceState == null && m.DestinationState == null)))
                    .ToList();

                /* Apply Case condition if any */
                foreach (var navigationItem in this.NavigationItems.Where(m => m.Condition != null))
                {
                    ApplyCaseCondition(navigationItem, currentCase);
                }
            }
            else
            {
                /* No State Workflow or Empty ID: Fetch all navigation items and apply conditions */
                this.NavigationItems = this.NavigationItems.ToList();

                /* Apply Case condition if any */
                foreach (var navigationItem in this.NavigationItems.Where(m => m.Condition != null))
                {
                    ApplyCaseCondition(navigationItem);
                }
            }


            /* Update list after applying condtion */
            this.NavigationItems = this.NavigationItems
                                    .Where(m => m.IsRemove != true)
                                    .ToList();
        }

        private void ApplyCaseCondition(NavigationItem navigationItem, Case currentCase = null)
        {
            string assigneeID = currentCase != null ? currentCase.AssigneeID : string.Empty;
            UserSession userSession = new UserSession(_httpContextAccessor);

            switch (navigationItem.Condition.Trim())
            {
                case "Assignee Only":
                    if (!string.IsNullOrEmpty(assigneeID) && assigneeID != userSession.GetUserSession().UserName)
                    {
                        /* Mark action to remove */
                        navigationItem.IsRemove = true;

                    }
                    break;

                case "Assignee & Other Role":
                    if (!string.IsNullOrEmpty(assigneeID) && assigneeID != userSession.GetUserSession().UserName)
                    {
                        ApplicationUser applicationUser = new ApplicationUser();
                        var assigneeRoles = applicationUser.GetUser(assigneeID).Roles;
                        var userRoles = userSession.GetUserSession().Roles;

                        if (true == userRoles.All(role => assigneeRoles.Contains(role)))
                        {
                            /* Mark action to remove */
                            navigationItem.IsRemove = true;
                        }
                    }
                    break;
                case "Creator Only":
                    //if (currentCase.CreatedBy != UserSession.GetUserSession().UserID)
                    //{
                    //    navigationItem.IsRemove = true;
                    //}
                    break;
                case "Role Only":
                    {
                        var userRoles = userSession.GetUserSession().Roles;
                        var roles = navigationItem.ConditionParam.Split(',');
                        if (!userRoles.Any(role => roles.Contains(role)))
                        {
                            /* Mark action to remove */
                            navigationItem.IsRemove = true;
                        }
                    }
                    break;
                case "Assignee or Roles":
                    {
                        var userRoles = userSession.GetUserSession().Roles;
                        var roles = navigationItem.ConditionParam.Split(',');

                        if (assigneeID == userSession.GetUserSession().UserName || userRoles.All(role => roles.Contains(role)))
                        {
                            // to do
                        }
                        else
                        {
                            navigationItem.IsRemove = true;
                        }
                    }
                    break;
                default:
                    /* Do nothing */
                    break;
            }
        }

        #region Navigation Item Class

        public class NavigationItem
        {
            public string ActionName { get; set; }
            public string DisplayName { get; set; }
            public string SourceState { get; set; }
            public string DestinationState { get; set; }
            public string Area { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
            public string Parameters { get; set; }
            public string Condition { get; set; }
            public string ConditionParam { get; set; }
            public bool IsRemove { get; set; }
            public bool IsBulk { get; set; }
            public bool IsAuto { get; set; }
            public bool? IsWindow { get; set; }
            public Nullable<int> FormId { get; set; }

            /// <summary>
            /// Constructor to initialize based on Action.
            /// </summary>
            /// <param name="action"></param>
            public NavigationItem(WF_Action action)
            {
                /* Copy Action Name */
                this.ActionName = action.Name;
                this.DisplayName = false == string.IsNullOrEmpty(action.DisplayName) ? action.DisplayName : action.Name;

                /* Copy state Name */
                this.SourceState = null != action.WF_State1 ? action.WF_State1.Name : null;
                this.DestinationState = null != action.WF_State ? action.WF_State.Name : null;

                /* Copy condition */
                this.Condition = null != action.WF_CaseCondition
                                ? action.WF_CaseCondition.Condition : null;

                /* Copy condition Param */
                this.ConditionParam = null != action.CaseConditionParam
                                ? action.CaseConditionParam : null;

                this.IsBulk = action.IsBulk.HasValue ? action.IsBulk.Value : false;
                this.IsAuto = (action.WF_State == null) ? false : action.WF_State.IsAuto;
                this.FormId = null != action.WF_ActionView ? action.WF_ActionView.FormId : null;

                /* Copy Action & View information */
                if (null != action.WF_ActionView)
                {
                    this.Area = action.WF_ActionView.Area;
                    this.Controller = action.WF_ActionView.Controller;
                    this.Action = action.WF_ActionView.Action;
                    this.IsWindow = action.WF_ActionView.IsWindow;
                    this.Parameters = action.WF_ActionView.Parameters;
                }
            }
        }

        #endregion Navigation Item Class
    }

    public class PropertySiteModel
    {
        public string AcHPFileSiteNumber { get; set; }
        public string SiteAddress { get; set; }
        public string OwnerCompanyName { get; set; }
        public string PMName { get; set; }
        public bool IsCASPReportAvailable { get; set; }
        public bool IsSelected { get; set; }
        public int CaseTypeID { get; set; }
        public string CaseType { get; set; }

        public int ProjectSiteID { get; set; }
        public int RefProjectSiteID { get; set; }
        public int ProjectID { get; set; }
        public int? SiteAddressID { get; set; }
        public int? LutProjectSiteStatusID { get; set; }
        public string PrimaryAPN { get; set; }
        public string HIMSNumber { get; set; }
        public int? HIMSProjUniqueId { get; set; }
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public int? NeighborhoodID { get; set; }
        public string NeighborhoodName { get; set; }
        public string CouncilDistrict { get; set; }
        public string Source { get; set; }
        public int? SourceRefID { get; set; }
        public string Status { get; set; }
        public string Attributes { get; set; }
        public bool IsDeleted { get; set; }

        public bool? IsCovered { get; set; }
        public int? TotalSiteUnit { get; set; }
        public int? MobilityUnit { get; set; }
        public int? SensoryUnit { get; set; }
        public decimal? MobilityRatio { get; set; }
        public decimal? HVRatio { get; set; }
        public string CESType { get; set; }
        public string PropertyName { get; set; }

        public int PropSnapShotID { get; set; }
        public string Buildings { get; set; }
        public string Units { get; set; }
        public string NumberOfViolations { get; set; }

        public string HousingRegistryStatus { get; set; }

        public bool? IsAccessible { get; set; }
        public bool? IsAffordable { get; set; }
        public bool? IsAccessibleAffordable { get; set; }
        public bool? IsCheck { get; set; }
    }

    public class FavouriteProperty
    {
        public int PropertySnapShotID { get; set; }
        public string UserName { get; set; }

    }
}
