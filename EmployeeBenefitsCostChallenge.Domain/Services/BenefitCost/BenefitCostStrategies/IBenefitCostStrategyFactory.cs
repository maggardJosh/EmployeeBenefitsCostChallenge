using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies
{
    public interface IBenefitCostStrategyFactory
    {
        IBenefitCostStrategy GetStrategy(Person p);
    }
}