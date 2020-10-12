using FluentAssertions;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate
{
    public class EmployeeTests
    {
        [Fact]
        public void AnnualBenefitCost_EmployeeWithDependents_GetsAdditionalCost()
        {
            //Arrange
            Employee e = new Employee("George", "Random");
            e.AddDependent(new Dependent("Claire", "Johnson"));

            //act
            var annualBenefitCost = e.AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(1500);
        }
    }
}