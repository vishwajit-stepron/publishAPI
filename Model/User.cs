using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace StepHR365.Model
{
    [Table("Users")]
    public class User 
    {
        [Key]
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string? UserEmail { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ReportingManager { get; set; }
        public DateTime? JoiningDate { get; set; } = DateTime.Now;
        public bool? Status { get; set; } = true;
        public bool? IsAdmin { get; set; } = false;
        public bool? IsDeleted { get; set; } = false;

        public int? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; } = DateTime.Now;
        public DateTime? LastAccess { get; set; } = DateTime.Now;
    }
}
