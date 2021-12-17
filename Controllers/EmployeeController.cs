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
    [Authorize(Roles = "Admin")]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeProvider _iEmployeeProvider;
        private EmployeeManagementDbContext _context;


        public EmployeeController(IEmployeeProvider iEmployeeProvider, EmployeeManagementDbContext Context)
        {
            _iEmployeeProvider = iEmployeeProvider;
            _context = Context;
        }
     
        public IActionResult Index(string? query)
        {
            EmployeeViewModel model = new EmployeeViewModel();

            model = _iEmployeeProvider.GetList();
             var designation = _context.Designations.ToList();

            List<SelectListItem> Designation = new List<SelectListItem>();

            foreach (var item in designation)
            {
                string position = item.DesignationName;

                SelectListItem items = new SelectListItem { Value = position /*Convert.ToString(item.Designation_Id)*/, Text = position };


                Designation.Add(items);

            }
            ViewBag.designation = Designation;



            ViewBag.Gender = _context.Genders.ToList();
            List<SelectListItem> Gender = new List<SelectListItem>();

            foreach (var item in ViewBag.Gender)

            {

                string gender;


                if (item.GenderName == 'M')
                {
                    gender = "Male";

                }
                else if (item.GenderName == 'F')
                {
                    gender = "Female";

                }
                else
                {
                    gender = "others";


                }

                SelectListItem items = new SelectListItem { Value = Convert.ToString(item.Gender_Id), Text = gender };
                Gender.Add(items);
            }
            ViewBag.gender = Gender;
            return View(model);
        }
     
        [HttpGet]
        public IActionResult Create(int? id)
        {

            var designation = _context.Designations.ToList();

            List<SelectListItem> Designation = new List<SelectListItem>();

            foreach (var item in designation)
            {
                string position = item.DesignationName;

                SelectListItem items = new SelectListItem { Value = Convert.ToString(item.Designation_Id), Text = position };


                Designation.Add(items);

            }
            ViewBag.designation = Designation;


            ViewBag.Gender = _context.Genders.ToList();
            List<SelectListItem> Gender = new List<SelectListItem>();

            foreach (var item in ViewBag.Gender)

            {

                string gender;


                if (item.GenderName == 'M')
                {
                    gender = "Male";

                }
                else if (item.GenderName == 'F')
                {
                    gender = "Female";

                }
                else
                {
                    gender = "others";


                }

                SelectListItem items = new SelectListItem { Value = Convert.ToString(item.Gender_Id), Text = gender };
                Gender.Add(items);
            }
            ViewBag.gender = Gender;
            EmployeeViewModel emp = new EmployeeViewModel();
            if (id.HasValue)
            {
                emp = _iEmployeeProvider.GetById(id.Value);
            }

            return PartialView(emp);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {

            try
            {

                _iEmployeeProvider.SaveEmployee(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
                
            }
        }
        //[HttpGet]
        //public ActionResult Update(int id)
        //{
        //    EmployeeViewModel emp = _iEmployeeProvider.GetById(id);
        //    return View(emp);
        //}

        //public JsonResult Update(int id)
        //{
        // EmployeeViewModel emp = _iEmployeeProvider.GetById(id);
        // return Json(emp);
        // _iEmployeeProvider.SaveEmployee(model);
        //  // return RedirectToAction("Create");
        // }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _iEmployeeProvider.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
{
            var users = (from employee in this._context.Employees
                         where employee.FirstName.StartsWith(prefix)
                         select new
                         {
                             label = employee.FirstName,
                             val = employee.Employee_Id
                         }).ToList();

            return Json(users);
        }

        public ActionResult SearchEmployee(string query)
        {
            EmployeeViewModel model = new EmployeeViewModel();
                model.EmployeeList = (from s in _context.Employees
                where s.FirstName.Contains(query) || s.LastName.Contains(query) || s.MiddleName.Contains(query)
                select new EmployeeViewModel
                {
                    Employee_Id = s.Employee_Id,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    Address = s.Address,
                    Dob = s.Dob,
                    Email = s.Email,
                    Phone= s.Phone,
                }).ToList();

            return PartialView(model);
        }

    }

} 

//vaisakyo ta search lol??