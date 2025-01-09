using DeveloperPortal.DataAccess.Entity.Models;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.Data
{
    public partial class AAHREntitiesHelper: DbContext
    {
        public virtual DbSet<AllConstructionData> AllConstructionData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllConstructionData>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Type);
                entity.Property(e => e.CaseId);
                entity.Property(e => e.SiteCases);
                entity.Property(e => e.ComplianceMatrixLink);
                entity.Property(e => e.PropertyDetailsLink);
                entity.Property(e => e.Status);
                entity.Property(e => e.AssigneeID);
                entity.Property(e => e.Summary);
                entity.Property(e => e.ProjectName);
                entity.Property(e => e.ProjectAddress);
                entity.Property(e => e.CreatedOn);
                entity.Property(e => e.ModifiedOn);
                entity.Property(e => e.AcHPFileProjectNumber);
                entity.Property(e => e.ProblemProject);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=43devdb10;Initial Catalog=AAHRDev;Integrated Security=true;user id=appACHP;password=BDpwD7@cHP;TrustServerCertificate=true");
    }
}
