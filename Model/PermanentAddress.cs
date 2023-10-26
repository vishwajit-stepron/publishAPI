using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class PermanentAddress
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Street { get; set; } 
        public string? City { get; set; } 
        public string? State { get; set; } 
        public string? Country { get; set; } 
        public string? PinCode { get; set; } 
        //public User? User { get; set; } // Define the User navigation property
    }
}
