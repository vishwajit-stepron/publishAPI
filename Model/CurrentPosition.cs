using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable enable
namespace StepHR365.Model
{
    public class CurrentPosition 
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Location { get; set; } 
        public string? Designation { get; set; } 
        public string? ReportingTo { get; set; } 
        public string? WeekOff { get; set; } 
        public string? GeoTracking { get; set; } 
        //public User? User { get; set; } // Define the User navigation property
    }
}
