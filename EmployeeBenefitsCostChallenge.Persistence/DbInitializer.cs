using System;
using System.Collections.Generic;
using System.Text;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using Microsoft.EntityFrameworkCore.Internal;

namespace EmployeeBenefitsCostChallenge.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
                return; //Datbase already created

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
