using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class EmployeeInformation 
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? EmployeeNo { get; set; } 
        public string? Name { get; set; } 
        public string? Gender { get; set; } 
        public string? ProfessionalMobile { get; set; } 
        public string? ProfessionalEmail { get; set; } 
        //public User? User { get; set; } // Define the User navigation property
    }
}
