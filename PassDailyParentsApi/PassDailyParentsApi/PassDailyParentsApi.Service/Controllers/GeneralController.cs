using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PassDailyParentsApi.Data.Model;
using PassDailyParentsApi.Data.Repository.Abstract;
using PassDailyParentsApi.Data.Repository.Impl;
using System.IO;
using System.Configuration;

namespace PassDailyParentsApi.Service.Controllers
{
    public class GeneralController : ApiController
    {

        static string SchoolName = ConfigurationManager.AppSettings["SchoolName"].ToString();
        static string SenderId = ConfigurationManager.AppSettings["SenderId"].ToString();

        
        private IParentLoginRepository _parentloginRepository;



        public GeneralController()
        {
            
            _parentloginRepository = new ParentLoginRepository();

        }



        [HttpGet]
        public AboutusInfoRoot AboutUs(string StudentId, string AboutType)
        {

            return _parentloginRepository.AboutUs(StudentId, AboutType);


        }

        [HttpGet]
        public ContactUsRootInfo ContactUs(string StudentId)
        {

            return _parentloginRepository.ContactUs(StudentId);


        }


    }
}
