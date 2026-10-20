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
    [RoutePrefix("PassDailyParentsApi/Exam")]
    public class ExamController : ApiController
    {
        private IExamRepository _examRepository;


        public ExamController()
        {
            _examRepository = new ExamRepository();


        }
        [HttpGet]
        [Route("ExamNameGet")]
        public ExamNameInfoRoot ExamNameGet(string ExamId)
        {
           
                return _examRepository.ExamNameGet();
           
        }
        [HttpGet]
        [Route("ExamMarkDetailsGet")]
        public ExamMarkDetailsInfoRoot ExamMarkDetailsGet(int AccademicId, int ClassId, int ExamId, int StudentRollNo, int StudentId = 1364)
        {

            return _examRepository.ExamMarkDetailsGet(AccademicId, ClassId, ExamId, StudentRollNo, StudentId);


        }

        //[HttpGet]
        //public ExamMarkDetailsCEInfoRoot ExamMarkDetailsGet(int AccademicId, int ClassId, int ExamId, int StudentRollNo)
        //{

        //    return _examRepository.ExamMarkDetailsCEGet(AccademicId, ClassId, ExamId, StudentRollNo);


        //}

        [HttpGet]
        [Route("TakeProgressReportType1")]
        public MarkInfoRoot TakeProgressReportType1(int AccademicId, int ClassId, int ExamId, int StudentId)
        {

            MarkInfoRoot result = new MarkInfoRoot();

            result = _examRepository.TakeProgressReportType1(AccademicId, ClassId, ExamId, StudentId);

            return result;


        }


    }
}
