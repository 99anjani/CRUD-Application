/*
using Microsoft.EntityFrameworkCore;

namespace crud_app.Models
{
    public class EmployeeContext :DbContext
    {
        protected EmployeeContext(DbContextOptions<EmployeeContext> options): base(options) 
        { 



        }
        public DbSet<Employee> Employees { get; set;}

       
    }
}
*/
using crud_app.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
    {
    }

    public EmployeeContext()
    {
        // Default constructor
    }

    // DbSet properties and other configurations here
    public DbSet<Employee> Employees { get; set; }
    // Other entity sets and configurations
}
