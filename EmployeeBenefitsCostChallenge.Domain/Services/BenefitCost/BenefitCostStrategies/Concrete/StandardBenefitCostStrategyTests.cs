using FluentAssertions;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies.Concrete
{
    public class StandardBenefitCostStrategyTests
    {
        [Fact]
        public void StandardBenefitCost_GivenStandardCost_ReturnsOriginalCost()
        {
            //arrange
            var costStrategy = new StandardBenefitCostStrategy();
            decimal standardCost = 1000;

            //act
            var result = costStrategy.GetBenefitCost(standardCost);

            //assert
            result.Should().Be(standardCost);
        }
    }
}