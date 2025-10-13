using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class AppConfigRepository : IAppConfigRepository
    {

        private readonly AAHREntities _context;

        public AppConfigRepository(AAHREntities context)
        {
            _context = context;
        }

        // Fetch all AppConfiguration records
        public async Task<IEnumerable<AppConfig>> GetAllAppConfigsAsync()
        {
            try
            {
                if (_context.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
                {
                    await _context.Database.OpenConnectionAsync();
                }

                return await _context.AppConfigs.AsNoTracking().ToListAsync();
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("The query was canceled due to a timeout or other issue.");
                throw new TimeoutException("The operation timed out. Consider optimizing the query or increasing the timeout.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
            finally
            {
                if (_context.Database.GetDbConnection().State == System.Data.ConnectionState.Open)
                {
                    await _context.Database.CloseConnectionAsync();
                }
            }
        }
        
        
     

        // Fetch a specific AppConfiguration by ID
        public async Task<AppConfig> GetAppConfigByIdAsync(int id)
        {
            return await _context.AppConfigs.FirstOrDefaultAsync(ac => ac.AppConfigId == id);
        }

        // Add a new AppConfiguration record
        public async Task AddAppConfigAsync(AppConfig appConfig)
        {
            await _context.AppConfigs.AddAsync(appConfig);
            await _context.SaveChangesAsync();
        }

        // Update an existing AppConfiguration record
        public async Task UpdateAppConfigAsync(AppConfig appConfig)
        {
            _context.AppConfigs.Update(appConfig);
            await _context.SaveChangesAsync();
        }

        // Delete an AppConfiguration record by ID
        public async Task DeleteAppConfigAsync(int id)
        {
            var appConfig = await _context.AppConfigs.FindAsync(id);
            if (appConfig != null)
            {
                _context.AppConfigs.Remove(appConfig);
                await _context.SaveChangesAsync();
            }
        }
        public string? getConfigValue(string value)
        {
            return _context.AppConfigs.Where(x => x.Name == value)?.FirstOrDefault()?.Value;
        }

    }
}
