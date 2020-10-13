using System.ComponentModel.DataAnnotations;

namespace EmployeeBenefitsCostChallenge.Persistence
{
    public class ApplicationSettings
    {
        [Key]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}