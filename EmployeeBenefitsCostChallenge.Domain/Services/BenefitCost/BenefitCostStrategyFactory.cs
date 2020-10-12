using System;
using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate.BenefitCostStrategies;

namespace EmployeeBenefitsCostChallenge.Domain.Services
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
            //TODO: Unit test BenefitCostStrategyFactory both paths
            //Assuming case of first letter is not important, would verify with stakeholder
            if (p.FirstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase))
                return new DiscountedBenefitCostStrategy(_aNameDiscountPercent);
            return new StandardBenefitCostStrategy();
        }
    }
}