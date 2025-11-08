using DepartmentsEmployeesAPI.DTOs.Department;

namespace DepartmentsEmployeesAPI.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<GetDepartmentDto>> GetAllAsync();
        Task<GetDepartmentDto?> GetByIdAsync(int id);
        Task AddAsync(CreateDepartmentDto dto);
        Task UpdateAsync(UpdateDepartmentDto dto);
    }
}
