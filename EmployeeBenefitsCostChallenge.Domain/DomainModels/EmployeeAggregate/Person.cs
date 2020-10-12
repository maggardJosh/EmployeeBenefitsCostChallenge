using System;
using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate.BenefitCostStrategies;

namespace EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate
{
    public abstract class Person
    {
        private const int NumberOfPaychecksPerYear = 26;    //TODO: would make this data driven

        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected abstract decimal StandardAnnualBenefitCost { get; }

        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual decimal AnnualBenefitCost => BenefitCostStrategy.GetBenefitCost(StandardAnnualBenefitCost);
        public decimal BenefitCostPerPaycheck => AnnualBenefitCost / NumberOfPaychecksPerYear;       //TODO: Possible rounding issue? Might be worth creating own Currency class or finding one online to make dealing with money easier/less error prone.

        private IBenefitCostStrategy BenefitCostStrategy
        {
            get
            {
                if (FirstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase))   //Assuming case of first letter is not important, would verify with stakeholder
                    return new DiscountedBenefitCostStrategy(10);
                return new StandardBenefitCostStrategy();
            }
        }

    }
}
