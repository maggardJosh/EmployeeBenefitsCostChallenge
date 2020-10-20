namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies
{
    public interface IBenefitCostStrategy
    {
        public decimal GetAnnualBenefitCost(decimal standardAnnualCost);
    }
}
