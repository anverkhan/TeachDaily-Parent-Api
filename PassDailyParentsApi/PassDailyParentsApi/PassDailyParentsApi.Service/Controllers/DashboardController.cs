using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PassDailyParentsApi.Data.Model;
using PassDailyParentsApi.Data.Repository.Abstract;
using PassDailyParentsApi.Data.Repository.Impl;
using System.Configuration;

namespace PassDailyParentsApi.Service.Controllers
{
    [RoutePrefix("PassDailyParentsApi/Dashboard")]
    public class DashboardController : ApiController
    {
        private IDashboardRepository _dashboardRepository;

        static string YoutubeLink = ConfigurationManager.AppSettings["YoutubeLink"].ToString();

        public DashboardController()
        {
            _dashboardRepository = new DashboardRepository();
            
           
        }

        [HttpGet]
        [Route("Details")]
        public DashboardInfo Details(string studentId = "0")
        {
            //DbResultInfo result = new DbResultInfo();
            //try
            //{
            //    result = _dashboardRepository.FromOldServer(Convert.ToInt32(studentId));
            //}
            //catch(Exception ee)
            //{
            //    string error = ee.Message.ToString();

            //}
            //return _dashboardRepository.GetDashboardDetails(Convert.ToInt32(studentId));

            DashboardInfo result = new DashboardInfo();

            result = _dashboardRepository.GetDashboardDetails(Convert.ToInt32(studentId));

            result.AcademicDetails.YOUTUBE_LINK = YoutubeLink;

            //return _dashboardRepository.GetDashboardDetails(Convert.ToInt32(studentId));

            return result;

        }

        [HttpGet]
        [Route("EventListAll")]
        public EventRootInfo EventListAll(string AccademicId, string ClassId, string StudentId)
        {
            return _dashboardRepository.EventListAll(AccademicId, ClassId, StudentId);
        }

        [HttpGet]
        [Route("TakeProfile")]
        public StudentProfileInfo TakeProfile(string studentId = "0")
        {
            StudentProfileInfo result = new StudentProfileInfo();
            try
            {
                result = _dashboardRepository.TakeProfile(Convert.ToInt32(studentId));
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();

            }
            return result;
        }





    }
}
