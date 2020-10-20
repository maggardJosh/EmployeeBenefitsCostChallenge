using EmployeeBenefitsCostChallenge.Domain.Common;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract decimal GetStandardAnnualBenefitCost(IBenefitCostSettingsRepository settingsRepository);
        
        public Person() { }
        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}