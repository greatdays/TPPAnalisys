using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.Models.Helper.ComCon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DeveloperPortal.DataAccess.Entity.ViewModels.ComCon
{
    public class ContactDisplayConfig
    {
        public ContactDisplayConfig()
        {
                
        }

        [Display(Name = "Application")]
        [Required(ErrorMessage = "Please select application.")]
        public int ApplicationId { get; set; }

        public List<ApplicationMaster> ApplicationMasters { get; set; }
        public int ContactDisplayConfigId { get; set; }
        public int ControViewlId { get; set; }// This is control Id

        [Display(Name = "Control Name")]
        public string ControlName { get; set; }

        [Display(Name = "Context Type")]
        public string ContextType { get; set; }

        [Display(Name = "Context Refernce Type")]
        public string ContextRefType { get; set; }

        [Display(Name = "Context Parameter")]
        [Required(ErrorMessage = "Please enter parameter.")]
        public string ContextParameter { get; set; }

        [Display(Name = "Data Filter Type")]
        public List<string> DataFilterType { get; set; }

        public List<SelectListModel> DataFilterTypeList { get; set; }

        [Display(Name = "Data Filter Source")]
        public List<string> DataFilterSource { get; set; }

        public List<SelectListModel> DataFilterSourceList { get; set; }

        [Display(Name = "Is History?")]
        public bool IsHistory { get; set; }

        [Display(Name = "Is Search?")]
        public bool IsSearch { get; set; }

        [Display(Name = "Is Add?")]
        public bool IsAdd { get; set; }

        [Display(Name = "Roles to Access Add Feature")]
        public List<string> AddRoleList { get; set; }

        [Display(Name = "Is User Filter?")]
        public bool IsUserFilter { get; set; }

        [Display(Name = "Roles to Access User Filter feature")]
        public List<string> UserFilterRoleList { get; set; }

        [Display(Name = "Is Action Menu?")]
        public bool IsActionMenu { get; set; }

        [Display(Name = "Is Edit Action?")]
        public bool IsEditAction { get; set; }

        [Display(Name = "Display Name")]
        public string EditActionDisplayName { get; set; }

        [Display(Name = "Is Delete Action?")]
        public bool IsDeleteAction { get; set; }

        [Display(Name = "Display Name")]
        public string DeleteActionDisplayName { get; set; }

        [Display(Name = "Is Copy Action?")]
        public bool IsCopyContactAction { get; set; }

        [Display(Name = "Display Name")]
        public string CopyContactActionDisplayName { get; set; }

        [Display(Name = "Copy Contact To")]
        public string CopyContactTo { get; set; }

        [Display(Name = "Is Toolbar")]
        public bool IsToolBar { get; set; }

        [Display(Name = "Mark Obsolete?")]
        public bool IsMarkObsolete { get; set; }

        [Display(Name = "Roles to Access Mark Obsolete feature")]
        public List<string> MarkObsoleteRoleList { get; set; }

        [Display(Name = "Tooltip")]
        public string MarkObsoleteTooltip { get; set; }

        [Display(Name = "Mark Valid or Preferred Mailing")]
        public bool IsMarkValid { get; set; }

        [Display(Name = "Roles to Access Mark Valid or Preferred Mailing feature")]
        public List<string> MarkValidRoleList { get; set; }

        [Display(Name = "Tooltip")]
        public string MarkValidTooltip { get; set; }

        [Display(Name = "Mark Invalid or Returned Mail")]
        public bool IsMarkInValid { get; set; }

        [Display(Name = "Roles to Access Mark Invalid or Returned Mail feature")]
        public List<string> MarkInValidRoleList { get; set; }

        [Display(Name = "Tooltip")]
        public string MarkInValidTooltip { get; set; }

        [Display(Name = "Mark Mail Forwarding")]
        public bool IsMarkMailForwarding { get; set; }

        [Display(Name = "Roles to Access Mark Mail Forwarding feature")]
        public List<string> MarkMailForwardingRoleList { get; set; }

        [Display(Name = "Tooltip")]
        public string MarkMailForwardingTooltip { get; set; }

        [Display(Name = "Left Panel Field 1")]
        public string CardViewLeftPanelField1 { get; set; }

        [Display(Name = "Left Panel Field 2")]
        public string CardViewLeftPanelField2 { get; set; }

        [Display(Name = "Left Panel Field 3")]
        public string CardViewLeftPanelField3 { get; set; }

        public List<ExtraFields> CardViewLeftPanelFieldList { get; set; }

        [Display(Name = "Right Panel Field 1")]
        public string CardViewRightPanelField1 { get; set; }

        [Display(Name = "Right Panel Field 2")]
        public string CardViewRightPanelField2 { get; set; }

        [Display(Name = "Right Panel Field 3")]
        public string CardViewRightPanelField3 { get; set; }

        [Display(Name = "Right Panel Field 4")]
        public string CardViewRightPanelField4 { get; set; }

        [Display(Name = "Right Panel Field 5")]
        public string CardViewRightPanelField5 { get; set; }

        public List<ExtraFields> CardViewRightPanelFieldList { get; set; }
        public List<SelectListModel> LeftPanelList { get; set; }
        public List<SelectListModel> RightPanelList { get; set; }
        public string LeftFields { get; set; }
        public string RightFields { get; set; }
        public List<SelectListItem> RoleMasters { get; set; }
        public List<ContactRenderModel> ContactRender { get; set; }

        [Display(Name = "Contact type while adding contact")]
        public List<string> ContactType { get; set; }

        public string ContextRefId { get; set; }

        [Display(Name = "Is Address Verification Required?")]
        public bool IsAddressVerification { get; set; }

        [Display(Name = "Address Verification Service URL")]
        public string AddressVerificationServiceAPI { get; set; }

        [Display(Name = "Is Pagination?")]
        public bool IsPagination { get; set; }

        [Display(Name = "Page Size")]
        public int PageSize { get; set; }

        public string APN { get; set; }

        public int TabId { get; set; }
        public string RenderSection { get; set; }
        public int ControlMasterId { get; set; }
        public int TabControlViewMapId { get; set; }
        public string DisplayName { get; set; }
        public SelectList RoleList { get; set; }

        [Display(Name = "Access Roles")]
        public int[] SelectedRole { get; set; }

        public int ViewOrder { get; set; }
        public int? ProjectId { get; set; }
        public int? ProjectSiteId { get; set; }
        public List<string> ValidateContactType { get; set; }
    }

    public class ExtraFields
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
