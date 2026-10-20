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

    public class InboxnewController : ApiController
    {
        static string SchoolName = ConfigurationManager.AppSettings["SchoolName"].ToString();
        static string SenderId = ConfigurationManager.AppSettings["SenderId"].ToString();


        private AppInboxRepository _appinboxnewRepository;

        public InboxnewController()
        {
            _appinboxnewRepository = new AppInboxRepository();

        }
        [HttpPost]
        public AppInboxInfoRootNew AppInboxGet(AppInboxRequestInfo inbox)
        {

            return _appinboxnewRepository.AppInboxGetNew(inbox);


        }
    }
}
