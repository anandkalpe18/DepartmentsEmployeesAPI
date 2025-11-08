using System.ComponentModel.DataAnnotations;

namespace DepartmentsEmployeesAPI.DTOs.Employee
{
    // For creating a new employee
    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(200)]
        public string EmpName { get; set; } = string.Empty;

        [Required]
        public int DeptId { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        [Range(0, 50)]
        public int YearsOfExperience { get; set; }
    }

    // For updating an existing employee
    public class UpdateEmployeeDto
    {
        [Required]
        public int EmpId { get; set; }

        [Required]
        [StringLength(200)]
        public string EmpName { get; set; } = string.Empty;

        [Required]
        public int DeptId { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        [Range(0, 50)]
        public int YearsOfExperience { get; set; }
    }

    // For retrieving employee data
    public class GetEmployeeDto
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string DeptName { get; set; } = string.Empty;
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }
    }

    
    public class EmployeeDto
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
