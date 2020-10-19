using System.Collections.Generic;
using System.Linq;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitsCostChallenge.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _dbContext;

        public EmployeeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees
                .Include(employee => employee.Dependents )
                .ToList();
        }

        public void AddEmployee(Employee newEmployee)
        {
            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();
        }

        public Employee GetById(int id)
        {
            //TODO: Handle null
            return _dbContext.Employees
                .Include(employee => employee.Dependents)
                .FirstOrDefault(e => e.EmployeeID == id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Attach(employee);
            _dbContext.SaveChanges();
            return employee;
        }
    }
}
