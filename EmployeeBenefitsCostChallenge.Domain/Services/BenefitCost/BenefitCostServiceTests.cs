using System;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
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
            var benefitCostSettings = new Mock<IBenefitCostSettingsRepository>();
            benefitCostSettings.SetupGet(settings => settings.StandardAnnualBenefitCost).Returns(1000);
            benefitCostSettings.SetupGet(settings => settings.DependentAnnualBenefitCost).Returns(500);
            benefitCostSettings.SetupGet(settings => settings.NumberOfPaychecksPerYear).Returns(26);
            benefitCostSettings.SetupGet(settings => settings.ANameDiscountPercent).Returns(10);
            return new BenefitCostService(benefitCostSettings.Object, new BenefitCostStrategyFactory(benefitCostSettings.Object));
        }

        [Fact]
        public void GetIndividualBenefitCost_PersonWithNameStartingWithA_GetsDiscount()
        {
            //arrange
            Employee employee = new Employee("Alphonso", "Miller");
            BenefitCostService service = GetMockBenefitCostService();

            //act
            decimal annualBenefitCost = service.GetIndividualBenefitCost(employee).AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(900);
        }

        [Fact]
        public void GetIndividualBenefitCost_PersonWithNameNotStartingWithA_GetsStandardCost()
        {
            //arrange
            Employee employee = new Employee("George", "Random");
            BenefitCostService service = GetMockBenefitCostService();

            //act
            var annualBenefitCost = service.GetIndividualBenefitCost(employee).AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(1000);
        }

        [Fact]
        public void GetTotalBenefitCost_EmployeeWithDependents_GetsAdditionalCost()
        {
            //Arrange
            Employee e = new Employee("George", "Random");
            e.AddDependent(new Dependent("Claire", "Johnson"));
            
            BenefitCostService service = GetMockBenefitCostService();

            //act
            var annualBenefitCost = service.GetTotalBenefitCost(e).AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(1500);
        }

        [Fact]
        public void GetIndividualBenefitCost_StandardEmployee_ReturnsCorrectPaycheckAmount()
        {
            //arrange
            Employee employee = new Employee("George", "Random");
            BenefitCostService service = GetMockBenefitCostService();

            //act
            var paycheckBenefitCost = service.GetIndividualBenefitCost(employee).PaycheckBenefitCost;

            //assert
            paycheckBenefitCost.Should().Be(Math.Round(1000M / 26, 2));
        }
    }
}
