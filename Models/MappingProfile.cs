using AutoMapper;
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
            CreateMap<Employee, EmployeeViewModel>()
           //   .ForMember(dest => dest.GenderName, o => o.MapFrom(src => src.GenderName))
            .ForMember(dest => dest.Gender_Id, o => o.MapFrom(src => src.Gender_Id))

            .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.MiddleName, o => o.MapFrom(src => src.MiddleName))
            .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.LastName))
             .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.UserName))
            //.ForMember(dest => dest.Gender_Name, o => o.MapFrom(src => src.Gender_Name))
            .ForMember(dest => dest.Address, o => o.MapFrom(src => src.Address))
            .ForMember(dest => dest.DesignationName, o => o.MapFrom(src => src.DesignationName))
            .ForMember(dest => dest.Dob, o => o.MapFrom(src => src.Dob))
            .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
            .ForMember(dest => dest.Salary, o => o.MapFrom(src => src.Salary))
            .ForMember(dest => dest.Phone, o => o.MapFrom(src => src.Phone));
          //  .ForMember(dest => dest.Gender_Id, o => o.MapFrom(src => src.Gender_Id))
          //  .ForMember(dest => dest.Gender_Name, o => o.MapFrom(src => src.Gender_Name));
          
            CreateMap<EmployeeViewModel, Employee>();
            

        }
    }
}
    