using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SalaryDbContext : DbContext
    {

        public SalaryDbContext() { }

        public SalaryDbContext(DbContextOptions<SalaryDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AP;Database=SalaryDb;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();


            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Tc)
                .IsUnique();

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryDetails> SalaryDetails { get; set; }

        public DbSet<Payroll> Payrolls { get; set; }



    }
}
