using DepartmentsEmployeesAPI.DTOs.Employee;
using System.ComponentModel.DataAnnotations;

namespace DepartmentsEmployeesAPI.DTOs.Department
{
    public class CreateDepartmentDto
    {
        [Required]
        [StringLength(100)]
        public string DeptName { get; set; } = string.Empty;
    }

    public class UpdateDepartmentDto
    {
        [Required]
        public int DeptId { get; set; }

        [Required]
        [StringLength(100)]
        public string DeptName { get; set; } = string.Empty;
    }

    public class GetDepartmentDto
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
    }

    public class DepartmentDto
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; } = string.Empty;
        public List<EmployeeDto>? Employees { get; set; }
    }
}
