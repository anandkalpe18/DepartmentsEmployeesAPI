using AutoMapper;
using DepartmentsEmployeesAPI.DTOs.Employee;
using DepartmentsEmployeesAPI.DTOs.Department;
using DepartmentsEmployeesAPI.Models;

namespace DepartmentsEmployeesAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Department
            CreateMap<Department, GetDepartmentDto>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DeptId))
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count));

            CreateMap<CreateDepartmentDto, Department>()
                .ForMember(dest => dest.DeptId, opt => opt.Ignore());

            CreateMap<UpdateDepartmentDto, Department>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DeptId));

            // Employee
            CreateMap<Employee, GetEmployeeDto>()
                .ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.Department.DeptName));

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
