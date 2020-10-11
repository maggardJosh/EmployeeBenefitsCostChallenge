namespace EmployeeBenefitsCostChallenge.DomainModels
{
    public class Dependent : Person
    {
        protected override decimal StandardAnnualBenefitCost => 500; //Ideally would make this driven by data

        public Dependent(string firstName, string lastName) : base(firstName, lastName)
        {
        }
    }
}
