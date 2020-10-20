using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost
{
    public interface IBenefitCostService
    {
        BenefitCostResult GetTotalBenefitCost(Employee p);
        BenefitCostResult GetIndividualBenefitCost(Person p);
    }
}