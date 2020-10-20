using System.Collections.Generic;
using System.Linq;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost;

namespace EmployeeBenefitsCostChallenge.API.EmployeeNS.Models
{
    public class EmployeeBenefitModel
    {
        public EmployeeBenefitModel(Employee employee, IBenefitCostService benefitCostService)
        {
            EmployeeID = employee.EmployeeID;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            BenefitCost = benefitCostService.GetBenefitCost(employee);

            Dependents = employee.Dependents.Select(dependent => new DependentBenefitModel
            {
                FirstName = dependent.FirstName,
                LastName = dependent.LastName,
                BenefitCost = benefitCostService.GetBenefitCost(dependent),
            }).ToList().AsReadOnly();
        }

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IReadOnlyCollection<DependentBenefitModel> Dependents { get; set; }

        public BenefitCostResult BenefitCost { get; set; }
    }

    public class DependentBenefitModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BenefitCostResult BenefitCost { get; set; }
    }
}