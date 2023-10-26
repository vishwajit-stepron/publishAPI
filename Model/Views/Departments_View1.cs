using System.ComponentModel.DataAnnotations;

#nullable enable
namespace StepHR365.Model.Views
{
    public class Departments_View1
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
