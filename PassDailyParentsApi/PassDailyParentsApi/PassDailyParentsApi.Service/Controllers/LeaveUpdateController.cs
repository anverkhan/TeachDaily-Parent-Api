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
    public class LeaveUpdateController : ApiController
    {
        private ILeaveRepository _leaveRepository;
        public LeaveUpdateController()
        {
            _leaveRepository = new LeaveRepository();

        }
        

        [HttpPost]
        public DbResultInfo LeaveRequestUpdate(LeaveRequestInfo leaves)
        {

            return _leaveRepository.LeaveRequestUpdate(leaves);

        }
    }
}
