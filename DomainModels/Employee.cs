using System.Collections.Generic;
using System.Linq;

namespace EmployeeBenefitsCostChallenge.DomainModels
{

    public class Employee : Person
    {
        public IEnumerable<Dependent> Dependents { get; set; }

        protected override double StandardAnnualBenefitCost => 1000; //Ideally would make this driven by data
        public override double AnnualBenefitCost => base.AnnualBenefitCost + Dependents.Sum(d => d.AnnualBenefitCost);        //TODO: Write unit tests for this

    }
}
