using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagement.Repository.HolidayRepository;

namespace EmployeeManagement.Repository
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository

    {
        public HolidayRepository(EmployeeManagementDbContext context) : base(context)
        {

        }
    }
    public interface IHolidayRepository : IRepository<Holiday>
    {

    }
}

    


