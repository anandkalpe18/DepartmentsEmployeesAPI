using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentsEmployeesAPI.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }

        [Required]
        [StringLength(100)]
        public string DeptName { get; set; } = string.Empty;
        public ICollection<Employee>? Employees { get; set; }
    }
}
