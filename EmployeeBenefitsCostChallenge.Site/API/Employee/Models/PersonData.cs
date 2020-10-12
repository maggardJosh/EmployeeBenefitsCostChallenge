using EmployeeBenefitsCostChallenge.Domain.Services;

namespace EmployeeBenefitsCostChallenge.API.Employee.Models
{
    public class PersonData
    {
        public string Name { get; set; }
        public BenefitCostResult BenefitCost { get; set; }
    }
}