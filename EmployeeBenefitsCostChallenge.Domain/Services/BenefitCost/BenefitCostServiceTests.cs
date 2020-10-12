using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.BenefitCostStrategies;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost
{
    public class BenefitCostServiceTests
    {
        private BenefitCostService GetMockBenefitCostService()
        {
            var benefitCostSettings = new Mock<IBenefitCostSettings>();
            benefitCostSettings.SetupGet(settings => settings.StandardAnnualBenefitCost).Returns(1000);
            benefitCostSettings.SetupGet(settings => settings.DependentAnnualBenefitCost).Returns(500);
            benefitCostSettings.SetupGet(settings => settings.NumberOfPaychecksPerYear).Returns(26);
            benefitCostSettings.SetupGet(settings => settings.ANameDiscountPercent).Returns(10);
            return new BenefitCostService(benefitCostSettings.Object, new BenefitCostStrategyFactory(benefitCostSettings.Object));
        }

        [Fact]
        public void AnnualBenefitCost_PersonWithNameStartingWithA_GetsDiscount()
        {
            //arrange
            Person p = new Employee("Alphonso", "Miller");
            BenefitCostService service = GetMockBenefitCostService();

            //act
            decimal annualBenefitCost = service.GetBenefitCost(p).AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(900);
        }

        [Fact]
        public void AnnualBenefitCost_PersonWithNameNotStartingWithA_GetsStandardCost()
        {
            //arrange
            Person p = new Employee("George", "Random");
            BenefitCostService service = GetMockBenefitCostService();

            //act
            var annualBenefitCost = service.GetBenefitCost(p).AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(1000);
        }

        [Fact]
        public void AnnualBenefitCost_EmployeeWithDependents_GetsAdditionalCost()
        {
            //Arrange
            Employee e = new Employee("George", "Random");
            e.AddDependent(new Dependent("Claire", "Johnson"));
            
            BenefitCostService service = GetMockBenefitCostService();

            //act
            var annualBenefitCost = service.GetBenefitCost(e).AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(1500);
        }

        [Fact]
        public void PaycheckBenefitCost_StandardEmployee_ReturnsCorrectAmount()
        {
            //arrange
            Person p = new Employee("George", "Random");
            BenefitCostService service = GetMockBenefitCostService();

            //act
            var paycheckBenefitCost = service.GetBenefitCost(p).PaycheckBenefitCost;

            //assert
            paycheckBenefitCost.Should().Be(1000M/26);
        }
    }
}
