namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies.Concrete
{
    internal class StandardBenefitCostStrategy : IBenefitCostStrategy
    {
        public decimal GetBenefitCost(decimal annualCost)
        {
            return annualCost;
        }
    }
}
