using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagement.Repository.ApplicationUserRepository;

namespace EmployeeManagement.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository

    {
        public ApplicationUserRepository(EmployeeManagementDbContext context) : base(context)
        {

        }
        public interface IApplicationUserRepository : IRepository<ApplicationUser>
        {

        }
    }
}

    


