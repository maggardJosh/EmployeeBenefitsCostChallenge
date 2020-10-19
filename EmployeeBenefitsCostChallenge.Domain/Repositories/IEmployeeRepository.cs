using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;

namespace EmployeeBenefitsCostChallenge.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        OperationResult<IEnumerable<Employee>> GetAllEmployees();
        OperationResult<Employee> AddEmployee(Employee newEmployee);
        OperationResult<Employee> GetEmployeeByID(int id);
        OperationResult<Employee> UpdateEmployee(Employee employee);
        OperationResult DeleteEmployee(int id);
    }

}
