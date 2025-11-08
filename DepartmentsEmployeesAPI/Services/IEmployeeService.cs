using DepartmentsEmployeesAPI.DTOs.Employee;

namespace DepartmentsEmployeesAPI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<GetEmployeeDto>> GetAllAsync();
        Task<GetEmployeeDto?> GetByIdAsync(int id);
        Task<IEnumerable<GetEmployeeDto>> GetByDepartmentIdAsync(int departmentId);
        Task AddAsync(CreateEmployeeDto dto);
        Task UpdateAsync(UpdateEmployeeDto dto);
        Task SoftDeleteAsync(int id);
    }
}
