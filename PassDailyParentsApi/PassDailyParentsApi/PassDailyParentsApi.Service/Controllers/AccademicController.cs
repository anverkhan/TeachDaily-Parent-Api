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
    public class AccademicController : ApiController
    {
        private IAccademicRepository _accademicRepository;


        public AccademicController()
        {
            _accademicRepository = new AccademicRepository();


        }
        [HttpGet]
        public AccademicInfoRoot AccademicYearGet(string AccademicId)
        {
            
                return _accademicRepository.AccademicYearGet();
            
        }

        [HttpGet]
        public HolidayRootInfo GetHolidayList(string StudentId, string Date)
        {

            return _accademicRepository.GetHolidayList(StudentId,Date);

        }

        [HttpGet]
        public HolidayRootInfo GetHolidayListById(string StudentId, string AccademicId, string Dummy)
        {

            return _accademicRepository.GetHolidayListById(StudentId, AccademicId);

        }

        [HttpGet]
        public ActivityInfoRoot GetActivityListById(string StudentId, string AccademicId, string Dummy, string Dummy2)
        {

            return _accademicRepository.GetActivityListById(StudentId, AccademicId);

        }

    }
}
