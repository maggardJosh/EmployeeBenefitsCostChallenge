using System.Collections.Generic;
using System.Linq;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.Models;

namespace EmployeeBenefitsCostChallenge.API.EmployeeNS.Models
{
    public class EmployeeBenefitModel
    {
        public EmployeeBenefitModel(Employee employee, IBenefitCostService benefitCostService)
        {
            EmployeeID = employee.EmployeeID;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            IndividualBenefitCost = benefitCostService.GetIndividualBenefitCost(employee);
            TotalBenefitCost = benefitCostService.GetTotalBenefitCost(employee);

            Dependents = employee.Dependents.Select(dependent => new DependentBenefitModel
            {
                FirstName = dependent.FirstName,
                LastName = dependent.LastName,
                IndividualBenefitCost = benefitCostService.GetIndividualBenefitCost(dependent),
            }).ToList().AsReadOnly();
        }


        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IReadOnlyCollection<DependentBenefitModel> Dependents { get; set; }

        public BenefitCostResult IndividualBenefitCost { get; set; }
        public BenefitCostResult TotalBenefitCost { get; set; }
    }

    public class DependentBenefitModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BenefitCostResult IndividualBenefitCost { get; set; }
    }
}