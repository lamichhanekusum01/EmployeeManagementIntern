using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EmployeeManagement.Controllers

{
   
    public class AttendenceController : Controller
    {
        private readonly IAttendenceProvider _iAttendenceProvider;
        private EmployeeManagementDbContext _context;
        public AttendenceController(IAttendenceProvider iAttendenceProvider, EmployeeManagementDbContext Context)
        {
            _iAttendenceProvider = iAttendenceProvider;
            _context = Context;
        }
       
        [HttpGet]
        public IActionResult Index()
        {
            AttendenceViewModel attendenceViewModel = new AttendenceViewModel();
            string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var attendenceList = _iAttendenceProvider.GetList();
            var attendence= attendenceList.AttendenceList.Where(x => x.Date == DateTime.Parse(currentDate)).FirstOrDefault();
          
            if (attendence==null)
            {
                attendenceViewModel.IsTurnIn = false;

            }
            else
            {
                attendenceViewModel.IsTurnIn = true;
                attendenceViewModel.Attendence_Id = attendence.Attendence_Id;

                attendenceViewModel.Turn_in = attendence.Turn_in;
            }
            return View(attendenceViewModel);

        }
       
        [HttpPost]
        public IActionResult Index(AttendenceViewModel model)
        {
            try
            {
                _iAttendenceProvider.SaveAttendence(model);
                return RedirectToAction("AttendenceList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
                               
        }

      
        [HttpGet]
        public IActionResult AttendenceList()
        {           
          
            var attendence = _iAttendenceProvider.GetList();
            return View(attendence);
        }

    }
}
