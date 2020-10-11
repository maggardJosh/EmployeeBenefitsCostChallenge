namespace EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies
{
    public interface IBenefitCostStrategy
    {
        public double GetBenefitCost(double annualCost);
    }
}
