using System;
using FluentAssertions;
using Xunit;

namespace EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies
{
    public class BenefitCostStrategyTests
    {
        [Theory]
        [InlineData(10, 1000, 900)]
        [InlineData(50, 10000, 5000)]
        [InlineData(90, 1000, 100)]
        public void Discount_GivenDiscount_AppliesCorrectly(decimal discountAmount, decimal standardCost, decimal expectedResult)
        {
            //Arrange
            var costStrategy = new DiscountedBenefitCostStrategy(discountAmount);

            //Act
            var result = costStrategy.GetBenefitCost(standardCost);

            //Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void Discount_GivenInvalidDiscount_ThrowsException(decimal discountAmount)
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new DiscountedBenefitCostStrategy(discountAmount));
        }

    }
}