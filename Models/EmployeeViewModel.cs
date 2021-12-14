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
        [Required(ErrorMessage = "Please Enter First Name")]
        [StringLength(10,MinimumLength =3)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter UserName")]
        public  string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        //public char GenderName { get; set; }
        [Required(ErrorMessage = "Please select gender ")]
        public int  Gender_Id { get; set; }
        [Required(ErrorMessage = "Please select gender ")]
        public char GenderName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Phone")]
        public long? Phone { get; set; }
       
        [Required(ErrorMessage = "Please Enter Salary")]
        public int? Salary { get; set; }
        public int Designation_Id { get; set; }
        public string DesignationName { get; set; }
        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Dob { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; }
        public EmployeeViewModel()
        {
            EmployeeList = new List<EmployeeViewModel>();
        }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }



    }
}
