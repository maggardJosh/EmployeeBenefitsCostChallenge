namespace EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies
{
    internal class StandardBenefitCostStrategy : IBenefitCostStrategy
    {
        public decimal GetBenefitCost(decimal annualCost)
        {
            return annualCost;
        }
    }
}
