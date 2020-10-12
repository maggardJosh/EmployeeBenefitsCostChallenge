using System.Collections.Generic;
using System.Linq;
using EmployeeBenefitsCostChallenge.API.Employee.Models;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeBenefitsCostChallenge.API.Employee
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<EmployeeData> Get()
        {
            IEnumerable<Domain.DomainModels.EmployeeAggregate.Employee> allEmployees = _employeeRepository.GetAllEmployees();
            return allEmployees.Select(employee => new EmployeeData
            {
                Name = $"{employee.FirstName} {employee.LastName}",
                BenefitCost = employee.AnnualBenefitCost,
                PaycheckBenefitCost = employee.BenefitCostPerPaycheck,
                DependentData = employee.Dependents.Select(d => new EmployeeData
                {
                    BenefitCost = d.AnnualBenefitCost,
                    Name = $"{d.FirstName} {d.LastName}",
                    PaycheckBenefitCost = d.BenefitCostPerPaycheck
                }).ToList().AsReadOnly()
            });

        }
    }
}