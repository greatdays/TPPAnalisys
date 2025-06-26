using DeveloperPortal.DataAccess.Common;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Entity.Data;

public partial class AAHREntities : DbContext
{

    public async Task<int> SaveChangesWithAuditAsync(string username)
    {
        ApplyAuditDetails(username);
        return await base.SaveChangesAsync();
    }

    private void ApplyAuditDetails(string username)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            AuditHelper.ApplyAudit(entry.Entity, entry.State, username);
        }
    }

    public int SaveChanges(string username)
    {
        ApplyAuditInfo(username);

        return base.SaveChanges();
    }
    private void ApplyAuditInfo(string username)
    {

        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            var entity = entry.Entity;
            var entityType = entity.GetType();

            var modifiedOnProp = entityType.GetProperty("ModifiedOn");
            var modifiedByProp = entityType.GetProperty("ModifiedBy");
            var createdOnProp = entityType.GetProperty("CreatedOn");
            var createdByProp = entityType.GetProperty("CreatedBy");

            if (modifiedOnProp != null && modifiedOnProp.PropertyType == typeof(DateTime))
                modifiedOnProp.SetValue(entity, DateTime.UtcNow);

            if (modifiedByProp != null && modifiedByProp.PropertyType == typeof(string))
                modifiedByProp.SetValue(entity, username);

            if (entry.State == EntityState.Added)
            {
                if (createdOnProp != null && createdOnProp.PropertyType == typeof(DateTime))
                    createdOnProp.SetValue(entity, DateTime.UtcNow);

                if (createdByProp != null && createdByProp.PropertyType == typeof(string))
                    createdByProp.SetValue(entity, username);
            }
        }
    }
}