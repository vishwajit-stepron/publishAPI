using System.ComponentModel.DataAnnotations;

#nullable enable
namespace StepHR365.Model
{
    public class Education  
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Qualification { get; set; } 
        public DateTime? From { get; set; } 
        public DateTime? To { get; set; } 
        public string? Institute { get; set; }
        public string? Grade { get; set; } 
        //public User? User { get; set; } // Define the User navigation property
    }
}
