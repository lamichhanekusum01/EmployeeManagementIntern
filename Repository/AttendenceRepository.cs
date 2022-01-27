using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagement.Repository.AttendenceRepository;

namespace EmployeeManagement.Repository
{
    public class AttendenceRepository : Repository<Attendence>, IAttendenceRepository
    {
        public AttendenceRepository(EmployeeManagementDbContext context) : base(context)
        {

        }
    }
    public interface IAttendenceRepository : IRepository<Attendence>
    {

    }
}

    


