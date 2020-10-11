namespace EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies
{
    internal class DiscountedBenefitCostStrategy : IBenefitCostStrategy
    {
        private readonly decimal _discountMultiplier;

        //TODO: Write unit tests for expected outcome
        public DiscountedBenefitCostStrategy(decimal discountPercent)
        {
            //TODO: guard clauses < 0 or > 100, write tests as well
            _discountMultiplier = 1 - (discountPercent / 100.0M);
        }

        public decimal GetBenefitCost(decimal annualBenefitCost)
        {
            return annualBenefitCost * _discountMultiplier;
        }
    }
}
