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
    public class EmployeeController : Controller
    {
        /*
        private EmployeeManagementDbContext db;
        public EmployeeController(EmployeeManagementDbContext _db)
        {
            db = _db;
        }
        
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }
        [Authorize]
        public ActionResult Create()
        {
            List<SelectListItem> gender = new List<SelectListItem>
            {
                new SelectListItem {Value="M", Text="Male"},
                new SelectListItem {Value="F", Text="Female"},
                new SelectListItem {Value="O", Text="Others"},
            };
            ViewBag.Gender = gender; 
                return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employees)
        {

            db.Employees.Add(employees);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Update(int id)
        {
            var employee = db.Employees.Find(id);
            List<SelectListItem> gender = new List<SelectListItem>
            {
                new SelectListItem {Value="M", Text="Male"},
                new SelectListItem {Value="F", Text="Female"},
                new SelectListItem {Value="O", Text="Others"},
            };
            ViewBag.Gender = gender;
            return View(employee);
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Employees.Update(employee);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        */
        private readonly IEmployeeProvider _iEmployeeProvider;
        private EmployeeManagementDbContext _context;


        public EmployeeController(IEmployeeProvider iEmployeeProvider, EmployeeManagementDbContext Context)
        {
            _iEmployeeProvider = iEmployeeProvider;
            _context = Context;
        }
        [Authorize]
        public IActionResult Index()
        {

            var data = _iEmployeeProvider.GetList();

            //var designation = _iEmployeeProvider.GetList();
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
            return View(data);
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
        public ActionResult SearchEmployee(string val)
        {
            EmployeeViewModel model = new EmployeeViewModel();

            model.EmployeeList = (from s in _context.Employees
                                  where s.FirstName.Contains(val) || s.LastName.Contains(val) || s.MiddleName.Contains(val) || s.Address.Contains(val) || s.Email.Contains(val)
                                  select new EmployeeViewModel
                                  {
                                      Employee_Id = s.Employee_Id,
                                      FirstName = s.FirstName,
                                      MiddleName = s.MiddleName,
                                      LastName = s.LastName,
                                      Address = s.Address,
                                      Dob = s.Dob,
                                      Email = s.Email,

                                  }).ToList();
            return View(model);
        }
        public JsonResult BindDataInDropDownList()
        {
            var list = new List<EmployeeViewModel>();
            var data = _context.Employees.ToList();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    EmployeeViewModel objModel = new EmployeeViewModel();
                    objModel.Employee_Id = item.Employee_Id;
                    objModel.FirstName = item.FirstName;
                    objModel.MiddleName = item.MiddleName;
                    objModel.LastName = item.LastName;
                    objModel.Address = item.Address;
                    //objModel.Gender = item.Gender;
                    objModel.Dob = item.Dob;
                    list.Add(objModel);
                }
            }
            return Json(data);
        }
    }

}