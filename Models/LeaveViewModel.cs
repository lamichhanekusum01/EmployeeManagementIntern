﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class LeaveViewModel
    {
        [Key]
        public int Leave_Id { get; set; }
        public string EmployeeName { get; set; }
        public int LeaveDays { get; set; }
        public DateTime LeaveDate { get; set; }
        public Employee Employee { get; set; }

    }
}
