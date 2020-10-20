using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmployeeBenefitsCostChallenge.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(DatabaseContext dbContext, ILogger<EmployeeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public OperationResult<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                var allEmployees = _dbContext.Employees
                    .Include(employee => employee.Dependents)
                    .ToList();
                return OperationResult<IEnumerable<Employee>>.Ok(allEmployees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception while retrieving all employees");
                return OperationResult<IEnumerable<Employee>>.Error("Unable to retrieve employees");
            }
        }

        public OperationResult<Employee> AddEmployee(Employee newEmployee)
        {
            try
            {
                _dbContext.Employees.Attach(newEmployee);
                _dbContext.SaveChanges();
                return OperationResult<Employee>.Ok(newEmployee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception while inserting employee");
                return OperationResult<Employee>.Error("Unable to add employee");
            }
        }

        public OperationResult<Employee> GetEmployeeByID(int id)
        {
            try
            {
                var employee = _dbContext.Employees
                    .Include(employee => employee.Dependents)
                    .FirstOrDefault(e => e.EmployeeID == id);
                if (employee == null)
                    return OperationResult<Employee>.Error("Employee Not Found");
                return OperationResult<Employee>.Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception while retrieving employee", id);
                return OperationResult<Employee>.Error("Unable to retrieve employee");
            }
        }

        public OperationResult<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                var employeeOperation = GetEmployeeByID(employee.EmployeeID);
                if(!employeeOperation.Success)
                    return OperationResult<Employee>.Error(employeeOperation.Message);

                Employee employeeToUpdate = employeeOperation.Result;

                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.ClearDependents();
                foreach(var dependent in employee.Dependents)
                    employeeToUpdate.AddDependent(dependent);

                _dbContext.SaveChanges();
                return OperationResult<Employee>.Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception while updating employee", employee);
                return OperationResult<Employee>.Error("Unhandled Exception while updating Employee");
            }
        }

        public OperationResult DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = _dbContext.Employees.FirstOrDefault(e => e.EmployeeID == id);
                if (employeeToDelete == null)
                    return OperationResult.Error("Employee not found to delete");

                _dbContext.Employees.Remove(employeeToDelete);
                _dbContext.SaveChanges();
                return OperationResult.Ok;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception while deleting employee", id);
                return OperationResult.Error("Unable to remove employee");
            }
        }
    }
}
