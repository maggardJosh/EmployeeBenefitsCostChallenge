using System;

namespace EmployeeBenefitsCostChallenge.Domain.Services.BenefitCost.Models
{
    public class BenefitCostResult
    {
        private decimal _annualBenefitCost;
        private decimal _paycheckBenefitCost;

        public decimal AnnualBenefitCost
        {
            get => Math.Round(_annualBenefitCost, 2);
            set => _annualBenefitCost = value;
        }

        public decimal PaycheckBenefitCost
        {
            get => Math.Round(_paycheckBenefitCost, 2);
            set => _paycheckBenefitCost = value;
        }
    }
}