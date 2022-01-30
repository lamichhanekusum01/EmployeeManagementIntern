﻿using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers

{
   
    public class AttendenceController : Controller
    {
        private readonly IAttendenceProvider _iAttendenceProvider;
        private EmployeeManagementDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
       

        public AttendenceController(IAttendenceProvider iAttendenceProvider, EmployeeManagementDbContext Context,UserManager<ApplicationUser> userManager)
        {
            _iAttendenceProvider = iAttendenceProvider;
            _context = Context;
            this.userManager = userManager;
        }
       
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            AttendenceViewModel attendenceViewModel = new AttendenceViewModel();
            string emp = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var employee = await userManager.FindByIdAsync(emp);
            int eid = employee.EId;
                           

            string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var attendenceList = _iAttendenceProvider.GetList();
            var attendence= attendenceList.AttendenceList.Where(x => x.Date == DateTime.Parse(currentDate)&&x.Employee_Id==eid) .FirstOrDefault();
          
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
