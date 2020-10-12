using System.Collections.Generic;
using System.Linq;
using EmployeeBenefitsCostChallenge.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeBenefitsCostChallenge.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class BenefitCostController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<BenefitCostController> _logger;

        public BenefitCostController(IEmployeeRepository employeeRepository, ILogger<BenefitCostController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BenefitCostData> Get()
        {
            IEnumerable<Employee> allEmployees = _employeeRepository.GetAllEmployees();
            return allEmployees.Select(employee => new BenefitCostData
            {
                Name = $"{employee.FirstName} {employee.LastName}",
                BenefitCost = employee.AnnualBenefitCost,
                PaycheckBenefitCost = employee.BenefitCostPerPaycheck,
                DependentCostData = employee.Dependents.Select(d => new BenefitCostData
                {
                    BenefitCost = d.AnnualBenefitCost,
                    Name = $"{d.FirstName} {d.LastName}",
                    PaycheckBenefitCost = d.BenefitCostPerPaycheck
                }).ToList().AsReadOnly()
            });

        }
    }

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }

    class MockEmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            var e1 = new Employee("Josh", "Maggard");
            e1.AddDependent(new Dependent("Bob", "Bobson"));
            e1.AddDependent(new Dependent("Alice", "Bobson"));

            var e2 = new Employee("George", "Man");
            return new[] { e1, e2 };
        }
    }

    public class BenefitCostData
    {
        public string Name { get; set; }
        public decimal BenefitCost { get; set; }
        public IReadOnlyCollection<BenefitCostData> DependentCostData { get; set; }
        public decimal PaycheckBenefitCost { get; set; }
    }
}

