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
using static EmployeeManagement.Repository.AttendenceRepository;

namespace EmployeeManagement.Service
{
    public interface IAttendenceProvider
    {

        List<Employee> GetEmployees();

        int SaveAttendence(AttendenceViewModel model);


        AttendenceViewModel GetById(int id);
        AttendenceViewModel GetList();


    }
    public class AttendenceProvider : IAttendenceProvider
    {
        private readonly IAttendenceRepository _iAttendenceRepository;
        private readonly IMapper _mapper;
        private EmployeeManagementDbContext _context;

        public AttendenceProvider(IAttendenceRepository iAttendenceRepository, EmployeeManagementDbContext context, IMapper mapper)
        {
            _iAttendenceRepository = iAttendenceRepository;
            _mapper = mapper;
            _context = context;

        }

        public int DeleteAttendence(int Id)
        {
            throw new NotImplementedException();
        }


        public AttendenceViewModel GetById(int id)
        {
            var item = _iAttendenceRepository.GetSingle(x => x.Attendence_Id == id);
            AttendenceViewModel data = _mapper.Map<AttendenceViewModel>(item);
            return data;
        }

        public AttendenceViewModel GetList()
        {
            AttendenceViewModel model = new AttendenceViewModel();
            var list = new List<AttendenceViewModel>();
            List<Attendence> data = _iAttendenceRepository.GetAll().ToList();
            list = _mapper.Map<List<Attendence>, List<AttendenceViewModel>>(data);
            model.AttendenceList = list;
            return model;
        }

        public int SaveAttendence(AttendenceViewModel model)
        {
            //Attendence attendence = new Attendence();
            //attendence = _mapper.Map<Attendence>(model);
            //if(model.Type=="TurnIn")
            //{

            //    _iAttendenceRepository.Add(attendence);
            //}
            //else
            //{
            //    _iAttendenceRepository.Update(attendence);
            //}
            //return 200;
            //changes

            var today2 = DateTime.Today;
            if (model.Type == "TurnIn")
            {

                var attendence1 = _iAttendenceRepository.GetSingle(x => x.Turn_in > today2 && x.Employee_Id == model.Employee_Id);
                if (attendence1 == null)
                {
                    Attendence attendence = new Attendence();
                    attendence = _mapper.Map<Attendence>(model);
                    attendence.Turn_in = DateTime.Now;
                    _iAttendenceRepository.Add(attendence);
                }
            }
            else
            {
                var attendence = _iAttendenceRepository.GetSingle(x => x.Turn_in > today2 && x.Employee_Id == model.Employee_Id);
                if (attendence == null)
                { }
                else
                {
                    attendence.Turn_out = DateTime.Now;
                    _iAttendenceRepository.Update(attendence);
                }

            }
            return 200;
        }

        public List<Employee> GetEmployees()
        {
            var EmpList = new List<Employee>();
            var Emp = _context.Employees.ToList();
            foreach (var item in Emp)
            {
                EmpList.Add(item);
            }
            return EmpList;
        }
    }

    //public int DeleteHoliday( int Id)
    //{
    //    var item = _iHolidayRepository.GetSingle(x => x.Holiday_Id == Holiday_Id);
    //    _iHolidayRepository.Delete(item);
    //}
}

