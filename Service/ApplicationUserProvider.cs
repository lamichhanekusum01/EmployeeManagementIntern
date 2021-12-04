using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagement.Repository.ApplicationUserRepository;

namespace EmployeeManagement.Service
{
    public interface IApplicationUserProvider
    {
        Task<int> SaveUser(ApplicationUserViewModel model);
        Task<bool> DeleteUser(string Id);
        // EmployeeViewModel EditEmployee(EmployeeViewModel model);
        List<ApplicationUserViewModel> GetList();
        Task<ApplicationUserViewModel> GetById(string Id);
        List<Employee> GetEmployeesWithNoUsers();
    }
    public class ApplicationUserProvider : IApplicationUserProvider
    {
        private readonly IApplicationUserRepository _iApplicationUserRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private EmployeeManagementDbContext _context;


        public ApplicationUserProvider(IApplicationUserRepository iApplicationUserRepository, EmployeeManagementDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _iApplicationUserRepository = iApplicationUserRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }
        public async Task<int> SaveUser(ApplicationUserViewModel model)
        {
            int empId = Convert.ToInt32(model.Employee_Id);
            //ApplicationUser applicationuser = new ApplicationUser { UserName = model.UserName, Email = model.Email, Employee_Id = empId };
            ApplicationUser applicationuser = _mapper.Map<ApplicationUserViewModel ,ApplicationUser>(model);
            var user = await _userManager.Users.Where(x => x.Employee.Employee_Id == empId).FirstOrDefaultAsync();
            IdentityResult result;

            if(user == null)
            {
                var singleEmployee = _context.Employees.Where(x => x.Employee_Id == empId).First();
                applicationuser.Id = Guid.NewGuid().ToString();
                applicationuser.Employee = singleEmployee;
                applicationuser.EId = singleEmployee.Employee_Id;
                result = await _userManager.CreateAsync(applicationuser, model.PasswordHash);

                var newUser = await _userManager.FindByIdAsync(applicationuser.Id);

                singleEmployee.ApplicationUser.Add(newUser);
                // singleEmployee.Id = applicationuser.Id;
                _context.Employees.Attach(singleEmployee);
                _context.SaveChanges();

            }
            else
            {
               // user.PasswordHash = applicationuser.PasswordHash;
                user.UserName = applicationuser.UserName;
                user.ConfirmPassword = applicationuser.ConfirmPassword;
                user.Email = applicationuser.Email;
                
                result = await _userManager.UpdateAsync(user);
            }

            if (result.Succeeded)
            {

                return 200;
            }

            return 500;

        }
        public async Task<bool> DeleteUser(string Id)
        {
            try
            {
                var item = await _userManager.FindByIdAsync(Id);
                if (item != null)
                {
                    var del = await _userManager.DeleteAsync(item);
                }
                return true;


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async  Task<ApplicationUserViewModel> GetById(string Id)
        {

            var item = await _userManager.FindByIdAsync(Id);
            ApplicationUserViewModel data = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(item);
            return data;
        }
        public List<ApplicationUserViewModel> GetList()
        {
            List<ApplicationUserViewModel> user = new List<ApplicationUserViewModel>();
            List<ApplicationUser> userlist = _userManager.Users.ToList();

            user = _mapper.Map<List<ApplicationUser>, List<ApplicationUserViewModel>>(userlist);


            return user;

        }
        public List<Employee> GetEmployeesWithNoUsers()
        {
            var EmpList = new List<Employee>();

            var Emp = _context.Employees.ToList();
            List<ApplicationUser> usersList = _userManager.Users.ToList();

            foreach (var item in Emp)
            {
                bool isExist = false;

                foreach (var user in usersList)
                {
                    if (user.EId == item.Employee_Id)
                    {
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    EmpList.Add(item);
                }
            }
            return EmpList;
        }


    }
}

