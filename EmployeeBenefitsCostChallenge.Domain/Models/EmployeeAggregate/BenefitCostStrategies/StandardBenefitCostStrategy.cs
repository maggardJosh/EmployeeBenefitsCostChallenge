namespace EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate.BenefitCostStrategies
{
    internal class StandardBenefitCostStrategy : IBenefitCostStrategy
    {
        public decimal GetBenefitCost(decimal annualCost)
        {
            return annualCost;
        }
    }
}
