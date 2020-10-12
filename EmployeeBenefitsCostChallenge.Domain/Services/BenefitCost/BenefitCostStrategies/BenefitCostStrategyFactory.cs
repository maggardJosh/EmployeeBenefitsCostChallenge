using System;
using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies.Concrete;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies
{
    public class BenefitCostStrategyFactory : IBenefitCostStrategyFactory
    {
        private readonly decimal _aNameDiscountPercent;

        public BenefitCostStrategyFactory(IBenefitCostSettings benefitCostSettings)
        {
            _aNameDiscountPercent = benefitCostSettings.ANameDiscountPercent;
        }

        public IBenefitCostStrategy GetStrategy(Person p)
        {
            if (p.FirstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase))
                return new DiscountedBenefitCostStrategy(_aNameDiscountPercent);

            return new StandardBenefitCostStrategy();
        }
    }
}