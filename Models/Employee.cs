using EmployeeManagement.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee 
    {
        [Key]
        public int Employee_Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
      
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/ dd/yyyy}")]
        public DateTime Dob { get; set; }
        public double Phone{ get; set; }
        
        public double Salary { get; set; }
        public int? Gender_Id { get; set; }
        [ForeignKey(nameof(Gender_Id))]
        public virtual Gender Gender { get; set; }
        [ForeignKey(nameof(Attendence_Id))]
        public char GenderName { get; set; }
        public int? Attendence_Id { get; set; }

        public DateTime Time_In { get; set; }
        public DateTime Time_out { get; set; }
        public DateTime Date { get; set; }
        public virtual Attendence Attendence { get; set; }
        public int? Designation_Id { get; set; }

        [ForeignKey(nameof(Designation_Id))]
        public virtual Designation Designation { get; set; }
        public string DesignationName { get; set; }


        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey(nameof(Id))]
        public string Id { get; set; }
        public ICollection<ApplicationUser> ApplicationUser { get; set; }


    }
}
