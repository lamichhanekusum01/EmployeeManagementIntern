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
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
            

        }
    }
}
    