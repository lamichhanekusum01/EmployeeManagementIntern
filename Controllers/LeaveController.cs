using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> IndexAsync()
        {
            var UserList = _iLeaveProvider.GetUsers();
            List<SelectListItem> usr = new List<SelectListItem>();
            var role = User.FindFirst(ClaimTypes.Role).Value;
            
            if (role == "Admin")
            {
                foreach (var item in UserList)
                {
                    string data1 = item.UserName;
                    string id1 = item.Id;
                    SelectListItem items = new SelectListItem { Value = id1, Text = data1 };
                    usr.Add(items);
                }
            }
            else
            {
             
                usr.Add(new SelectListItem { Value = User.FindFirst(ClaimTypes.NameIdentifier).Value, Text = User.FindFirst(ClaimTypes.Name).Value });
            }
            
            ViewBag.Emp = usr;
            return View();
        }
           
        
        [HttpPost]
        public IActionResult Index(LeaveViewModel model)
        {
            try
            {
               
                var user = _context.ApplicationUsers.Where(x => x.Id == model.UserId).FirstOrDefault();
                model.EmployeeName = user.UserName;
                model.EId = user.EId;
               _iLeaveProvider.SaveLeave(model);
                return RedirectToAction("Index");
               
             
            }
            catch (Exception ex)
            {
                throw ex;
            }
                               
        }
        [HttpGet]
        public IActionResult LeaveList()
        {
            var data = _iLeaveProvider.GetList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Approve(int? id)
        {
            LeaveViewModel model = new LeaveViewModel();
            if (id.HasValue)
            {
                model = _iLeaveProvider.GetById(id.Value);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Approve(LeaveViewModel model)
        {
            try
            {
                _iLeaveProvider.EditLeave(model);
                return RedirectToAction("LeaveList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
