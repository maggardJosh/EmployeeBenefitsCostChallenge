using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost;

namespace EmployeeBenefitsCostChallenge.API.Employee.Models
{
    public class PersonData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BenefitCostResult BenefitCost { get; set; }
    }
}