using System;
using EmployeeBenefitsCostChallenge.DomainModels.BenefitCostStrategies;

namespace EmployeeBenefitsCostChallenge.DomainModels
{
    public abstract class Person
    {
        private const int NumberOfPaychecksPerYear = 26;    //TODO: would make this data driven

        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected abstract double StandardAnnualBenefitCost { get; }

        public virtual double AnnualBenefitCost => BenefitCostStrategy.GetBenefitCost(StandardAnnualBenefitCost);
        public double BenefitCostPerPaycheck => AnnualBenefitCost / NumberOfPaychecksPerYear;       //TODO: Possible rounding issue? Might be worth creating own Currency class or finding one online to make dealing with money easier/less error prone.

        private IBenefitCostStrategy BenefitCostStrategy
        {
            get
            {
                //TODO: Write unit tests for this
                if (FirstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase))   //Assuming case of first letter is not important, would verify with stakeholder
                    return new DiscountedBenefitCostStrategy(10);
                return new StandardBenefitCostStrategy();
            }
        }

    }
}
