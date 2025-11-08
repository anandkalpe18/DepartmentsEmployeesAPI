using AutoMapper;
using DepartmentsEmployeesAPI.Models;
using DepartmentsEmployeesAPI.DTOs.Employee;

namespace DepartmentsEmployeesAPI.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {

            CreateMap<Employee, GetEmployeeDto>()
                .ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.Department.DeptName));

            CreateMap<CreateEmployeeDto, Employee>();

            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
