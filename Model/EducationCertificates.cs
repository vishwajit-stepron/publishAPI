using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class EducationCertificates
    {

        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? FilePath { get; set; } 
        public int? ProfessionalDocumentId { get; set; }
        //public ProfessionalDocuments? ProfessionalDocuments { get; set; } // Define the ProfessionalDocuments navigation property

    }
}
