using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Common;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class Dependent : Person
    {
        public int DependentID { get; set; }
        public Dependent(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        //TODO: Potentially cover this function in tests
        public override decimal GetStandardAnnualBenefitCost(IBenefitCostSettings settings)
        {
            return settings.DependentAnnualBenefitCost;
        }

        public override IReadOnlyList<Dependent> Dependents => new List<Dependent>().AsReadOnly();
    }
}