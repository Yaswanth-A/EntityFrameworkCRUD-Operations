using System.ComponentModel.DataAnnotations;

namespace WebAPI_Practice.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required (ErrorMessage ="Department Name is required")]
        [StringLength(50, ErrorMessage ="Department name cannot exceed 50 characters")]
        public string DepartmentName { get; set; }
    }
}
