namespace EmployeeBenefitsCostChallenge.Domain.Common
{
    public interface IBenefitCostSettingsRepository
    {
        decimal ANameDiscountPercent { get; }
        int NumberOfPaychecksPerYear { get;}
        decimal StandardAnnualBenefitCost { get; }
        decimal DependentAnnualBenefitCost { get; }
    }
}