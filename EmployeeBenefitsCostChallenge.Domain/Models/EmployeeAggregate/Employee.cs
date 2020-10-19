using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Common;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class Employee : Person
    {
        public int EmployeeID { get; set; }

        public Employee(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        //TODO: Potentially cover this function in tests
        public override decimal GetStandardAnnualBenefitCost(IBenefitCostSettingsRepository settingsRepository)
        {
            return settingsRepository.StandardAnnualBenefitCost;
        }

        public override IReadOnlyList<Dependent> Dependents => _dependents.AsReadOnly();
        private readonly List<Dependent> _dependents = new List<Dependent>();

        public void AddDependent(Dependent dependent)
        {
            _dependents.Add(dependent);
        }

        public void ClearDependents()
        {
            _dependents.Clear();
        }
    }
}