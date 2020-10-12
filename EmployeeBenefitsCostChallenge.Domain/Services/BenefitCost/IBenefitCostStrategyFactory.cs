using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate.BenefitCostStrategies;

namespace EmployeeBenefitsCostChallenge.Domain.Services
{
    public interface IBenefitCostStrategyFactory
    {
        IBenefitCostStrategy GetStrategy(Person p);
    }
}