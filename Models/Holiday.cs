using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Holiday
    {
        [Key]
        public int? Holiday_Id { get; set; }
        public string HolidayName { get; set; }     
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/ dd/yyyy}")]
        public DateTime HolidayDate { get; set; }

    }
}
