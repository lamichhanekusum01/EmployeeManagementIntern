using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Employee, EmployeeViewModel>();

            CreateMap<EmployeeViewModel, Employee>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Employee_Id));


            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.Employee_Id, opt => opt.MapFrom(source => source.EId));

            CreateMap<ApplicationUserViewModel, ApplicationUser>();

            CreateMap<Holiday, HolidayViewModel>();

            CreateMap<HolidayViewModel, Holiday>();
            CreateMap<Leave, LeaveViewModel>();
            CreateMap<LeaveViewModel, Leave>();
            CreateMap<Attendence, AttendenceViewModel>();
            CreateMap<AttendenceViewModel, Attendence>();
        }
    }
}
