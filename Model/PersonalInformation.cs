using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class PersonalInformation 
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? ProfileImage { get; set; } 
        public DateTime? DOB { get; set; } 
        public DateTime? Birthday { get; set; } 
        public string? BloodGroup { get; set; } 
        public string? PersonalEmail { get; set; } 
        public string? PersonalMobileNumber { get; set; }
        public string? EmergencyNumber { get; set; } 
        //public User? User { get; set; } // Define the User navigation property
    }
}
