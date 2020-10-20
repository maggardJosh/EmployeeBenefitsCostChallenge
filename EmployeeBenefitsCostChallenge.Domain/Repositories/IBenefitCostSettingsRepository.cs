namespace EmployeeBenefitsCostChallenge.Domain.Repositories
{
    public interface IBenefitCostSettingsRepository
    {
        decimal ANameDiscountPercent { get; }
        int NumberOfPaychecksPerYear { get; }
        decimal StandardAnnualBenefitCost { get; }
        decimal DependentAnnualBenefitCost { get; }
    }
}