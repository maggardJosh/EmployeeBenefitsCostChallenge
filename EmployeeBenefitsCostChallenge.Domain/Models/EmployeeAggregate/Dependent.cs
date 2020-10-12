using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Common;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class Dependent : Person
    {
        public Dependent(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override decimal GetStandardAnnualBenefitCost(IBenefitCostSettings settings)
        {
            return settings.DependentAnnualBenefitCost;
        }

        public override IReadOnlyList<Dependent> Dependents => new List<Dependent>().AsReadOnly();
    }
}