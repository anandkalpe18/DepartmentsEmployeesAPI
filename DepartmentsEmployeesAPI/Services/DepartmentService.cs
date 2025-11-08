using AutoMapper;
using DepartmentsEmployeesAPI.DTOs.Department;
using DepartmentsEmployeesAPI.Models;
using DepartmentsEmployeesAPI.Repositories;

namespace DepartmentsEmployeesAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDepartmentDto>> GetAllAsync()
        {
            var depts = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<GetDepartmentDto>>(depts);
        }

        public async Task<GetDepartmentDto?> GetByIdAsync(int id)
        {
            var dept = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetDepartmentDto>(dept);
        }

        public async Task AddAsync(CreateDepartmentDto dto)
        {
            var dept = _mapper.Map<Department>(dto);
            await _repo.AddAsync(dept);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(UpdateDepartmentDto dto)
        {
            var dept = await _repo.GetByIdAsync(dto.DeptId);
            if (dept == null) return;

            _mapper.Map(dto, dept);
            await _repo.UpdateAsync(dept);
        }
    }
}
