﻿using System.Collections.Generic;
using EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate;

namespace EmployeeBenefitsCostChallenge.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }

}
