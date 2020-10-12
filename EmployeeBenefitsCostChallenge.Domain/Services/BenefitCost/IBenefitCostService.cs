using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost
{
    public interface IBenefitCostService
    {
        BenefitCostResult GetBenefitCost(Person p);
    }
}