using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Internal;

namespace EmployeeBenefitsCostChallenge.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            SeedEmployeesTable(context);
            SeedApplicationSettingsTable(context);
        }

        private static void SeedApplicationSettingsTable(DatabaseContext context)
        {
            if (context.ApplicationSettings.Any())
                return;

            var hardcodedSettings = new DefaultLocalBenefitCostSettingsRepository();
            var settings = new []
            {
                new ApplicationSettings{Name = nameof(hardcodedSettings.ANameDiscountPercent), Value = hardcodedSettings.ANameDiscountPercent.ToString()},
                new ApplicationSettings{Name = nameof(hardcodedSettings.NumberOfPaychecksPerYear), Value = hardcodedSettings.NumberOfPaychecksPerYear.ToString()},
                new ApplicationSettings{Name = nameof(hardcodedSettings.DependentAnnualBenefitCost), Value = hardcodedSettings.DependentAnnualBenefitCost.ToString()},
                new ApplicationSettings{Name = nameof(hardcodedSettings.StandardAnnualBenefitCost), Value = hardcodedSettings.StandardAnnualBenefitCost.ToString()},
            };

            foreach (var setting in settings)
                context.ApplicationSettings.Add(setting);

            context.SaveChanges();
        }

        private static void SeedEmployeesTable(DatabaseContext context)
        {
            if (context.Employees.Any())
                return;

            var e1 = new Employee("Josh", "Maggard");
            e1.AddDependent(new Dependent("Alice", "Random"));
            e1.AddDependent(new Dependent("Jerry", "Random"));
            var e2 = new Employee("George", "Someone");

            var employees = new[]
            {
                e1, e2
            };

            foreach (var employee in employees)
                context.Employees.Add(employee);
            context.SaveChanges();
        }
    }
}
