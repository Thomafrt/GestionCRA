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
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            base.OnModelCreating(modelBuilder);
        
        }
    }

}