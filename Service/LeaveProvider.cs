using AutoMapper;

using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;

using System;
namespace EmployeeManagement.Service
{
    public interface ILeaveProvider
    {
        int SaveLeave(LeaveViewModel model);
        int DeleteLeave(int Id);


    }
    public class LeaveProvider : ILeaveProvider
    {
        private readonly ILeaveRepository _iLeaveRepository;
        private readonly IMapper _mapper;
        private EmployeeManagementDbContext _context;

        public LeaveProvider(ILeaveRepository iLeaveRepository, EmployeeManagementDbContext context, IMapper mapper)
        {
            _iLeaveRepository = iLeaveRepository;
            _mapper = mapper;
            _context = context;

        }

        public int DeleteLeave(int Id)
        {
            throw new NotImplementedException();
        }

        public int SaveLeave(LeaveViewModel model)
        {
            Leave leave = new Leave();
            leave = _mapper.Map<Leave>(model);
            _iLeaveRepository.Add(leave);
            return 200;


        }

    }

    //public int DeleteHoliday( int Id)
    //{
    //    var item = _iHolidayRepository.GetSingle(x => x.Holiday_Id == Holiday_Id);
    //    _iHolidayRepository.Delete(item);
    //}
}

