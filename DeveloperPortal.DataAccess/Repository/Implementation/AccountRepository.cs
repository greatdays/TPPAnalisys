using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Models.IDM;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Index.HPRtree;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AAHREntities _context;

        public AccountRepository(AAHREntities context)
        {
            _context = context;
        }

        

        public async Task<List<VwPropertySearch>> GetVwPropertySearchesByFileNumberAsync(string FileNumber)
        {
            var query = _context.VwPropertySearches.AsQueryable();

            if (!string.IsNullOrEmpty(FileNumber))
                query = query.Where(v => v.FileNumber != null && v.FileNumber.ToLower().Contains(FileNumber.ToLower()));

            return await query.ToListAsync();
        }

        public async Task<List<Project>> GetProjectDetailByFileNumberAsync(string FileNumber)
        {
            var query = _context.Projects
            .Include(p => p.ProjectSites) // <-- Include the related navigation property
            .AsQueryable();

            if (!string.IsNullOrEmpty(FileNumber))
                query = query.Where(v => v.FileGroup != null && v.FileGroup.ToLower().Contains(FileNumber.ToLower()));
            return await query.ToListAsync();
        }


        public async Task<bool> CheckIsProjectExistsForCurrentUser(int projectId, int userId)
        {
            bool exists = await _context.AssnPropContacts
                .AnyAsync(x => x.ProjectId == projectId && x.ContactIdentifierId == userId);
            return exists;

        }


        public async Task<LutContactType> GetLutPropContactAssnTypes(string contactType)
        {
            var lutContactType = await _context.LutContactTypes
                                           .Where(x => x.ContactType == contactType)
                                           .FirstOrDefaultAsync();
            return lutContactType;
        }


        public async Task<ContactIdentifier> GetContactIdentifierByUserName(string userName)
        {
            var contactIdentifier = await _context.ContactIdentifiers
                                           .Where(x => x.IdmuserName == userName)
                                           .FirstOrDefaultAsync();
            return contactIdentifier;
        }

        
        public async Task<bool> AddPropContactIfNotExistsAsync(AssnPropContact contact, string userName)
        {
            // Check if record already exists
            bool exists = await _context.AssnPropContacts
                .AnyAsync(x => x.ProjectId == contact.ProjectId
                            && x.ContactIdentifierId == contact.ContactIdentifierId);

            if (exists)
                return false; // Already exists

            // Get first APN number (optimized query - only one row fetched)
            var apnNumber = await _context.PropSnapshots
                .Where(x => x.ProjectId == contact.ProjectId && x.Apn != null)
                .Select(x => x.Apn.Apn1)
                .FirstOrDefaultAsync();

            // Assign APN if available
            contact.Apn = apnNumber;

            // Insert new record
            _context.AssnPropContacts.Add(contact);
            await _context.SaveChangesWithAuditAsync(userName);

            return true;
        }




        public async Task<List<PropSnapshot>> GetPropSnapshotByProjectID(int? ProjectId)
        {
            var propSnapshots = await _context.PropSnapshots
                                .Where(x => x.ProjectId == ProjectId)
                                .Include(x => x.Apn)   // 👈 this loads the related APN navigation property
                                .ToListAsync();

            return propSnapshots;
        }
        public async Task<List<VwAspNetRole>> GetUSerRole(int? ApplicationID)
        {
            var VwApplications = await _context.VwApplications
                                .Where(x => x.AppKey == "AAHRDeveloperPortal")
                                // 👈 this loads the related APN navigation property
                                .ToListAsync();
            if (VwApplications.Any())
            {
                var VwAspNetRoles = await _context.VwAspNetRoles
                                .Where(x => x.ApplicationId == VwApplications.FirstOrDefault().ApplicationId && x.Name == "Property Developer")
                                // 👈 this loads the related APN navigation property
                                .ToListAsync();
                return VwAspNetRoles;
            }

            return null;
        }

    }
}
