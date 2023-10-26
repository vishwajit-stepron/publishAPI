using System.ComponentModel.DataAnnotations;

#nullable enable
namespace StepHR365.Model.Views
{
    public class User_View1
    {
        [Key]
        public int? Id { get; set; }
        public int? DepartmentId { get; set; }
        public string? ReportingManager { get; set; }
        public DateTime? JoiningDate { get; set; }
        public bool? Status { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsDeleted { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? LastAccess { get; set; }


        // EmplpoyeeInformation
        public int? empId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? ProfessionalMobile { get; set; }
        public string? ProfessionalEmail { get; set; }


        // PersonalInformation
        public int? pinfoId { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? Birthday { get; set; }
        public string? BloodGroup { get; set; }
        public string? PersonalEmail { get; set; }
        public string? PersonalMobileNumber { get; set; }
        public string? EmergencyNumber { get; set; }

        // PresentAddress
        public int? PresentAddressId { get; set; }
        public string? PresentStreet { get; set; }
        public string? PresentCity { get; set; }
        public string? PresentState { get; set; }
        public string? PresentCountry { get; set; }
        public string? PresentPinCode { get; set; }

        //permanentAddress
        public int? PermanentAddressId { get; set; }
        public string? PermanentStreet { get; set; }
        public string? PermanentCity { get; set; }
        public string? PermanentState { get; set; }
        public string? PermanentCountry { get; set; }
        public string? PermanentPinCode { get; set; }

        //employeeIdentity
        public int? empIdentityId { get; set; }
        public string? AadhaarNumber { get; set; }
        public string? NameInAadhaar { get; set; }
        public string? PANNumber { get; set; }
        public string? NameInPAN { get; set; }

        //education
        public int? educationId { get; set; }
        public string? Qualification { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? Institute { get; set; }
        public string? Grade { get; set; }

        //personalDocuments
        public int? pdId { get; set; }
        public string? RecentPhotographs { get; set; }
        public string? IDProofPanCard { get; set; }
        public string? AddressProof { get; set; }
        public string? AadharCard { get; set; }

        //JoiningDetails
        public int? joiningdId { get; set; }
        public DateTime? JoinedOn { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string? ProbationPeriod { get; set; }
        public string? NoticePeriod { get; set; }
        public string? EmployeeStatus { get; set; }

        //currentPosition
        public int? cpositionId { get; set; }
        public string? Location { get; set; }
        public string? Designation { get; set; }
        public string? ReportingTo { get; set; }
        public string? WeekOff { get; set; }
        public string? GeoTracking { get; set; }

    }
}
