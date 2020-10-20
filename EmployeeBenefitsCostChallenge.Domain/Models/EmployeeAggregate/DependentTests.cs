using EmployeeBenefitsCostChallenge.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class DependentTests
    {
        [Fact]
        public void DependentGetBenefitCost_GivenSettings_ShouldReturnDependentValue()
        {
            //arrange
            var dependent = new Dependent("Josh", "LastName");
            var mockSettingsRepo = new Mock<IBenefitCostSettingsRepository>();
            mockSettingsRepo.Setup(r => r.DependentAnnualBenefitCost).Returns(500);

            //act
            var standardBenefitCost = dependent.GetStandardAnnualBenefitCost(mockSettingsRepo.Object);

            //assert
            standardBenefitCost.Should().Be(500);
        }
    }
}