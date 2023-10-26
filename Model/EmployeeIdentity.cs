using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class EmployeeIdentity
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? AadhaarNumber { get; set; } 
        public string? NameInAadhaar { get; set; } 
        public string? PANNumber { get; set; } 
        public string? NameInPAN { get; set; } 
        //public User? User { get; set; } // Define the User navigation property
    }
}
