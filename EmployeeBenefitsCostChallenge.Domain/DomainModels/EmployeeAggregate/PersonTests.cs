using FluentAssertions;
using Xunit;

namespace EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate
{
    public class PersonTests
    {
        [Fact]
        public void AnnualBenefitCost_PersonWithNameStartingWithA_GetsDiscount()
        {
            //arrange
            Person p = new Employee("Alphonso", "Miller");

            //act
            var annualBenefitCost = p.AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(900);
        }

        [Fact]
        public void AnnualBenefitCost_PersonWithNameNotStartingWithA_GetsStandardCost()
        {
            //arrange
            Person p = new Employee("George", "Random");

            //act
            var annualBenefitCost = p.AnnualBenefitCost;

            //assert
            annualBenefitCost.Should().Be(1000);
        }
    }
}
