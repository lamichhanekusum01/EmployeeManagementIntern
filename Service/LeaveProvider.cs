using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Service
{
    public interface ILeaveProvider
    {
        int SaveLeave(LeaveViewModel model);
        LeaveViewModel GetById(int id);
        LeaveViewModel GetList();
        List<Employee> GetEmployees();
        List<ApplicationUser> GetUsers();
        LeaveViewModel GetApprovedLeave();
        int EditLeave(LeaveViewModel model);
        List<CalenderViewModel> GetCalendarDataByYearAndMonth(string eid, string year, string month);





    }
    public class LeaveProvider : ILeaveProvider
    {
        private readonly ILeaveRepository _iLeaveRepository;
        private readonly IMapper _mapper;
        private EmployeeManagementDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager; 

        private readonly IHolidayRepository _iHolidayRepository;
        private readonly IAttendenceRepository _iAttendenceRepository;

        public LeaveProvider(IAttendenceRepository iAttendenceRepository, IHolidayRepository iHolidayRepository, UserManager<ApplicationUser> userManager, ILeaveRepository iLeaveRepository, IMapper mapper, EmployeeManagementDbContext context)
        {
            _iAttendenceRepository = iAttendenceRepository;
            _iHolidayRepository = iHolidayRepository;
            _userManager = userManager;
            _iLeaveRepository = iLeaveRepository;
            _mapper = mapper;
            _context = context;
        }

        public int DeleteLeave(int Id)
        {
            throw new NotImplementedException();
        }

        public LeaveViewModel GetById(int id)
        {

            var item = _iLeaveRepository.GetSingle(x => x.Leave_Id == id);
            LeaveViewModel data = _mapper.Map<LeaveViewModel>(item);
            return data;
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

        public List<ApplicationUser> GetUsers()
        {
            var UserList = new List<ApplicationUser>();
            List<ApplicationUser> usersList = _userManager.Users.ToList();
            foreach (var item in usersList)
            {
                UserList.Add(item);
            }
            return UserList;
        }
        public LeaveViewModel GetList()
        {
            LeaveViewModel model = new LeaveViewModel();
            var list = new List<LeaveViewModel>();
            List<Leave> data = _iLeaveRepository.GetAll().ToList();
            list = _mapper.Map<List<Leave>, List<LeaveViewModel>>(data);
            model.LeaveList = list;
            return model;
        }
        public int SaveLeave(LeaveViewModel model)
        {
            string usrId = model.UserId;
            Leave leave = _mapper.Map<LeaveViewModel, Leave>(model);
            var usr = _iLeaveRepository.GetSingle(x => x.UserId == model.UserId);
            var singleUser = _context.Users.Where(x => x.Id == usrId).First();
            leave.UserId = singleUser.Id;
            _iLeaveRepository.Add(leave);
            _context.Users.Attach(singleUser);
            _context.SaveChanges();
            return 200;


        }
        public LeaveViewModel GetApprovedLeave()
        {
            LeaveViewModel model = new LeaveViewModel();
            var list = new List<LeaveViewModel>();
            List<Leave> data = _iLeaveRepository.GetAll().ToList();
            foreach (var item in data)
            {
                if (item.LeaveStatus == true)
                {
                    list = _mapper.Map<List<Leave>, List<LeaveViewModel>>(data);
                    model.LeaveList = list;
                }
            }
            return model;



        }
        public int EditLeave(LeaveViewModel model)
        {
            Leave leave = new Leave();
            leave = _mapper.Map<Leave>(model);
            _iLeaveRepository.Update(leave);
            return 200;
        }

        public List<CalenderViewModel> GetCalendarDataByYearAndMonth(string eid, string year, string month)
        {

            //var users = _context.Users.Find();
            
            //int EmpId = Convert.ToInt32(eid);
           int EmpId =3;
            int monthInt = 0; 
            if (month == "0")
                monthInt = 1;
            else if (month == "1")
                monthInt = 2;
           
            DateTime firstDate = Convert.ToDateTime(monthInt + "/01/" + year);
            DateTime lastDate = Convert.ToDateTime(monthInt + "/28/" + year);
            List<CalenderViewModel> calenderViewLists = new();
            List<Attendence> attendance = _iAttendenceRepository
                .GetAll(x => x.Employee_Id == EmpId)
                .Where(x => x.Date <= lastDate && x.Date >= firstDate).ToList();
            //List<Leave> leave = _iLeaveRepository.GetAll(x => x.EId == EmpId).Where(x => x.LeaveDate <= lastDate && x.LeaveDate >= firstDate).ToList();
            List<Holiday> holiday = _iHolidayRepository.GetAll().Where(x => x.HolidayDate <= lastDate && x.HolidayDate >= firstDate).ToList();
            List<Leave> leave = _iLeaveRepository.GetAll(x => x.EId == EmpId).Where(x => x.LeaveDate <= lastDate && x.LeaveDate >= firstDate).ToList();

            if (holiday != null)
            {
                foreach (var item in holiday)
                {
                    CalenderViewModel model = new();
                    model.Day = item.HolidayDate.Day.ToString();
                    model.Status = item.HolidayName;
                    model.Type = "Holiday";
                    calenderViewLists.Add(model);
                }
            }

            if (leave != null)
            {
                foreach (var item in leave)
                {
                    CalenderViewModel model = new();
                    model.Day = item.LeaveDate.Day.ToString();
                    model.Status = item.Leave_Reason;
                    model.Type = "Leave";
                    model.NoOfDays = item.LeaveDays;
                    calenderViewLists.Add(model);

                }
            }

            if (attendance != null)
            {
                foreach (var item in attendance)
                {
                    CalenderViewModel model = new();

                    model.Day = item.Date.Day.ToString();
                    model.Type = "Attendence";

                    if (item.Turn_in.Hour > 10)
                    {
                        model.Status = "Late";
                    }

                    if (item.Turn_out.ToString() == "0001-01-01 00:00:00.0000000")
                    {
                        model.Status = "Not Checked Out";
                    }

                    if (item.Turn_out.Hour < 5)
                    {
                        model.Status = "Half Day";
                    }

                    if (item.Turn_out.Hour >= 7)
                    {
                        model.Status = "Over Time";
                    }

                    if (item.Turn_in.Hour <= 10 && item.Turn_out.Hour > 5)
                    {
                        model.Status = "Valid Attendance";
                    }

                    calenderViewLists.Add(model);

                }
            }

            return calenderViewLists;
        }
    }
           
    }

 

