using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate.Abstract;
using EmployeeBenefitsCostChallenge.Domain.Repositories;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class Dependent : Person
    {
        public int ID { get; set; }

        public Dependent() { }
        public Dependent(string firstName, string lastName) : base(firstName, lastName) { }

        public override decimal GetStandardAnnualBenefitCost(IBenefitCostSettingsRepository settingsRepository)
        {
            return settingsRepository.DependentAnnualBenefitCost;
        }
    }
}