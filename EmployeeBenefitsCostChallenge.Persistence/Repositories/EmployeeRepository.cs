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
    }
}
