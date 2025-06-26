using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Common
{
    public static class AuditHelper
    {
        public static void ApplyAudit(object entity, EntityState state, string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return;

            var entityType = entity.GetType();
            var now = DateTime.UtcNow;

            var createdOn = entityType.GetProperty("CreatedOn");
            var createdBy = entityType.GetProperty("CreatedBy");
            var modifiedOn = entityType.GetProperty("ModifiedOn");
            var modifiedBy = entityType.GetProperty("ModifiedBy");

            if (state == EntityState.Added)
            {
                createdOn?.SetValue(entity, now);
                createdBy?.SetValue(entity, username);
            }

            if (state == EntityState.Added || state == EntityState.Modified)
            {
                modifiedOn?.SetValue(entity, now);
                modifiedBy?.SetValue(entity, username);
            }
        }
    }
}
