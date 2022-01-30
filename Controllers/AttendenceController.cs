using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace EmployeeManagement.Controllers

{
   
    public class AttendenceController : Controller
    {
        private readonly IAttendenceProvider _iAttendenceProvider;
        private EmployeeManagementDbContext _context;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AttendenceController(IAttendenceProvider iAttendenceProvider, EmployeeManagementDbContext Context,SignInManager<ApplicationUser> signInManager)
        {
            _iAttendenceProvider = iAttendenceProvider;
            _context = Context;
            this.signInManager = signInManager;
        }
       
        [HttpGet]
        public IActionResult Index()
        {
            AttendenceViewModel attendenceViewModel = new AttendenceViewModel();
            string emp = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var attendenceList = _iAttendenceProvider.GetList();
            var attendence= attendenceList.AttendenceList.Where(x => x.Date == DateTime.Parse(currentDate)).FirstOrDefault();
          
            if (attendence==null)
            {
                attendenceViewModel.IsTurnIn = false;
                attendenceViewModel.IsTurnOut = false;

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
