using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class AttendenceViewModel
    {
        [Key]
        public int Attendence_Id { get; set; }
        public DateTime Turn_in { get; set; }
        public DateTime Turn_out { get; set; }
        public bool IsTurnIn { get; set; }
        public bool IsTurnOut { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        public int? Employee_Id { get; set; }
        [ForeignKey(nameof(Employee_Id))]
        public virtual Employee Employee { get; set; }
        public string EmployeeName { get; set; }

        public List<AttendenceViewModel> AttendenceList { get; set; }
        public AttendenceViewModel()
        {
            AttendenceList = new List<AttendenceViewModel>();
        }


    }
}


