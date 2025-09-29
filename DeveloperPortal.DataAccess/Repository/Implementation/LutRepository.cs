using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using static DeveloperPortal.Domain.PropertySnapshot.Constants;

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

        /// <summary>
        /// LutContactTypes
        /// </summary>
        /// <param name="contactTypes"></param>
        /// <returns></returns>
        public async Task<List<LutContactType>> LutContactTypes(string[]? contactTypes)
        {
            if(contactTypes!= null && contactTypes.Any())
            {
                return _context.LutContactTypes.Where(x => contactTypes.Contains(x.ContactType) && x.IsObsolete == false).ToList();
            }
            return  _context.LutContactTypes.Where(x => x.IsObsolete == false).ToList();

        }
    }
}
