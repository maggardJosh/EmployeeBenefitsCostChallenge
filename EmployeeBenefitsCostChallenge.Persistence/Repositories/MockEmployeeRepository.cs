﻿using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Repositories;

namespace EmployeeBenefitsCostChallenge.Persistence.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            var e1 = new Employee("Josh", "Maggard");
            e1.AddDependent(new Dependent("Bob", "Bobson"));
            e1.AddDependent(new Dependent("Alice", "Bobson"));

            var e2 = new Employee("George", "Man");
            return new[] { e1, e2 };
        }
    }
}