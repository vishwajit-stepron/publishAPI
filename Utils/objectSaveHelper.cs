using Org.BouncyCastle.Bcpg;
using StepHR365.Model;

namespace StepHR365.Utils
{
    public class objectSaveHelper
    {
        public User? User { get; set; }
        public Departments? Department { get; set; }
        public EmployeeInformation? EmployeeInformation { get; set; }
        public PersonalInformation? PersonalInformation { get; set; }
        public PresentAddress? PresentAddress { get; set; }
        public PermanentAddress? PermanentAddress { get; set; }
        public EmployeeIdentity? EmployeeIdentity { get; set; }
        public Education? Education { get; set; }
        public PersonalDocuments? PersonalDocuments { get; set; }
        public JoiningDetails? JoiningDetails { get; set; }
        public CurrentPosition? CurrentPosition { get; set; }
        //public List<ProfessionalDocuments>? ProfessionalDocuments { get; set; }
    }
}
