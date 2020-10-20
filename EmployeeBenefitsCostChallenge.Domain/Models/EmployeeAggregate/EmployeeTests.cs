using EmployeeBenefitsCostChallenge.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeGetBenefitCost_GivenSettings_ShouldReturnStandardValue()
        {
            //arrange
            var employee = new Employee("Josh", "LastName");
            var mockSettingsRepo = new Mock<IBenefitCostSettingsRepository>();
            mockSettingsRepo.Setup(r => r.StandardAnnualBenefitCost).Returns(1000);

            //act
            var standardBenefitCost = employee.GetStandardAnnualBenefitCost(mockSettingsRepo.Object);

            //assert
            standardBenefitCost.Should().Be(1000);
        }   

        [Fact]
        public void AddDependent_AddsDependent()
        {
            //arrange
            var employee = new Employee();
            var dependent = new Dependent();

            //act
            employee.AddDependent(dependent);

            //assert
            employee.Dependents.Should().Contain(dependent);
        }

        [Fact]
        public void AddDependent_AddSameDependentTwice_DoesNotDuplicate()
        {
            //arrange
            var employee = new Employee();
            var dependent = new Dependent();

            //act
            employee.AddDependent(dependent);
            employee.AddDependent(dependent);

            //assert
            employee.Dependents.Count.Should().Be(1, "Duplicate dependents not allowed");
        }

        [Fact]
        public void ClearDependents_ClearsDependent()
        {
            //arrange
            var employee = new Employee();
            var dependent = new Dependent();
            var dependent2 = new Dependent();
            employee.AddDependent(dependent);
            employee.AddDependent(dependent2);

            //act
            employee.ClearDependents();

            //assert
            employee.Dependents.Should().BeEmpty();
        }
    }
}