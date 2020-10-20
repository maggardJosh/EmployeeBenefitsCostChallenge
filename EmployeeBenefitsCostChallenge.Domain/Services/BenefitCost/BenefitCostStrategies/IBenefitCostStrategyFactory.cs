using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate.Abstract;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies
{
    public interface IBenefitCostStrategyFactory
    {
        IBenefitCostStrategy GetStrategy(Person p);
    }
}