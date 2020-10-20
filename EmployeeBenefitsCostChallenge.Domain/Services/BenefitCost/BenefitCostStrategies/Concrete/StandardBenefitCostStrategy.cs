namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies.Concrete
{
    internal class StandardBenefitCostStrategy : IBenefitCostStrategy
    {
        public decimal GetAnnualBenefitCost(decimal standardAnnualCost)
        {
            return standardAnnualCost;
        }
    }
}
