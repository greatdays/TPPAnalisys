namespace DeveloperPortal.Constants
{
    public static class WebApiConstant
    {
        // IDM Services.


        public const string GetAppUsersByRole = "api/ComConService/GetAppUsersByRole";

        public const string GetContactRender = "api/ContactMgmt/{0}/{1}/{2}/{3}/{4}/{5}";
        public const string PostContact = "api/ContactMgmt/Save";

        //public const string MakeContactObsolete = "api/ContactMgmt/MarkObsolete?contactId={0}&isObsolete={1}&userName={2}";
        public const string UpdateContactStatus = "api/ContactMgmt/ChangeStatus?contactId={0}&isVerified={1}&userName={2}";

        public const string UpdateContactMailing = "api/ContactMgmt/ContactMailing?contactId={0}&contactAddressId={1}&isMailingAddress={2}&userName={3}";
        public const string DeleteContact = "api/ContactMgmt/Delete?contactId={0}&userName={1}&projectId={2}&projectSiteId={3}";
        public const string CopyContact = "api/ContactMgmt/CopyContact?contactId={0}&userName={1}&projectId={2}&projectSiteIds={3}";
        public const string GetStreetPrefix = "api/StreetPrefix";
        public const string GetStreetSuffix = "api/StreetSuffix";
        public const string GetAPNByCase = "api/ServiceRequest/Case/{0}";
        public const string GetAPNByStructure = "api/Structure/{0}";
        public const string GetAPNByUnit = "api/Unit/{0}";
        public const string GetStructureList = "api/Structures";
        public const string GetUnitList = "api/Units";
        public const string GetSiteAddressList = "api/SiteAddresses";
        public const string GetImageInformationView = "api/ImageInformationView";
        public const string GetUserDetails = "api/Account/GetUserDetails";
        public const string DeleteAccountContact = "api/ContactMgmt/DeleteAccountContact?contactId={0}&userName={1}&sessionName={2}";
        public const string UpdateAccountContactType = "api/ContactMgmt/UpdateAccountContactType?contactId={0}&contactType={1}&organizationID={2}&userName={3}";

        public const string CheckForFileNumber = "ProjectSite/CheckForFileNumber?fileNumber={0}&userName={1}";
        public const string GetSiteAddresses = "ProjectSite/GetSiteAddresses?address={0}";
        public const string GetRolesByProjectSiteId = "ProjectSite/GetRolesByProjectSiteId?projectSiteId={0}&userName={1}";
        public const string SaveLinkProperty = "ProjectSite/SaveLinkProperty?projectSiteId={0}&userName={1}&roles={2}";
        public const string SaveUnlinkProperty = "ProjectSite/SaveLinkProperty?projectSiteId={0}&userName={1}";
        public const string UnLinkProperty = "ProjectSite/SaveLinkProperty?projectSiteId={0}&userName={1}";
        public const string GetPropertyByRefProjectSiteID = "Property/GetPropertyByRefProjectSiteID?refProjectSiteID={0}";
        public const string GetPropertyAdvancedSearchResult = "Property/PropertyAdvancedSearchResult";
        public const string GetPropertyDetails = "Property/GetPropertyDetails?FileNumber={0}";
        public const string GetContactByUserName = "Contact/GetContactByUserName?userName={0}";
        public const string GetAccountProfileDetails = "Account/GetAccountProfileDetails?username={0}";
        public const string GetMyAccountDetail = "User/MyAccountDetail";

        public const string PLReassign = "Property/PropertyListingCaseReassign";
        public const string PMPCaseReassign = "Property/PMPCaseReassign";
        public const string CheckUserAccountForAssn = "Account/CheckUserAccountForAssn";
        public const string RemoveUnlinkedPropertyContacts = "Contact/RemoveUnlinkedPropertyContacts";
        public static string GetStateList = "Property/GetStateList";
        public const string RemoveUserAccountAssn = "Account/RemoveUserAccountAssn";
        public const string CancelApplicationByUserName = "Listing/CancelApplicationByUserName";
        public const string GetAllGroupMembersForAccount = "Account/GetAllGroupMembersForAccount";
        public const string RemoveGroupMember = "Trainer/RemoveGroupMember";
    }
}
