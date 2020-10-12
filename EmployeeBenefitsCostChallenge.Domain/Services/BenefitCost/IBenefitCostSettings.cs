namespace EmployeeBenefitsCostChallenge.Domain.Services
{
    public interface IBenefitCostSettings
    {
        decimal ANameDiscountPercent { get; }
        int NumberOfPaychecksPerYear { get;}
        decimal StandardAnnualBenefitCost { get; }
        decimal DependentAnnualBenefitCost { get; }
    }
}