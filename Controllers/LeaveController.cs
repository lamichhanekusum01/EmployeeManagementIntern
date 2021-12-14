using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace EmployeeManagement.Controllers

{
    
    public class LeaveController : Controller
    {
        private readonly ILeaveProvider _iLeaveProvider;
        private EmployeeManagementDbContext _context;
        public LeaveController(ILeaveProvider iLeaveProvider, EmployeeManagementDbContext Context)
        {
            _iLeaveProvider = iLeaveProvider;
            _context = Context;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(LeaveViewModel model)
        {
            try
            {
                _iLeaveProvider.SaveLeave(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
                               
        }

    }
}
