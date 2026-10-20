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
    public class ResultController : ApiController
    {
        private IResultRepository _resultRepository;


        public ResultController()
        {
            _resultRepository = new ResultRepository();


        }
        [HttpGet]
        public ResultInfoRoot AnnualResultGet(int STUDENT_ID, int ACCADEMIC_ID)
        {
            
                return _resultRepository.AnnualResultGet(STUDENT_ID, ACCADEMIC_ID);
           
        }
    }
}
