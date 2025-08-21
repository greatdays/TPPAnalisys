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

        public async Task<bool> AddPropContactIfNotExistsAsync(AssnPropContact contact, string userName)
        {
            bool exists = await _context.AssnPropContacts
                .AnyAsync(x => x.ProjectId == contact.ProjectId
                            && x.ContactIdentifierId == contact.ContactIdentifierId);

            try
            {
                if (!exists)
                {
                    _context.AssnPropContacts.Add(contact);
                    await _context.SaveChangesWithAuditAsync(userName);
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }    
            

            return false; // Already exists
        }


    }
}
