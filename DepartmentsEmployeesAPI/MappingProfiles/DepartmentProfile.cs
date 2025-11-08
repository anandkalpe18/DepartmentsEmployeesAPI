using AutoMapper;
using DepartmentsEmployeesAPI.DTOs.Department;
using DepartmentsEmployeesAPI.Models;

namespace DepartmentsEmployeesAPI.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            
            CreateMap<Department, GetDepartmentDto>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DeptId))
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count));

            
            CreateMap<CreateDepartmentDto, Department>()
                .ForMember(dest => dest.DeptId, opt => opt.Ignore());

           
            CreateMap<UpdateDepartmentDto, Department>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DeptId));

           
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DeptId));

            CreateMap<DepartmentDto, Department>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DeptId));
        }
    }
}
