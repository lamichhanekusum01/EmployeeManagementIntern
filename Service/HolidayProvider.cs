using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagement.Repository.HolidayRepository;

namespace EmployeeManagement.Service
{
    public interface IHolidayProvider
    {
       int SaveHoliday(HolidayViewModel model);
       int  DeleteHoliday(int Id);


    }
    public class HolidayProvider : IHolidayProvider
    {
        private readonly IHolidayRepository _iHolidayRepository;
        private readonly IMapper _mapper;
        private EmployeeManagementDbContext _context;

        public HolidayProvider(IHolidayRepository iHolidayRepository, EmployeeManagementDbContext context, IMapper mapper)
        {
            _iHolidayRepository = iHolidayRepository;
            _mapper = mapper;
            _context = context;

        }

        public int DeleteHoliday(int Id)
        {
            throw new NotImplementedException();
        }

        public int SaveHoliday(HolidayViewModel model)
        {
            Holiday holiday = new Holiday();
            holiday = _mapper.Map<Holiday>(model);
            _iHolidayRepository.Add(holiday);
            return 200;


        }
          
        }

        //public int DeleteHoliday( int Id)
        //{
        //    var item = _iHolidayRepository.GetSingle(x => x.Holiday_Id == Holiday_Id);
        //    _iHolidayRepository.Delete(item);
        //}
    }

