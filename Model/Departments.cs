using System.ComponentModel.DataAnnotations;

namespace StepHR365.Model
{
    public class Departments 
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
