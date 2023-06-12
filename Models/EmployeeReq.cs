using System.ComponentModel.DataAnnotations;

namespace WebAPI_Practice.Models
{
    public class EmployeeReq
    {
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50, ErrorMessage = "Employee name cannot exceed 50 characters")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public double Salary { get; set; }
        [Required(ErrorMessage = "Department Id is required")]
        public int DepartmentId { get; set; }

    }
}
