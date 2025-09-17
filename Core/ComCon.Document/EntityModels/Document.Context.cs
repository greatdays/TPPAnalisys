
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ComCon.Document.Entity
{
    public partial class DMSEntities : DbContext
    {
        // This is overridden to prevent someone from calling SaveChanges without specifying the user making the change
        public override int SaveChanges()
        {
            throw new InvalidOperationException("Username must be provided");
        }

        public int SaveChanges(string username)
        {
            IEnumerable<System.Data.Entity.Infrastructure.DbEntityEntry<IAuditable>> changeSet = ChangeTracker.Entries<IAuditable>();
            if (changeSet != null)
            {
                foreach (System.Data.Entity.Infrastructure.DbEntityEntry<IAuditable> entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = username;
                            entry.Entity.CreatedOn = DateTime.Now;
                            entry.Entity.ModifiedBy = username;
                            entry.Entity.ModifiedOn = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            entry.Entity.ModifiedBy = username;
                            entry.Entity.ModifiedOn = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
