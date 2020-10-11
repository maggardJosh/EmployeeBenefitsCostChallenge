namespace EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies
{
    public interface IBenefitCostStrategy
    {
        public decimal GetBenefitCost(decimal annualCost);
    }
}
