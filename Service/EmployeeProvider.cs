﻿using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public interface IEmployeeProvider
    {
        int SaveEmployee(EmployeeViewModel model);
        void DeleteEmployee(int id);
        EmployeeViewModel EditEmployee(EmployeeViewModel model);
        EmployeeViewModel GetList();
        EmployeeViewModel GetById(int id);
    }
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeRepository _iEmployeeRepository;
        private readonly IMapper _mapper;
        public EmployeeProvider(IEmployeeRepository iEmployeeRepository, IMapper mapper)
        {
            _iEmployeeRepository = iEmployeeRepository;
            _mapper = mapper;

        }
        public int SaveEmployee(EmployeeViewModel model)
        {

            Employee employee = new Employee();
            employee = _mapper.Map<Employee>(model);
            //employee.FullName = model.FullName;
            //employee.Address = model.Address;
            //employee.Gender = model.Gender;
            //employee.Dob = model.Dob;
            if (employee.Id > 0)
            {
                //employee.UpdatedBy = 1;
                //  employee.UpdatedDate = DateTime.UtcNow;
                _iEmployeeRepository.Update(employee);
                return 200;

            }
            else
            {
                //employee.CreatedBy = 1;
                _iEmployeeRepository.Add(employee);
                return 200;
            }
        }
        public void DeleteEmployee(int id)
        {
            var item = _iEmployeeRepository.GetSingle(x => x.Id == id);
            _iEmployeeRepository.Delete(item);
        }
        public EmployeeViewModel EditEmployee(EmployeeViewModel model)
        {
            Employee data = new Employee();
            _mapper.Map<EmployeeViewModel>(data);

            //data.Id = model.Id;
            //data.FullName = model.FullName;
            //data.Address = model.Address;
            //data.Gender = model.Gender;
            //data.Dob = model.Dob;
            _iEmployeeRepository.Update(data);
            return model;
        }
        public EmployeeViewModel GetById(int id)
        {
            var item = _iEmployeeRepository.GetSingle(x => x.Id == id);
            EmployeeViewModel data = _mapper.Map<EmployeeViewModel>(item);
            return data;
        }
        public EmployeeViewModel GetList()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            var list = new List<EmployeeViewModel>();
            List<Employee> data = _iEmployeeRepository.GetAll().ToList();
            //EmployeeViewModel model = new EmployeeViewModel();
            //var list = new List<EmployeeViewModel>();
            //var data = _iEmployeeRepository.GetAll();
            //foreach (var item in data)
            //{
            //    EmployeeViewModel objModel = new EmployeeViewModel();
            //    objModel.Id = item.Id;
            //    objModel.FullName = item.FullName;
            //    objModel.Address = item.Address;
            //    objModel.Gender =item.Gender;
            //    objModel.Dob = item.Dob;
            //    list.Add(objModel);
            //}
            //model.EmployeeList = list;

            list = _mapper.Map<List<Employee>, List<EmployeeViewModel>>(data);

            model.EmployeeList = list;
            return model;

        }
    }
}
       



