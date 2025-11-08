using Microsoft.EntityFrameworkCore;
using DepartmentsEmployeesAPI.Models;

namespace DepartmentsEmployeesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
               .HasOne(e => e.Department)
               .WithMany(d => d.Employees)
               .HasForeignKey(e => e.DeptId)
               .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Employee>()
                        .HasQueryFilter(e => !e.IsDeleted);
        }

    }
}
