using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PassDailyParentsApi.Data.Model;
using PassDailyParentsApi.Data.Repository.Abstract;
using PassDailyParentsApi.Data.Repository.Impl;

namespace PassDailyParentsApi.Service.Controllers
{
    public class LeaveController : ApiController
    {

        private ILeaveRepository _leaveRepository;
        public LeaveController()
        {
            _leaveRepository = new LeaveRepository();
        }

        [HttpPost]
        public DbResultInfo LeaveRequest(LeaveRequestInfo leave)
        {

            return _leaveRepository.LeaveRequest(leave);


        }

        

        [HttpGet]
        public DbResultInfo LeaveDelete(string LeaveId)
        {

            return _leaveRepository.LeaveDelete(LeaveId);


        }


        [HttpGet]
        public LeaveListInfoRoot LeaveListForEdit(string Leave_Id)
        {
            return _leaveRepository.LeaveListForEdit(Leave_Id);

        }

        


    }
}
