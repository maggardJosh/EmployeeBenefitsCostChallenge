using EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies;
using FluentAssertions;
using Xunit;

namespace EmployeeBenefitsCostChallenge.DomainModels
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

        [Fact]
        public void AnnualBenefitCost_EmployeenWithDependents_GetsAdditionalCost()
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
