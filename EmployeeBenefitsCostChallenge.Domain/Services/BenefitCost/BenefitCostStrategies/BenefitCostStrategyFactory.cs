using System;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate.Abstract;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies.Concrete;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies
{
    public class BenefitCostStrategyFactory : IBenefitCostStrategyFactory
    {
        private readonly decimal _aNameDiscountPercent;

        public BenefitCostStrategyFactory(IBenefitCostSettingsRepository benefitCostSettingsRepository)
        {
            _aNameDiscountPercent = benefitCostSettingsRepository.ANameDiscountPercent;
        }

        public IBenefitCostStrategy GetStrategy(Person p)
        {
            if (p.FirstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase))
                return new DiscountedBenefitCostStrategy(_aNameDiscountPercent);

            return new StandardBenefitCostStrategy();
        }
    }
}