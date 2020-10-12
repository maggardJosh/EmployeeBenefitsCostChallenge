using System;
using System.Collections.Generic;
using System.Text;
using EmployeeBenefitsCostChallenge.Domain.DomainModels.EmployeeAggregate;

namespace EmployeeBenefitsCostChallenge.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }

}
