using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Practice.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .Property(e => e.EmployeeId)
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<Department>()
        //        .Property(d => d.DepartmentID)
        //        .ValueGeneratedOnAdd();
        //}
    }
}
