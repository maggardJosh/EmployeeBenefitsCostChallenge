namespace EmployeeBenefitsCostChallenge.Domain.Common
{
    public interface IBenefitCostSettings
    {
        decimal ANameDiscountPercent { get; }
        int NumberOfPaychecksPerYear { get;}
        decimal StandardAnnualBenefitCost { get; }
        decimal DependentAnnualBenefitCost { get; }
    }
}