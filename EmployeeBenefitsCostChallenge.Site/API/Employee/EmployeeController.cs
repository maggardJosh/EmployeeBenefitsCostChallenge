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

        [HttpGet("{id}", Name = "GetEmployeeRoute")]
        public EmployeeData GetByID(int id)
        {
            Domain.Models.EmployeeAggregate.Employee e = _employeeRepository.GetById(id);
            return CreateEmployeeData(e);
        }

        [HttpPost]
        public ActionResult Post([FromBody]NewEmployeeData newEmployeeData)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Domain.Models.EmployeeAggregate.Employee newEmployee = new Domain.Models.EmployeeAggregate.Employee(newEmployeeData.FirstName, newEmployeeData.LastName);
            foreach(var dependentData in newEmployeeData.Dependents)
                newEmployee.AddDependent(new Dependent(dependentData.FirstName, dependentData.LastName));
            _employeeRepository.AddEmployee(newEmployee);
            //TODO: Try catch log return error
            return CreatedAtRoute("GetEmployeeRoute", new {id = newEmployee.EmployeeID}, CreateEmployeeData(newEmployee));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] NewEmployeeData employeeData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Domain.Models.EmployeeAggregate.Employee employeeToUpdate = _employeeRepository.GetById(id);

            employeeToUpdate.FirstName = employeeData.FirstName;
            employeeToUpdate.LastName = employeeData.LastName;
            employeeToUpdate.ClearDependents();
            foreach(var dependentData in employeeData.Dependents)
                employeeToUpdate.AddDependent(new Dependent(dependentData.FirstName, dependentData.LastName));

            var updatedEmployee = _employeeRepository.UpdateEmployee(employeeToUpdate);
            
            return AcceptedAtRoute("GetEmployeeRoute", new {id = id}, CreateEmployeeData(updatedEmployee));
        }

    }

    public class NewEmployeeData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public NewDependentData[] Dependents { get; set; }
    }

    public class NewDependentData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}