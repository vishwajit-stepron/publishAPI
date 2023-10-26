using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class JoiningDetails 
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? JoinedOn { get; set; }
        public DateTime? ConfirmationDate { get; set; } 
        public string? Status { get; set; } 
        public string? ProbationPeriod { get; set; } 
        public string? NoticePeriod { get; set; } 
        //public User? User { get; set; } // Define the User navigation property
    }
}
