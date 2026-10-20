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
    public class LeaveListController : ApiController
    {

        private ILeaveRepository _leaveRepository;
        public LeaveListController()
        {
            _leaveRepository = new LeaveRepository();

        }


        [HttpPost]
        public LeaveListInfoRoot LeaveList(LeaveFilterInfo leavefilter)
        {

            return _leaveRepository.LeaveList(leavefilter);


        }
    }
}
