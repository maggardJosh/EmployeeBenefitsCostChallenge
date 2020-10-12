using System;

namespace EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate.BenefitCostStrategies
{
    internal class DiscountedBenefitCostStrategy : IBenefitCostStrategy
    {
        private readonly decimal _discountMultiplier;

        public DiscountedBenefitCostStrategy(decimal discountPercent)
        {
            if(discountPercent < 0 || discountPercent > 100)
                throw new ArgumentOutOfRangeException(nameof(discountPercent));
            _discountMultiplier = 1 - (discountPercent / 100.0M);
        }

        public decimal GetBenefitCost(decimal annualBenefitCost)
        {
            return annualBenefitCost * _discountMultiplier;
        }
    }
}
