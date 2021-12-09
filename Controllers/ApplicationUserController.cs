using EmployeeManagement.Controllers;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class ApplicationUserController : Controller
    { private readonly IApplicationUserProvider _iApplicationUserProvider;
        private EmployeeManagementDbContext _context;


        public ApplicationUserController(IApplicationUserProvider iApplicationUserProvider, EmployeeManagementDbContext Context)
        {
            _iApplicationUserProvider = iApplicationUserProvider;
            _context = Context;
        }
        [Authorize]
        public IActionResult Index()
        {
            ApplicationUserViewModel user = new ApplicationUserViewModel();
            user.UserList = _iApplicationUserProvider.GetList();


            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {

            // var Emp = _context.Employees.ToList();
            var Emp = _iApplicationUserProvider.GetEmployeesWithNoUsers();
            List<SelectListItem> emp = new List<SelectListItem>();
            foreach (var item in Emp)
            {
                string data1 = item.FirstName +" "+ item.MiddleName +" " + item.LastName;
                int id1 = item.Employee_Id;
                SelectListItem items = new SelectListItem { Value = id1.ToString(), Text = data1 };
                emp.Add(items);
            }
            ViewBag.Emp = emp;
            ApplicationUserViewModel user = new ApplicationUserViewModel();
            if (id != null)
            {
                user = await _iApplicationUserProvider.GetById(id);


            }
            return PartialView(user);
        }
            [HttpPost]
        public async Task<IActionResult> Create(ApplicationUserViewModel model)
        {
           
                try
                {
                    var user = _context.Employees.Where(x => x.Employee_Id == Convert.ToInt32(model.Employee_Id)).FirstOrDefault();
                    model.Email = user.Email;
                    model.Address = user.Address;
                    model.Phone = user.Phone;
                   

                    var res = await _iApplicationUserProvider.SaveUser(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {


                    throw ex;
                }
                
            

            //ModelState.AddModelError(nameof(model.ConfirmPassword),"hi");
            return View("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Update(string Id)
        {
            ApplicationUserViewModel emp = await _iApplicationUserProvider.GetById(Id);
            return View(emp);
        }

      

        public async Task<IActionResult> Delete(string Id)
        {    await _iApplicationUserProvider.DeleteUser(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var users = (from user in this._context.ApplicationUsers
                         where user.UserName.StartsWith(prefix)
                         select new
                         {
                             label = user.UserName,
                             val = user.EId
                         }).ToList();

            return Json(users);
        }
    }

}