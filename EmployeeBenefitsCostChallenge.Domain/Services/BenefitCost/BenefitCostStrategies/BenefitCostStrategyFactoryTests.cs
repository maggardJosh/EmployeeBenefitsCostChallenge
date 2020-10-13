using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies.Concrete;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies
{
    public class BenefitCostStrategyFactoryTests
    {
        [Fact]
        public void GetStrategy_GivenNameStartingWithA_ShouldReturnDiscountStrategy()
        {
            //arrange
            var factory = new BenefitCostStrategyFactory(Mock.Of<IBenefitCostSettingsRepository>());
            var person = new Employee("Alice", "Something");
            //act
            var strategy = factory.GetStrategy(person);

            //assert
            strategy.Should().BeOfType<DiscountedBenefitCostStrategy>();
        }

        [Fact]
        public void GetStrategy_GivenNameNotStartingWithA_ShouldReturnStandardStrategy()
        {
            //arrange
            var factory = new BenefitCostStrategyFactory(Mock.Of<IBenefitCostSettingsRepository>());
            var person = new Employee("Bob", "Something");
            //act
            var strategy = factory.GetStrategy(person);

            //assert
            strategy.Should().BeOfType<StandardBenefitCostStrategy>();
        }
    }
}