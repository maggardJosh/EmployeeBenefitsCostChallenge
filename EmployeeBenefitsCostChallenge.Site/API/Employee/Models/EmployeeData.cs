using System.Collections.Generic;

namespace EmployeeBenefitsCostChallenge.API.Employee.Models
{
    public class EmployeeData : PersonData
    {
        public IReadOnlyCollection<PersonData> DependentData { get; set; }

    }
}