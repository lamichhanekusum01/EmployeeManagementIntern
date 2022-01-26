using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace EmployeeManagement.Controllers

{
   
    public class HolidayController : Controller
    {
        private readonly IHolidayProvider _iHolidayProvider;
        private EmployeeManagementDbContext _context;
        public HolidayController(IHolidayProvider iHolidayProvider, EmployeeManagementDbContext Context)
        {
            _iHolidayProvider = iHolidayProvider;
            _context = Context;
        }
       
        [HttpGet]
        public IActionResult Index()
        {

            return View();

        }
       
        [HttpPost]
        public IActionResult Index(HolidayViewModel model)
        {
            try
            {   _iHolidayProvider.SaveHoliday(model);
                return RedirectToAction("HolidayList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
                               
        }
      
        [HttpGet]
        public IActionResult HolidayList(string searchText = "")
        {
          
            HolidayViewModel holiday = new HolidayViewModel();
            if (searchText != "" && searchText != null)
            {
                //holiday.HolidayList = (from s in _context.Holidays
                //                       where s.HolidayName.Contains(searchText)
                //                       select new HolidayViewModel
                //                       {
                //                           Holiday_Id = s.Holiday_Id,
                //                           HolidayName = s.HolidayName,
                //                           HolidayDate = s.HolidayDate,
                //                           HolidayDays = s.HolidayDays,
                //                       }).ToList();
            }
            else
                holiday = _iHolidayProvider.GetList();
            return View(holiday);
        }

    }
}
