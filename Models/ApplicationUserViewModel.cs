using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class ApplicationUserViewModel
    {
        [Key]
        public int Employee_Id { get; set; }
        public string FullName { get; set; } 
        public string Address { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public int PhoneNo { get; set; }

   

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public List<ApplicationUserViewModel> UserList { get; set; }
        public ApplicationUserViewModel()
        {
            UserList = new List<ApplicationUserViewModel>();
        }
    }
}
