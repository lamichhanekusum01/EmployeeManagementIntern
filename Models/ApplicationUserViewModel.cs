using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class ApplicationUserViewModel
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "enterusername.", MinimumLength = 6)]
        public string UserName { get; set; }
        public string DegisnationName { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public double Phone { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("PasswordHash", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Employee_Id { get; set; }
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
