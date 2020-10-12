using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Common;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";

        public abstract decimal GetStandardAnnualBenefitCost(IBenefitCostSettings settings);

        public abstract IReadOnlyList<Dependent> Dependents { get; }

        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}