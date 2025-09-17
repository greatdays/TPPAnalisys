using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class LutRepository : ILutRepository
    {
        private readonly AAHREntities _context;

        public LutRepository(AAHREntities context)
        {
            _context = context;
        }

        /// <summary>
        /// LutPreDirs
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        public async Task<List<LutPreDir>> LutPreDirs()
        {
            return await _context.LutPreDirs.Where(x => x.LutPreDirCd != "").ToListAsync();
        }

        /// <summary>
        /// LutStates
        /// </summary>
        /// <returns></returns>
        public async Task<List<LutState>> LutStates()
        {
            return  await _context.LutStates.Where(x => x.IsDeleted == false).ToListAsync(); 
        }
    }
}
