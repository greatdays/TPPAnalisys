using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
  
    public class ApnpinRepository : IApnpinRepository
    {
        private readonly AAHREntities _context;

        public ApnpinRepository(AAHREntities context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all Apnpin records.
        /// </summary>
        /// <returns>A list of Apnpin entities.</returns>
        public async Task<IEnumerable<Apnpin>> GetAllApnpinsAsync()
        {
            //var data = _context.Apnpins.ToList();
            return await _context.Apnpins.ToListAsync();
        }

        /// <summary>
        /// Retrieves a single Apnpin record by its ID.
        /// </summary>
        /// <param name="id">The ID of the Apnpin record.</param>
        /// <returns>An Apnpin entity if found; otherwise, null.</returns>
        public async Task<Apnpin> GetApnpinByIdAsync(int id)
        {
            return await _context.Apnpins.FindAsync(id);
        }

        /// <summary>
        /// Adds a new Apnpin record to the database.
        /// </summary>
        /// <param name="apnpin">The Apnpin entity to add.</param>
        /// <returns>The added Apnpin entity.</returns>
        public async Task<Apnpin> AddApnpinAsync(Apnpin apnpin)
        {
            var result = await _context.Apnpins.AddAsync(apnpin);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Updates an existing Apnpin record.
        /// </summary>
        /// <param name="apnpin">The Apnpin entity to update.</param>
        /// <returns>The updated Apnpin entity.</returns>
        public async Task<Apnpin> UpdateApnpinAsync(Apnpin apnpin)
        {
            _context.Apnpins.Update(apnpin);
            await _context.SaveChangesAsync();
            return apnpin;
        }

        /// <summary>
        /// Deletes an Apnpin record by its ID.
        /// </summary>
        /// <param name="id">The ID of the Apnpin record to delete.</param>
        /// <returns>A boolean indicating whether the delete was successful.</returns>
        public async Task<bool> DeleteApnpinAsync(int id)
        {
            var apnpin = await _context.Apnpins.FindAsync(id);
            if (apnpin == null) return false;

            _context.Apnpins.Remove(apnpin);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
