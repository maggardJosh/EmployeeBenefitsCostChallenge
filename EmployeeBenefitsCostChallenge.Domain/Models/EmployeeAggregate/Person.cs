using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Common;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract decimal GetStandardAnnualBenefitCost(IBenefitCostSettingsRepository settingsRepository);

        public abstract List<Dependent> Dependents { get; set; }

        public Person() { }
        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}