using ChallengeBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeBackend.Infrastructure
{
    public class ChallengeBackendContext : DbContext
    {
        public ChallengeBackendContext(DbContextOptions<ChallengeBackendContext> options) : base(options)
        {

        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Permission
            modelBuilder.Entity<Permission>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Permission>()
                        .Property(x => x.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Permission>()
                        .HasIndex(u => u.Id)
                        .IsUnique();

            modelBuilder.Entity<Permission>()
                        .HasOne(s => s.PermissionType)
                        .WithOne()
                        .IsRequired(false)
                        .HasForeignKey<Permission>("PermissionTypeId");


            //PermissionType
            modelBuilder.Entity<PermissionType>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<PermissionType>()
                        .Property(x => x.Id)
                        .ValueGeneratedOnAdd();
        }
    }
}
