using System.ComponentModel.DataAnnotations;

namespace SupportCenter.EmployeeManager.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        public bool IsDeveloper { get; set; }

        [Required]
        public int? DepartmentID { get; set; }

        public Department Department { get; set; }

        [Timestamp] 
        public byte[]? Timestamp { get; set; }
    }

}
