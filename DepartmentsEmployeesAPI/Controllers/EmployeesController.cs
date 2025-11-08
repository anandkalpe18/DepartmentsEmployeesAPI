using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DepartmentsEmployeesAPI.Services;
using DepartmentsEmployeesAPI.DTOs.Employee;

namespace DepartmentsEmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _service.GetByIdAsync(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpGet("ByDepartment/{deptId}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetByDepartmentId(int deptId)
        {
            return Ok(await _service.GetByDepartmentIdAsync(deptId));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Employee created successfully");
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateEmployeeDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("Employee updated successfully");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _service.SoftDeleteAsync(id);
            return Ok("Employee deleted (soft delete) successfully");
        }
    }
}
