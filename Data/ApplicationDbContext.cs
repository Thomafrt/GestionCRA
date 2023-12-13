using CRA.Models;
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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration des relations entre les modèles
            modelBuilder.Entity<Entry>()
                .HasOne(e => e.Mission)
                .WithMany(m => m.Entries)
                .HasForeignKey(e => e.MissionId)
                .IsRequired();

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.Employee)
                .WithMany(emp => emp.Entries)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();

            // D'autres configurations de modèle peuvent être nécessaires ici

            base.OnModelCreating(modelBuilder);
        
        }
    }

}