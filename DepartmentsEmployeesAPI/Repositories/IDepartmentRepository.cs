using DepartmentsEmployeesAPI.Models;

namespace DepartmentsEmployeesAPI.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task AddAsync(Department department);
        Task UpdateAsync(Department department);
        Task SaveAsync();
    }
}
