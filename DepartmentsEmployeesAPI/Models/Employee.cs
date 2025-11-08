


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentsEmployeesAPI.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DeptId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmpName { get; set; } = string.Empty;

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Range(0, 50)]
        public int YearsOfExperience { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Department? Department { get; set; }
    }
}
