﻿using EmployeeBenefitsCostChallenge.Domain.Common;

namespace EmployeeBenefitsCostChallenge.Domain.Models.EmployeeAggregate
{
    public class Dependent : Person
    {
        public int ID { get; set; }

        public Dependent() { }
        public Dependent(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        //TODO: Potentially cover this function in tests
        public override decimal GetStandardAnnualBenefitCost(IBenefitCostSettingsRepository settingsRepository)
        {
            return settingsRepository.DependentAnnualBenefitCost;
        }
    }
}