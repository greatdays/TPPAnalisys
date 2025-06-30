using System;
using DeveloperPortal.DataAccess.Entity.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess
{
    public class TPPDbContext : DbContext
    {
        public TPPDbContext(DbContextOptions<TPPDbContext> options) : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<TPPUser> TPPUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TPPUser>(b =>
            {
                b.ToTable("TPPUsers");        
                b.HasKey(u => u.UserId);
                b.Property(u => u.Email)
                 .IsRequired()
                 .HasMaxLength(256);
                b.HasIndex(u => u.Email).IsUnique();
                b.Property(u => u.FirstName).HasMaxLength(100);
                b.Property(u => u.LastName).HasMaxLength(100);
                b.Property(u => u.CreatedOn)
                 .HasDefaultValueSql("GETDATE()");
                b.Property(u => u.Provider).IsRequired()
                                           .HasMaxLength(50)
                                           .HasDefaultValue("SQL");
            });

            modelBuilder.Entity<RefreshToken>(b =>
            {
                b.ToTable("TPPRefreshTokens");
                b.HasKey(r => r.Id);
                b.Property(r => r.Token).IsRequired().HasMaxLength(200);
                b.Property(r => r.ExpiresOn).IsRequired();
                b.Property(r => r.CreatedOn).HasDefaultValueSql("GETDATE()");
                b.HasIndex(r => r.Token).IsUnique();

                // FK to TPPUsers
                b.HasOne(r => r.User)
                 .WithMany() 
                 .HasForeignKey(r => r.UserId)
                 .OnDelete(DeleteBehavior.Cascade); ;
            });

        }
    }
}
