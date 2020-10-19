using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitsCostChallenge.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApplicationSettings> ApplicationSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee").HasMany(e => e.Dependents).WithOne().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Dependent>().ToTable("Dependent");
            modelBuilder.Entity<ApplicationSettings>().ToTable("ApplicationSetting");
        }
    }
}
