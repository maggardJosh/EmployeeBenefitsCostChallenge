using EmployeeBenefitsCostChallenge.Domain.Repositories;

namespace EmployeeBenefitsCostChallenge.Persistence.Repositories
{
    public class DefaultLocalBenefitCostSettingsRepository : IBenefitCostSettingsRepository
    {
        public int NumberOfPaychecksPerYear => 26;
        public decimal StandardAnnualBenefitCost => 1000;
        public decimal DependentAnnualBenefitCost => 500;
        public decimal ANameDiscountPercent => 10;
    }
}