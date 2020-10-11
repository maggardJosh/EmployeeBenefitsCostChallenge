namespace EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies
{
    internal class DiscountedBenefitCostStrategy : IBenefitCostStrategy
    {
        private readonly double _discountMultiplier;

        //TODO: Write unit tests for expected outcome
        public DiscountedBenefitCostStrategy(double discountPercent)
        {
            //TODO: guard clauses < 0 or > 100, write tests as well
            _discountMultiplier = 1 - (discountPercent / 100.0);
        }

        public double GetBenefitCost(double annualBenefitCost)
        {
            return annualBenefitCost * _discountMultiplier;
        }
    }
}
