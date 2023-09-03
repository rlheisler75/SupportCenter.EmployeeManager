using Microsoft.EntityFrameworkCore;
using SupportCenter.EmployeeManager.Data.Models;

namespace SupportCenter.EmployeeManager.Data
{
    public class EmployeeManagerDbContext : DbContext
    {
        public EmployeeManagerDbContext(
        DbContextOptions<EmployeeManagerDbContext> options) : base(options) { }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Finance" },
                new Department { Id = 2, Name = "Sales" },
                new Department { Id = 3, Name = "Marketing" },
                new Department { Id = 4, Name = "Human Resources" },
                new Department { Id = 5, Name = "IT" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Robert", LastName = "Heisler", Title = "C# Developer", DepartmentID = 5, IsDeveloper = true },
                new Employee { Id = 2, FirstName = "Brad", LastName = "Sullivan", Title = "Banker", DepartmentID = 1 },
                new Employee { Id = 3, FirstName = "Silas ", LastName = "Rogers", Title = "Sales Manager", DepartmentID = 3 },
                new Employee { Id = 4, FirstName = "Vinny", LastName = "Beck", Title = "Sales Rep", DepartmentID = 2 },
                new Employee { Id = 5, FirstName = "Betsy ", LastName = "Mendoza", Title = "Payroll", DepartmentID = 4 },
                new Employee { Id = 6, FirstName = "Jason", LastName = "Rojas", Title = "JavaScript Developer", DepartmentID = 5, IsDeveloper = true },
                new Employee { Id = 7, FirstName = "Marvin ", LastName = "Winter", Title = "Sales Rep", DepartmentID = 2 },
                new Employee { Id = 8, FirstName = "Yousuf ", LastName = "Grant", Title = "Recruiting Manager", DepartmentID = 4 });



        }
    }
}
