using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost
{
    public interface IBenefitCostStrategyFactory
    {
        IBenefitCostStrategy GetStrategy(Person p);
    }
}