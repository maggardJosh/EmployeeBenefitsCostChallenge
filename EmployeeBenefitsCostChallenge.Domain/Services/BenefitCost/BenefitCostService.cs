using System.Linq;
using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies;

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
        public BenefitCostResult GetBenefitCost(Person p)
        {
            var benefitCostStrategy = _benefitCostStrategyFactory.GetStrategy(p);
            var standardAnnualBenefitCost = p.GetStandardAnnualBenefitCost(_benefitCostSettingsRepository);

            var benefitCostResult = benefitCostStrategy.GetBenefitCost(standardAnnualBenefitCost);
            var dependentAnnualCost = p.Dependents.Sum(dependent => GetBenefitCost(dependent).AnnualBenefitCost);

            benefitCostResult += dependentAnnualCost;

            return new BenefitCostResult
            {
                AnnualBenefitCost = benefitCostResult,
                PaycheckBenefitCost = benefitCostResult / _benefitCostSettingsRepository.NumberOfPaychecksPerYear
            };
        }
    }
}
