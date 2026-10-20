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
    [RoutePrefix("PassDailyParentsApi/OnlineDExam")]
    public class OnlineDExamController : ApiController
    {
        static string SchoolName = ConfigurationManager.AppSettings["SchoolName"].ToString();
        static string SenderId = ConfigurationManager.AppSettings["SenderId"].ToString();
        static string SubDomain = ConfigurationManager.AppSettings["subdomain"].ToString();


        private IOnlineExamRepository _onlineexamRepository = null;

        public OnlineDExamController()
        {
            _onlineexamRepository = new OnlineExamRepository();

        }

        [HttpGet]
        [Route("OnlineDExamList")]
        public OnlineDExamListRootInfo OnlineDExamList(string AccademicId, string ClassId, string SubjectId, string StudentId)
        {
            return _onlineexamRepository.OnlineDExamList(AccademicId, ClassId, SubjectId, StudentId);
        }

        [HttpGet]
        [Route("OnlineDExamDetailsById")]
        public OnlineDExamListRootInfo OnlineDExamDetailsById(string StudentId, string ExamId)
        {
            return _onlineexamRepository.OnlineDExamDetailsById(StudentId, ExamId);
        }


        [HttpGet]
        [Route("OnlineDExamStatusByStudent")]
        public DExamResultInfo OnlineDExamStatusByStudent(string AccademicId, string ClassId, string StudentId, string ExamId)
        {
            DExamResultInfo result = new DExamResultInfo();

            try
            {
                result = _onlineexamRepository.OnlineDExamStatusByStudent(AccademicId, ClassId, StudentId, ExamId);

                string[] Sub_result = result.RESULT.Split(',');
                result.RESULT = Sub_result[0].ToString();
                result.EXAM_ATTEMPT_ID = System.Convert.ToInt32(Sub_result[1].ToString());
                result.EXAM_DURATION = System.Convert.ToInt32(Sub_result[2].ToString());
                result.ELAPSED_TIME = System.Convert.ToInt32(Sub_result[3].ToString());
                result.JSON_ERROR = "NOERROR";

                if (result.RESULT.ToString() == "FAILED")
                {
                    result.JSON_ERROR = "ERRORINDATABASE";
                }
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAILED";
                result.JSON_ERROR = ee.Message.ToString();
            }
            return result;
        }


        [HttpGet]
        [Route("DQuestionListForStart")]
        public DQuestionListRootInfo DQuestionListForStart(string ExamId, string ExamAttemptId)
        {
            return _onlineexamRepository.DQuestionListForStart(ExamId, ExamAttemptId);
        }

        [HttpGet]
        [Route("TakeAnswer")]
        public DAnswerRootInfo TakeAnswer(string ExamId, string ExamAttemptId, string QuestionId)
        {
            return _onlineexamRepository.TakeAnswer(ExamId, ExamAttemptId, QuestionId);
        }

        [HttpPost()]
        public ResultNewInfo UploadFiles()
        {
            ResultNewInfo result = new ResultNewInfo();
            string filenameresult = string.Empty;
            try
            {
                int iUploadedCnt = 0;

                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
                string sPath = "";
                //sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/locker/");
                sPath = "C:/inetpub/vhosts/passdaily.in/subdomains/" + SubDomain + "/DExamFile/Answer/";
                //sPath = "C:/inetpub/vhosts/gtgroups.in/subdomains/" + SubDomain + "/DExamFile/Answer/"; 
                //sPath = "C:/inetpub/vhosts/classdaily.in/subdomains/" + SubDomain + "/DExamFile/Answer/";

                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                string fileName = Guid.NewGuid().ToString();
                // CHECK THE FILE COUNT.
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];

                    if (hpf.ContentLength > 0)
                    {
                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                        if (!File.Exists(sPath + fileName + Path.GetFileName(hpf.FileName)))
                        {
                            // SAVE THE FILES IN THE FOLDER.
                            hpf.SaveAs(sPath + fileName + Path.GetFileName(hpf.FileName));
                            iUploadedCnt = iUploadedCnt + 1;

                            filenameresult = fileName + Path.GetFileName(hpf.FileName);
                        }


                    }
                }

                // RETURN A MESSAGE (OPTIONAL).
                if (iUploadedCnt > 0)
                {
                    //return iUploadedCnt + " Files Uploaded Successfully";

                    result.RESULT = "SUCCESS";
                    result.DETAILS = filenameresult.ToString().TrimEnd();


                }
                else
                {
                    //return "Upload Failed";
                    result.RESULT = "FAILED";
                    result.RESULT = "File Upload Failed In Service";
                }

            }
            catch (Exception ee)
            {
                result.RESULT = "ERROR";
                result.RESULT = ee.Message.ToString();
            }

            return result;

        }

        [HttpPost]
        [Route("SubmitAnswer")]
        public DbResultInfo SubmitAnswer(AnswerSubmitInfo asi)
        {
            return _onlineexamRepository.SubmitAnswer(asi);
        }


        [HttpPost]
        [Route("DeleteAnswer")]
        public DbResultInfo DeleteAnswer(DeleteAnswerInfo Dai)
        {
            return _onlineexamRepository.DeleteAnswer(Dai);
        }


        [HttpPost]
        [Route("DeleteFile1")]
        public DbResultInfo DeleteFile1(DeleteAnswerInfo Dai)
        {
            return _onlineexamRepository.DeleteFile1(Dai);
        }

        [HttpPost]
        [Route("DeleteFile2")]
        public DbResultInfo DeleteFile2(DeleteAnswerInfo Dai)
        {
            return _onlineexamRepository.DeleteFile2(Dai);
        }

        [HttpPost]
        [Route("DeleteFile3")]
        public DbResultInfo DeleteFile3(DeleteAnswerInfo Dai)
        {
            return _onlineexamRepository.DeleteFile3(Dai);
        }

        [HttpPost]
        [Route("PauseDExam")]
        public DbResultInfo PauseDExam(DeleteAnswerInfo Dai)
        {
            return _onlineexamRepository.PauseDExam(Dai);
        }

        [HttpPost]
        [Route("FinishDExam")]
        public DbResultInfo FinishDExam(DeleteAnswerInfo Dai)
        {
            return _onlineexamRepository.FinishDExam(Dai);
        }

        [HttpPost]
        [Route("DoAutoEndDExam")]
        public DbResultInfo DoAutoEndDExam(DeleteAnswerInfo Dai)
        {
            return _onlineexamRepository.DoAutoEndDExam(Dai);
        }


        [HttpGet]
        [Route("DOnlineExamResult")]
        public DExamResultRootInfo DOnlineExamResult(string AccademicId, string StudentId, string ExamId, string ExamAttemptId)
        {
            return _onlineexamRepository.DOnlineExamResult(AccademicId, StudentId, ExamId, ExamAttemptId);
        }




    }

    



}
