using BackendSessionDemo.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BackendSessionDemo.Data;

public class AppDbContext : DbContext
{
    // Required to read config from DI
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<CarLicense> CarLicenses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
