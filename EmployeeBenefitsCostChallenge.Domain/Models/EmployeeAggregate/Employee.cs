using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Common;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class Employee : Person
    {
        public Employee(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override decimal GetStandardAnnualBenefitCost(IBenefitCostSettings settings)
        {
            return settings.StandardAnnualBenefitCost;
        }

        public override IReadOnlyList<Dependent> Dependents => _dependents.AsReadOnly();
        private readonly List<Dependent> _dependents = new List<Dependent>();

        public void AddDependent(Dependent dependent)
        {
            _dependents.Add(dependent);
        }
    }
}