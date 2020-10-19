using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Repositories;

namespace EmployeeBenefitsCostChallenge.Persistence.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public OperationResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var e1 = new Employee("Josh", "Maggard");
            e1.AddDependent(new Dependent("Bob", "Bobson"));
            e1.AddDependent(new Dependent("Alice", "Bobson"));

            var e2 = new Employee("George", "Man");
            var employeeArray = new[] {e1, e2};

            return OperationResult<IEnumerable<Employee>>.Ok(employeeArray);
        }

        public OperationResult<Employee> AddEmployee(Employee newEmployee)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult<Employee> GetEmployeeByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult<Employee> UpdateEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult DeleteEmployee(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
