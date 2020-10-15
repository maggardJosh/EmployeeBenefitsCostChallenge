using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EmployeeBenefitsCostChallenge.API.Employee.Models;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost;
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
            IEnumerable<Domain.Models.EmployeeAggregate.Employee> allEmployees = _employeeRepository.GetAllEmployees();
            return allEmployees.Select(CreateEmployeeData);
        }

        private EmployeeData CreateEmployeeData(Domain.Models.EmployeeAggregate.Employee employee)
        {
            return new EmployeeData
            {
                ID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BenefitCost = _benefitCostService.GetBenefitCost(employee),
                Dependents = employee.Dependents.Select(dependent => new EmployeeData
                {
                    FirstName = dependent.FirstName,
                    LastName = dependent.LastName,
                    BenefitCost = _benefitCostService.GetBenefitCost(dependent),
                }).ToList().AsReadOnly()
            };
        }

        [HttpPost]
        public EmployeeData Post(NewEmployeeData newEmployeeData)
        {
            Domain.Models.EmployeeAggregate.Employee newEmployee = new Domain.Models.EmployeeAggregate.Employee(newEmployeeData.FirstName, newEmployeeData.LastName);
            foreach(var d in newEmployeeData.DependentData)
                newEmployee.AddDependent(new Dependent(d.FirstName, d.LastName));
            return CreateEmployeeData(newEmployee);
        }

        [HttpGet("{id}")]
        public EmployeeData GetByID(int id)
        {
            Domain.Models.EmployeeAggregate.Employee e = _employeeRepository.GetById(id);
            return CreateEmployeeData(e);
        }
    }

    public class NewEmployeeData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public NewDependentData[] DependentData { get; set; }
    }

    public class NewDependentData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}