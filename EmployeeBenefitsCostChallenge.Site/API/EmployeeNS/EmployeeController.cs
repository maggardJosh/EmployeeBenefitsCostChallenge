using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeBenefitsCostChallenge.API.EmployeeNS.Models;
using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;
using EmployeeBenefitsCostChallenge.Domain.Repositories;
using EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeBenefitsCostChallenge.API.EmployeeNS
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IBenefitCostService _benefitCostService;

        public EmployeeController(IEmployeeRepository employeeRepository,
                                    ILogger<EmployeeController> logger,
                                    IBenefitCostService benefitCostService)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _benefitCostService = benefitCostService;
        }

        [HttpGet]
        public ActionResult RetrieveAllEmployeeData()
        {
            try
            {
                var allEmployeeOperation = _employeeRepository.GetAllEmployees();
                if (!allEmployeeOperation.Success)
                    return null;
                IEnumerable<Employee> allEmployees = allEmployeeOperation.Result;
                return Ok(allEmployees.Select(employee => new EmployeeBenefitModel(employee, _benefitCostService)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all employee data");
                return BadRequest();
            }
        }

        [HttpGet("{id}", Name = "GetEmployeeRoute")]
        public ActionResult GetEmployeeByID(int id)
        {
            try
            {
                var employeeOperation = _employeeRepository.GetEmployeeByID(id);
                if (!employeeOperation.Success)
                    return BadRequest();

                return Ok(employeeOperation.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employee data");
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Employee newEmployee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _employeeRepository.AddEmployee(newEmployee);
            return CreatedAtRoute("GetEmployeeRoute", new { id = newEmployee.EmployeeID }, newEmployee);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Employee employeeData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var updateEmployeeOperation = _employeeRepository.UpdateEmployee(employeeData);
            if (!updateEmployeeOperation.Success)
                return BadRequest(updateEmployeeOperation.Message);

            return AcceptedAtRoute("GetEmployeeRoute", new { id = id }, updateEmployeeOperation.Result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            OperationResult deleteOperation = _employeeRepository.DeleteEmployee(id);
            if (!deleteOperation.Success)
                return BadRequest(deleteOperation.Message);
            return Accepted();
        }
    }
}