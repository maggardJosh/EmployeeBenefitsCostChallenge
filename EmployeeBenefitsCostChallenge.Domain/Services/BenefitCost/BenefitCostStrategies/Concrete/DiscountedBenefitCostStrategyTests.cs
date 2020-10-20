using System;
using FluentAssertions;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies.Concrete
{
    public class DiscountedBenefitCostStrategyTests
    {
       

        [Theory]
        [InlineData(10, 1000, 900)]
        [InlineData(50, 10000, 5000)]
        [InlineData(90, 1000, 100)]
        public void GetAnnualBenefitCost_GivenDiscount_AppliesCorrectly(decimal discountAmount, decimal standardCost, decimal expectedResult)
        {
            //Arrange
            var costStrategy = new DiscountedBenefitCostStrategy(discountAmount);

            //Act
            var result = costStrategy.GetAnnualBenefitCost(standardCost);

            //Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void DiscountStrategy_GivenInvalidDiscount_ThrowsException(decimal discountAmount)
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new DiscountedBenefitCostStrategy(discountAmount));
        }

    }
}