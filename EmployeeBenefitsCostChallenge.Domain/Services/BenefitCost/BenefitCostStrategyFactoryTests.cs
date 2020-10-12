using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate.BenefitCostStrategies;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.Services
{
    public class BenefitCostStrategyFactoryTests
    {
        [Fact]
        public void GetStrategy_GivenNameStartingWithA_ShouldReturnDiscountStrategy()
        {
            //arrange
            var factory = new BenefitCostStrategyFactory(Mock.Of<IBenefitCostSettings>());
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
            var factory = new BenefitCostStrategyFactory(Mock.Of<IBenefitCostSettings>());
            var person = new Employee("Bob", "Something");
            //act
            var strategy = factory.GetStrategy(person);

            //assert
            strategy.Should().BeOfType<StandardBenefitCostStrategy>();
        }
    }
}