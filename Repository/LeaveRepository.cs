using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagement.Repository.LeaveRepository;

namespace EmployeeManagement.Repository
{
    public class LeaveRepository : Repository<Leave>, ILeaveRepository

    {
        public LeaveRepository(EmployeeManagementDbContext context) : base(context)
        {

        }
    }
    public interface ILeaveRepository : IRepository<Leave>
    {

    }
}

    


