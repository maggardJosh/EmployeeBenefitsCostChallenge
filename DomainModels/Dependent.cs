namespace EmployeeBenefitsCostChallenge.DomainModels
{
    public class Dependent : Person
    {
        protected override double StandardAnnualBenefitCost => 500; //Ideally would make this driven by data
    }
}
