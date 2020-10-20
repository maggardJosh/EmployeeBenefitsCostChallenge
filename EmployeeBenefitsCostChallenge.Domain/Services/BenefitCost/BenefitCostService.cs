using System.Linq;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate.Abstract;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.Models;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost
{
    public class BenefitCostService : IBenefitCostService
    {
        private readonly IBenefitCostSettingsRepository _benefitCostSettingsRepository;
        private readonly IBenefitCostStrategyFactory _benefitCostStrategyFactory;

        public BenefitCostService(IBenefitCostSettingsRepository benefitCostSettingsRepository, IBenefitCostStrategyFactory benefitCostStrategyFactory)
        {
            _benefitCostSettingsRepository = benefitCostSettingsRepository;
            _benefitCostStrategyFactory = benefitCostStrategyFactory;
        }
        public BenefitCostResult GetTotalBenefitCost(Employee employee)
        {
            decimal employeeAnnualCost = GetIndividualBenefitCost(employee).AnnualBenefitCost;

            decimal totalDependentAnnualCost = employee.Dependents.Sum(dependent => GetIndividualBenefitCost(dependent).AnnualBenefitCost);

            decimal totalAnnualBenefitCost = employeeAnnualCost + totalDependentAnnualCost;

            return new BenefitCostResult
            {
                AnnualBenefitCost = totalAnnualBenefitCost,
                PaycheckBenefitCost = totalAnnualBenefitCost / _benefitCostSettingsRepository.NumberOfPaychecksPerYear
            };
        }

        public BenefitCostResult GetIndividualBenefitCost(Person person)
        {
            IBenefitCostStrategy benefitCostStrategy = _benefitCostStrategyFactory.GetStrategy(person);
            decimal standardAnnualBenefitCost = person.GetStandardAnnualBenefitCost(_benefitCostSettingsRepository);

            decimal benefitCostResult = benefitCostStrategy.GetAnnualBenefitCost(standardAnnualBenefitCost);

            return new BenefitCostResult
            {
                AnnualBenefitCost = benefitCostResult,
                PaycheckBenefitCost = benefitCostResult / _benefitCostSettingsRepository.NumberOfPaychecksPerYear
            };
        }
    }
}
