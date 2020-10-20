using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate.Abstract;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.Models;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost
{
    public interface IBenefitCostService
    {
        BenefitCostResult GetTotalBenefitCost(Employee employee);
        BenefitCostResult GetIndividualBenefitCost(Person person);
    }
}