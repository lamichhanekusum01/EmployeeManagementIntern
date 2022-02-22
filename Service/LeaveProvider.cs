﻿using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Service
{
    public interface ILeaveProvider
    {
        int SaveLeave(LeaveViewModel model);
        LeaveViewModel GetById(int id);
        LeaveViewModel GetList();
        List<Employee> GetEmployees();
        List<ApplicationUser> GetUsers();






    }
    public class LeaveProvider : ILeaveProvider
    {
        private readonly ILeaveRepository _iLeaveRepository;
        private readonly IMapper _mapper;
        private EmployeeManagementDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public LeaveProvider(UserManager<ApplicationUser> userManager, ILeaveRepository iLeaveRepository, IMapper mapper, EmployeeManagementDbContext context)
        {
            _userManager = userManager;
            _iLeaveRepository = iLeaveRepository;
            _mapper = mapper;
            _context = context;
        }

        public int DeleteLeave(int Id)
        {
            throw new NotImplementedException();
        }

        public LeaveViewModel GetById(int id)
        {

            var item = _iLeaveRepository.GetSingle(x => x.Leave_Id == id);
            LeaveViewModel data = _mapper.Map<LeaveViewModel>(item);
            return data;
        }

        public List<Employee> GetEmployees()
        {

            var EmpList = new List<Employee>();
            var Emp = _context.Employees.ToList();
            foreach (var item in Emp)
            {
                EmpList.Add(item);
            }
            return EmpList;
        }

        public List<ApplicationUser> GetUsers()
        {
            var UserList = new List<ApplicationUser>();
            List<ApplicationUser> usersList = _userManager.Users.ToList();
            foreach (var item in usersList)
            {
                UserList.Add(item);
            }
            return UserList;
        }
        public LeaveViewModel GetList()
        {
            LeaveViewModel model = new LeaveViewModel();
            var list = new List<LeaveViewModel>();
            List<Leave> data = _iLeaveRepository.GetAll().ToList();
            list = _mapper.Map<List<Leave>, List<LeaveViewModel>>(data);
            model.LeaveList = list;
            return model;
        }
        public int SaveLeave(LeaveViewModel model)
        {
            string usrId = model.UserId;
            Leave leave = _mapper.Map<LeaveViewModel, Leave>(model);
            var usr = _iLeaveRepository.GetSingle(x => x.UserId == model.UserId);
            var singleUser = _context.Users.Where(x => x.Id == usrId).First();
            leave.UserId = singleUser.Id;
            _iLeaveRepository.Add(leave);
            _context.Users.Attach(singleUser);
            _context.SaveChanges();
            return 200;


        }

        
        
    }

}

