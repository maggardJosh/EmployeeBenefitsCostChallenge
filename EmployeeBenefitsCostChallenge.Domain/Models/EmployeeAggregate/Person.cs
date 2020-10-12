using System;
using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Services;

namespace EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate
{
    public abstract class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract decimal GetStandardAnnualBenefitCost(IBenefitCostSettings settings);

        public abstract IReadOnlyList<Dependent> Dependents { get; }

        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
