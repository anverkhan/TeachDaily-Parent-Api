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
    [RoutePrefix("PassDailyParentsApi/Attendance")]
    public class AttendanceController : ApiController
    {
        private IAttendanceRepository _attendanceRepository;


        public AttendanceController()
        {
            _attendanceRepository = new AttendanceRepository();


        }
        [HttpGet]
        [Route("AttendanceReportGet")]
        public AttendanceReportInfoRoot AttendanceReportGet(int STUDENT_ID, int ACCADEMIC_ID)
        {
            
                return _attendanceRepository.AttendanceReportGet(STUDENT_ID, ACCADEMIC_ID);
            
        }

        [HttpGet]
        [Route("CarryingTypeList")]
        public CarryingTypeRootInfo CarryingTypeList(int STUDENT_ID)
        {

            return _attendanceRepository.CarryingTypeList(STUDENT_ID);

        }

        [HttpGet]
        [Route("CarryingDetailsList")]
        public CarryingListRootInfo CarryingDetailsList(int STUDENT_ID, int TYPE_ID)
        {

            return _attendanceRepository.CarryingDetailsList(STUDENT_ID, TYPE_ID);

        }
    }
}
