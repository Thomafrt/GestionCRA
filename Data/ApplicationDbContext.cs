using CRA.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GestionCRA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Mission>()
               .HasMany(m => m.Assigned)
               .WithMany(e => e.Missions)
               .UsingEntity(j => j.ToTable("MissionEmployeeAssignments"));

            // Autres configurations si nécessaires

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Report> Reports { get; set; }
    }

}