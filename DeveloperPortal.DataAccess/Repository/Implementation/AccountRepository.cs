using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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
    }
}
