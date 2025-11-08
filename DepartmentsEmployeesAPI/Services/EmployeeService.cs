using AutoMapper;
using DepartmentsEmployeesAPI.DTOs.Employee;
using DepartmentsEmployeesAPI.Models;
using DepartmentsEmployeesAPI.Repositories;

namespace DepartmentsEmployeesAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEmployeeDto>> GetAllAsync()
        {
            var emps = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<GetEmployeeDto>>(emps);
        }

        public async Task<GetEmployeeDto?> GetByIdAsync(int id)
        {
            var emp = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetEmployeeDto>(emp);
        }

        public async Task<IEnumerable<GetEmployeeDto>> GetByDepartmentIdAsync(int departmentId)
        {
            var emps = await _repo.GetByDepartmentIdAsync(departmentId);
            return _mapper.Map<IEnumerable<GetEmployeeDto>>(emps);
        }

        public async Task AddAsync(CreateEmployeeDto dto)
        {
            var emp = _mapper.Map<Employee>(dto);
            await _repo.AddAsync(emp);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(UpdateEmployeeDto dto)
        {
            var emp = await _repo.GetByIdAsync(dto.EmpId);
            if (emp == null) return;

            _mapper.Map(dto, emp);
            await _repo.UpdateAsync(emp);
            await _repo.SaveAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var emp = await _repo.GetByIdAsync(id);
            if (emp == null) return;

            await _repo.SoftDeleteAsync(emp);
            await _repo.SaveAsync();
        }
    }
}
