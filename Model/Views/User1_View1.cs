using System.ComponentModel.DataAnnotations;

#nullable enable
namespace StepHR365.Model.Views
{
    public class User1_View1
    {
        [Key]
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string? UserEmail { get; set; }
        public string? Username { get; set; }
        public string? ReportingManager { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? EmployeeStatus { get; set; }
        public bool? Status { get; set; } = true;
        public bool? IsAdmin { get; set; } = false;
        public bool? IsDeleted { get; set; } = false;

        public int? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? LastAccess { get; set; }
    }
}
