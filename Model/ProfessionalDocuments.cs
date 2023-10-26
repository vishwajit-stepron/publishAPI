using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class ProfessionalDocuments 
    {
        [Key]
        public int? ProfessionalDocumentId { get; set; }
        public string? ResignationTerminationLetter { get; set; } 
        public string? PreviousOrganizationAppointmentLetter { get; set; } 
        public string? PreviousOrganizationExperienceCertificate { get; set; } 
        public string? PreviousOrganizationRelievingLetter { get; set; } 

        //public User? User { get; set; } // Define the User navigation property
        // public List<LastThreeSalarySlips>? LastThreeSalarySlips { get; set; }
        //  public List<EducationCertificates>? EducationCertificates { get; set; }
    }
}
