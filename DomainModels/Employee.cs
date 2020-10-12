using System.Collections.Generic;
using System.Linq;

namespace EmployeeBenefitsCostChallenge.DomainModels
{

    public class Employee : Person
    {
        
        public IList<Dependent> Dependents { get; set; } = new List<Dependent>();

        protected override decimal StandardAnnualBenefitCost => 1000; //Ideally would make this driven by data
        public override decimal AnnualBenefitCost => base.AnnualBenefitCost + Dependents.Sum(d => d.AnnualBenefitCost);

        public Employee(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public void AddDependent(Dependent dependent)
        {
            Dependents.Add(dependent);
        }
    }
}
