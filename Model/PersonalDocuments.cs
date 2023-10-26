using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class PersonalDocuments
    {

        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? RecentPhotographs { get; set; } 
        public string? IDProofPanCard { get; set; } 
        public string? AddressProof { get; set; } 
        public string? AadharCard { get; set; } 
        //public User? User { get; set; } // Define the User navigation property
    }
}
