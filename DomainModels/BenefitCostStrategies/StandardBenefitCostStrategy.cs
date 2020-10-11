namespace EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies
{
    internal class StandardBenefitCostStrategy : IBenefitCostStrategy
    {
        public double GetBenefitCost(double annualCost)
        {
            return annualCost;
        }
    }
}
