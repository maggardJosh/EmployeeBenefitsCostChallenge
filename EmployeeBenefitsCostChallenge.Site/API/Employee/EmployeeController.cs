using System.Collections.Generic;
using System.Linq;
using EmployeeBenefitsCostChallenge.API.Employee.Models;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
using EmployeeBenefitsCostChallenge.Domain.Services;
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
        private readonly IBenefitCostService _benefitCostService;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IBenefitCostService benefitCostService)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _benefitCostService = benefitCostService;
        }

        [HttpGet]
        public IEnumerable<EmployeeData> Get()
        {
            IEnumerable<Domain.DomainModels.EmployeeAggregate.Employee> allEmployees = _employeeRepository.GetAllEmployees();
            return allEmployees.Select(employee => new EmployeeData
            {
                Name = $"{employee.FirstName} {employee.LastName}",
                BenefitCost = _benefitCostService.GetBenefitCost(employee),
                DependentData = employee.Dependents.Select(d => new EmployeeData
                {
                    Name = $"{d.FirstName} {d.LastName}",
                    BenefitCost = _benefitCostService.GetBenefitCost(d),
                }).ToList().AsReadOnly()
            });

        }
    }
}