namespace EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate.BenefitCostStrategies
{
    public interface IBenefitCostStrategy
    {
        public decimal GetBenefitCost(decimal annualCost);
    }
}
