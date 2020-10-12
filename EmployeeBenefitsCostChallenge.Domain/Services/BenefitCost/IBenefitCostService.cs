using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate;

namespace EmployeeBenefitsCostChallenge.Domain.Services
{
    public interface IBenefitCostService
    {
        BenefitCostResult GetBenefitCost(Person p);
    }
}