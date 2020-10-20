using EmployeeBenefitsCostChallenge.Domain.Repositories;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate.Abstract
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Person() { }
        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public abstract decimal GetStandardAnnualBenefitCost(IBenefitCostSettingsRepository settingsRepository);
    }
}