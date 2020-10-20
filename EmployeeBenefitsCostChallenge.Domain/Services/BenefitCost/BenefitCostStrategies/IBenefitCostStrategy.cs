namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies
{
    public interface IBenefitCostStrategy
    {
        public decimal GetBenefitCost(decimal standardAnnualCost);
    }
}
