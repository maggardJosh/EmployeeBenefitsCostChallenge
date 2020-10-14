using System.Collections.Generic;

namespace EmployeeBenefitsCostChallenge.API.Employee.Models
{
    public class EmployeeData : PersonData
    {
        public int ID { get; set; }
        public IReadOnlyCollection<PersonData> DependentData { get; set; }

    }
}