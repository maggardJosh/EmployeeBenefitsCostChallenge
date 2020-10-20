using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate.Abstract;
using EmployeeBenefitsCostChallenge.Domain.Repositories;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class Employee : Person
    {
        public int EmployeeID { get; set; }

        public Employee() { }
        public Employee(string firstName, string lastName) : base(firstName, lastName) { }

        public override decimal GetStandardAnnualBenefitCost(IBenefitCostSettingsRepository settingsRepository)
        {
            return settingsRepository.StandardAnnualBenefitCost;
        }

        public List<Dependent> Dependents { get; set; } = new List<Dependent>();

        public void AddDependent(Dependent dependent)
        {
            if (Dependents.Contains(dependent))
                return;
            Dependents.Add(dependent);
        }

        public void ClearDependents()
        {
            Dependents.Clear();
        }
    }
}