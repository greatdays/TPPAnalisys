using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Application.PropertySnapshot;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Models.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class ContactIdentifiersService : IContactIdentifiersService
    {

        /// <summary>
        /// Save Contact
        /// </summary>
        /// <param name="contactIdentifierMdl"></param>
        /// <returns></returns>
        public async Task<int> SaveContact(ContactIdentifierModel contactRenderModel)
        {
            int ContactIdentifierID = 0;
            //using (PropertySnapshotEntities _dbContext = new PropertySnapshotEntities())
            //{
            //    ContactIdentifier contact = new ContactIdentifier();
            //    AssnOrganizationContact contactOrganization = new AssnOrganizationContact();
            //    List<AssnPropContact> popContacts = new List<AssnPropContact>();

            //    //Add Contact
            //    contact.ContactID = contactRenderModel.ContactID;
            //    contact.FirstName = contactRenderModel.FirstName.Trim();
            //    contact.MiddleName = !string.IsNullOrEmpty(contactRenderModel.MiddleName) ? contactRenderModel.MiddleName.Trim() : null;
            //    contact.LastName = contactRenderModel.LastName.Trim();
            //    contact.Email = contactRenderModel.Email != null ? contactRenderModel.Email.Trim() : null;
            //    contact.Source = !string.IsNullOrEmpty(contactRenderModel.Source) ? contactRenderModel.Source : "Staff";
            //    contact.IDMUserName = contactRenderModel.IDMUserName;
            //    contact.IsEmployee = contactRenderModel.IsEmployee;
            //    contact.Title = contactRenderModel.Title;
            //    contact.PreferredContactMethod = contactRenderModel.PreferredContactMethod;
            //    contact.BirthDay = contactRenderModel.BirthDay;
            //    contact.BirthMonth = contactRenderModel.BirthMonth;
            //    contact.BirthYear = contactRenderModel.BirthYear;
            //    contact.IsPrimary = contactRenderModel.IsPrimary;

            //    //To add Contractor Type in Attribute column
            //    if (contactRenderModel.ContractorType == "" || contactRenderModel.ContractorType == null)
            //    {
            //        contact.Attributes = !string.IsNullOrEmpty(contactRenderModel.ContactAttribute)
            //                              ? contactRenderModel.ContactAttribute
            //                              : "{" + "\"In\"" + ":" + "\"Office\"" + "}";
            //    }
            //    else
            //    {
            //        contact.Attributes = !string.IsNullOrEmpty(contactRenderModel.ContactAttribute)
            //                            ? contactRenderModel.ContactAttribute
            //                            : "{" + "\"In\"" + ":" + "\"Office\"" + "," + "\"ContractorType\"" + ":" + "\"" + contactRenderModel.ContractorType + "\"" + " }";
            //    }

            //    #region AAHP-2385 add CASpNumber
            //    if (!string.IsNullOrEmpty(contactRenderModel.CASpNumber))
            //    {
            //        JObject result = JObject.Parse(contact.Attributes);

            //        if (result["CASp"] == null)// if property not present then add property to the json 
            //        {
            //            result.Add(new JProperty("CASp", contactRenderModel.CASpNumber));
            //        }
            //        else
            //        {
            //            result["CASp"] = contactRenderModel.CASpNumber;
            //        }

            //        contact.Attributes = result.ToString();
            //    }


            //    #endregion //AAHP-2385 add CASpNumber



            //    contact.LutPhoneTypeCd = contactRenderModel.LutPhoneTypeCd;
            //    contact.PhoneHome = contactRenderModel.HomePhoneNumber;
            //    contact.PhoneWork = contactRenderModel.BusinessPhoneNumber;
            //    contact.PhoneMobile = contactRenderModel.MobilePhoneNumber;
            //    contact.PhoneExtension = contactRenderModel.PhoneExtension?.Trim();
            //    contact.HouseNum = contactRenderModel.HouseNum;
            //    contact.HouseFracNum = contactRenderModel.HouseFracNum;
            //    contact.PreDirCd = contactRenderModel.PreDirCd;
            //    contact.StreetName = contactRenderModel.StreetName;
            //    contact.StreetTypeCd = contactRenderModel.StreetTypeCd;
            //    contact.PostDirCd = contactRenderModel.PostDirCd;
            //    contact.City = contactRenderModel.City;
            //    contact.State = contactRenderModel.State;
            //    contact.Zip = contactRenderModel.Zip;
            //    contact.UnitNo = contactRenderModel.Unit;
            //    contact.IsMailingAddress = contactRenderModel.IsMarkedForMailing;
            //    contact.Source = !string.IsNullOrEmpty(contactRenderModel.Source) ? contactRenderModel.Source : "Staff";
            //    contact.ContactType = contactRenderModel.ContactTypeName;

            //    /*If Company is blank/null then escape add/update for organisation*/
            //    if (!string.IsNullOrEmpty(contactRenderModel.Company))
            //    {
            //        if (contactOrganization == null || contactOrganization.OrganizationID == 0)
            //        {
            //            var organization = _dbContext.Organizations.Where(x => x.Name == contactRenderModel.Company && x.IsDeleted == false).FirstOrDefault();

            //            if (organization == null)
            //            {
            //                organization = new Organization
            //                {
            //                    Name = contactRenderModel.Company,
            //                    IsDeleted = false,
            //                    IsReviewRequired = false
            //                };

            //                _dbContext.Organizations.Add(organization);
            //                _dbContext.SaveChanges(contactRenderModel.UserName);
            //            }
            //            contactOrganization = new AssnOrganizationContact
            //            {
            //                OrganizationID = organization.OrganizationID,
            //                AssociationType = "Full Time",
            //                AssociatedFrom = DateTime.Now.AddYears(-2),
            //                AssociatedTo = DateTime.Now,
            //                IsReviewRequired = false,
            //                IsDeleted = false,
            //                Source = contactRenderModel.Source
            //            };
            //            contact.AssnOrganizationContacts.Add(contactOrganization);
            //        }
            //        else
            //        {
            //            contactOrganization.Organization.Name = contactRenderModel.Company;
            //        }
            //    }

            //    string[] contactTypes = !string.IsNullOrEmpty(contactRenderModel.ContactTypeName) ? contactRenderModel.ContactTypeName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : new string[0];
            //    string[] primaryAssociations = !string.IsNullOrEmpty(contactRenderModel.PrimaryTypes) ? contactRenderModel.PrimaryTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : new string[0];
            //    var lutPropContact = _dbContext.LutContactTypes
            //                                    .Where(x => contactTypes.Contains(x.ContactType) && x.IsObsolete == false)
            //                                    .ToList();

            //    var removedPC = popContacts.Where(x => !contactTypes.Contains(x.LutContactType.ContactType)).ToList();
            //    foreach (var pc in removedPC)
            //    {
            //        _dbContext.AssnPropContacts.Remove(pc);
            //        popContacts.Remove(pc);
            //    }

            //    int projectId = 0;
            //    int projectSiteId = 0;
            //    foreach (var lpc in lutPropContact)
            //    {
            //        var APC = popContacts.FirstOrDefault(x => x.LutContactTypeID == lpc.LutContactTypeID);
            //        if (APC == null)
            //        {
            //            APC = new AssnPropContact();
            //            APC.IdentifierType = contactRenderModel.IdentifierType;
            //        }

            //        //Add Association
            //        APC.IsPrimaryAssnType = primaryAssociations.Contains(lpc.ContactType);
            //        APC.LutContactTypeID = lpc.LutContactTypeID;
            //        APC.Source = contactRenderModel.Source;

            //        if (contactRenderModel.IdentifierType == "APN")
            //        {
            //            APC.APN = contactRenderModel.IdentifierValue;
            //        }
            //        else if (contactRenderModel.IdentifierType == "Structure")
            //        {
            //            var StructureID = Convert.ToInt32(contactRenderModel.IdentifierValue);
            //            APC.StructureID = _dbContext.Structures.FirstOrDefault(x => x.RefBuildingID == StructureID)?.StructureID;
            //            APC.APN = contactRenderModel.APN;
            //        }
            //        else if (contactRenderModel.IdentifierType == "Unit")
            //        {
            //            var UnitID = Convert.ToInt32(contactRenderModel.IdentifierValue);
            //            APC.UnitID = _dbContext.Units.FirstOrDefault(x => x.RefUnitID == UnitID)?.UnitID;
            //            APC.APN = contactRenderModel.APN;
            //        }
            //        else if (contactRenderModel.IdentifierType == "Project")
            //        {
            //            var Project = _dbContext.Projects.FirstOrDefault(x => x.RefProjectID == contactRenderModel.ProjectId);
            //            APC.ProjectID = Project?.ProjectID;
            //            APC.APN = Project?.ProjectSites?.FirstOrDefault()?.PrimaryAPN;
            //            projectId = Convert.ToInt32(Project?.ProjectID);
            //        }
            //        else if (contactRenderModel.IdentifierType == "ProjectSite")
            //        {
            //            var ProjectSite = _dbContext.ProjectSites.FirstOrDefault(x => x.RefProjectSiteID == contactRenderModel.ProjectSiteID);
            //            APC.ProjectID = ProjectSite?.ProjectID;
            //            APC.APN = ProjectSite?.PrimaryAPN;
            //            APC.ProjectSiteID = ProjectSite?.ProjectSiteID;
            //            projectSiteId = Convert.ToInt32(ProjectSite?.ProjectSiteID);
            //        }

            //        if (contactRenderModel.IdentifierType == "Address")
            //        {
            //            int siteAddressId = Convert.ToInt32(contactRenderModel.IdentifierValue);
            //            SiteAddress siteAddresse = _dbContext.SiteAddresses.FirstOrDefault(x => x.RefSiteAddressID == siteAddressId);
            //            if (siteAddresse != null)
            //            {
            //                APC.IdentifierType = contactRenderModel.IdentifierType;
            //                APC.APN = siteAddresse.APNs?.FirstOrDefault()?.APN1;
            //                APC.SiteAddressID = siteAddresse.SiteAddressID;
            //            }
            //        }
            //        // AAHP-4367 : Contact information to be displayed on the Registry for the public
            //        APC.IsContactPublic = Convert.ToBoolean(contactRenderModel.IsContactPublic);

            //        contact.AssnPropContacts.Add(APC);

            //        #region ServiceRequestContact
            //        ServiceRequestContact serviceRequestContact = contact.ServiceRequestContacts
            //        .FirstOrDefault(m => m.ServiceRequestID == contactRenderModel.ServiceRequestID && m.LutContactTypeID == lpc.LutContactTypeID);

            //        if (serviceRequestContact == null && contactRenderModel.ServiceRequestID > 0)
            //        {
            //            serviceRequestContact = new ServiceRequestContact
            //            {
            //                ServiceRequestID = contactRenderModel.ServiceRequestID,
            //                LutContactTypeID = lpc.LutContactTypeID,
            //                ContactIdentifierID = ContactIdentifierID
            //            };

            //            contact.ServiceRequestContacts.Add(serviceRequestContact);
            //        }
            //        #endregion ServiceRequestContact
            //    }

            //    // save contact
            //    if (contactRenderModel.ContactIdentifierID == 0)
            //    {
            //        _dbContext.ContactIdentifiers.Add(contact);
            //    }
            //    _dbContext.SaveChanges(contactRenderModel.UserName);
            //    ContactIdentifierID = contact.ContactIdentifierID;

            //    #region Update IsPrimaryAssnType false if selected contact and property other contacts have same ContactType with IsPrimaryAssnType true
            //    if (lutPropContact.Count() > 0 && contactRenderModel.IdentifierType == "Project")
            //    {
            //        var primaryContactAPCExcept = _dbContext.AssnPropContacts.Where(x => x.ProjectID == projectId && primaryAssociations.Any(y => y == x.LutContactType.ContactType) && x.IsPrimaryAssnType == true && x.ContactIdentifierID != ContactIdentifierID).ToList();
            //        foreach (var item in primaryContactAPCExcept)
            //        {
            //            item.IsPrimaryAssnType = false;
            //            _dbContext.Entry(item).State = EntityState.Modified;
            //            _dbContext.SaveChanges(contactRenderModel.UserName);
            //        }
            //    }
            //    else if (lutPropContact.Count() > 0 && contactRenderModel.IdentifierType == "ProjectSite")
            //    {
            //        var primaryContactAPCExcept = _dbContext.AssnPropContacts.Where(x => x.ProjectSiteID == projectSiteId && primaryAssociations.Any(y => y == x.LutContactType.ContactType) && x.IsPrimaryAssnType == true && x.ContactIdentifierID != ContactIdentifierID).ToList();
            //        foreach (var item in primaryContactAPCExcept)
            //        {
            //            item.IsPrimaryAssnType = false;
            //            _dbContext.Entry(item).State = EntityState.Modified;
            //            _dbContext.SaveChanges(contactRenderModel.UserName);
            //        }
            //    }
            //    #endregion Update IsPrimaryAssnType false if selected contact and property other contacts have same ContactType with IsPrimaryAssnType true

            //    #region AAHP-4367 : Update IsContactPublic as false for all contacts except latest contact
            //    if (contactRenderModel.IsContactPublic == true)
            //    {
            //        var contactToPublicList = _dbContext.AssnPropContacts.Where(x => x.APN == contactRenderModel.APN && x.IsDeleted == false && x.IsContactPublic == true && x.ContactIdentifierID != ContactIdentifierID).ToList();
            //        if (contactToPublicList != null)
            //        {
            //            foreach (var item in contactToPublicList)
            //            {
            //                item.IsContactPublic = false;
            //                _dbContext.Entry(item).State = EntityState.Modified;
            //                _dbContext.SaveChanges(contactRenderModel.UserName);
            //            }
            //        }
            //    }
            //    #endregion

            //}
            return ContactIdentifierID;
        }
    }
}
