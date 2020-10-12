namespace EmployeeBenefitsCostChallenge.Domain.Services
{
    public class HardcodedBenefitCostSettings : IBenefitCostSettings
    {
        public int NumberOfPaychecksPerYear => 26;
        public decimal StandardAnnualBenefitCost => 1000;
        public decimal DependentAnnualBenefitCost => 500;
        public decimal ANameDiscountPercent => 10;
    }
}