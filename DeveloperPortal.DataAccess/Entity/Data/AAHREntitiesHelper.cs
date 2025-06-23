using DeveloperPortal.DataAccess.Entity.Models;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DeveloperPortal.DataAccess.Entity.Data
{
    public partial class AAHREntitiesHelper: DbContext
    {

        private readonly IConfiguration _configuration;

        public AAHREntitiesHelper(DbContextOptions<AAHREntitiesHelper> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        public virtual DbSet<AllConstructionData> AllConstructionData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllConstructionData>().HasNoKey();
            //modelBuilder.Entity<AllConstructionData>(entity =>
            //{
            //    entity.HasNoKey();
            //    entity.Property(e => e.Type);
            //    entity.Property(e => e.CaseId);
            //    entity.Property(e => e.SiteCases);
            //    entity.Property(e => e.ComplianceMatrixLink);
            //    entity.Property(e => e.PropertyDetailsLink);
            //    entity.Property(e => e.Status);
            //    entity.Property(e => e.AssigneeID);
            //    entity.Property(e => e.Summary);
            //    entity.Property(e => e.ProjectName);
            //    entity.Property(e => e.ProjectAddress);
            //    entity.Property(e => e.CreatedOn);
            //    entity.Property(e => e.ModifiedOn);
            //    entity.Property(e => e.AcHPFileProjectNumber);
            //    entity.Property(e => e.ProblemProject);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


    }
}
