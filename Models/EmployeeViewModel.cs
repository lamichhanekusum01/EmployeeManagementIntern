using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Employee_Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public  string UserName { get; set; }
        public string Address { get; set; }
       //public char GenderName { get; set; }
        public int  Gender_Id { get; set; }
        public char GenderName { get; set; }
        public string Email { get; set; }
        public double Phone { get; set; }
        public double Salary { get; set; }
        public int Designation_Id { get; set; }
        public string DesignationName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; }
        public EmployeeViewModel()
        {
            EmployeeList = new List<EmployeeViewModel>();
        }
        
       
       

    }
}
