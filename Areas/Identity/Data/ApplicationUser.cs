using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Areas.Identity.Data
{
    public class ApplicationUser: IdentityUser
    {
        public int? Employee_Id { get; set; }

        [ForeignKey(nameof(Employee_Id))]
        public virtual Employee employee { get; set; }

    }
}
