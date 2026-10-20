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
    [RoutePrefix("PassDailyParentsApi/OnlineExam")]
    public class OnlineExamController : ApiController
    {
        static string SchoolName = ConfigurationManager.AppSettings["SchoolName"].ToString();
        static string SenderId = ConfigurationManager.AppSettings["SenderId"].ToString();
        static string SubDomain = ConfigurationManager.AppSettings["subdomain"].ToString();


        private IOnlineExamRepository _onlineexamRepository = null;

        public OnlineExamController()
        {
            _onlineexamRepository = new OnlineExamRepository();

        }


        [HttpGet]
        [Route("GetSubjectByClass")]
        public SubjectListRootInfo GetSubjectByClass(string ClassId, string StudentId)
        {
            return _onlineexamRepository.GetSubjectByClass(ClassId, StudentId);
        }

        [HttpGet]
        [Route("OnlineExamList")]
        public OnlineExamListRootInfo OnlineExamList(string AccademicId, string ClassId, string SubjectId, string StudentId)
        {
            return _onlineexamRepository.OnlineExamList(AccademicId, ClassId, SubjectId, StudentId);
        }

        [HttpGet]
        [Route("OnlineExamDetailsById")]
        public OnlineExamListRootInfo OnlineExamDetailsById(string StudentId, string OexamId)
        {
            return _onlineexamRepository.OnlineExamDetailsById(StudentId, OexamId);
        }

        [HttpGet]
        [Route("OnlineExamStatusByStudent")]
        public OexamResultInfo OnlineExamStatusByStudent(string AccademicId, string ClassId, string StudentId, string OexamId)
        {
        OexamResultInfo result = new OexamResultInfo();
        
            try
            {
                result = _onlineexamRepository.OnlineExamStatusByStudent(AccademicId, ClassId, StudentId, OexamId);
                string[] Sub_result = result.RESULT.Split(',');
                result.RESULT = Sub_result[0].ToString();
                result.OEXAM_ATTEMPT_ID =System.Convert.ToInt32(Sub_result[1].ToString());
                result.OEXAM_DURATION = System.Convert.ToInt32(Sub_result[2].ToString());
                result.ELAPSED_TIME = System.Convert.ToInt32(Sub_result[3].ToString());
                result.JSON_ERROR = "NOERROR";

                if(result.RESULT.ToString()=="FAILED")
                {
                    result.JSON_ERROR = "ERRORINDATABASE";
                }
            }
            catch(Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAILED";
                result.JSON_ERROR = ee.Message.ToString();
            }
        return result;
    }

        [HttpGet]
        [Route("QuestionListForStart")]
        public QuestionListRootInfo QuestionListForStart(string OexamId, string OexamAttemptId)
        {
            return _onlineexamRepository.QuestionListForStart(OexamId, OexamAttemptId);
        }

        [HttpGet]
        [Route("OptionsList")]
        public OptionAttemptRootInfo OptionsList(string QuestionId, string OexamAttemptId)
        {
            return _onlineexamRepository.OptionsList(QuestionId, OexamAttemptId);
        }


        [HttpPost]
        [Route("SubmitOption")]
        public DbResultInfo SubmitOption(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result =  _onlineexamRepository.SubmitOption(osi);
            }
            catch(Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAIL";
            }

            return result;
        }


        [HttpPost]
        [Route("PauseExam")]
        public DbResultInfo PauseExam(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result = _onlineexamRepository.PauseExam(osi);
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAIL";
            }

            return result;
        }

        [HttpPost]
        [Route("FinishExam")]
        public DbResultInfo FinishExam(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result = _onlineexamRepository.FinishExam(osi);
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAIL";
            }

            return result;
        }

        [HttpPost]
        [Route("DoAutoEnd")]
        public DbResultInfo DoAutoEnd(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result = _onlineexamRepository.DoAutoEnd(osi);
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAIL";
            }

            return result;
        }

        [HttpPost]
        [Route("DeleteOption")]
        public DbResultInfo DeleteOption(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result = _onlineexamRepository.DeleteOption(osi);
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAIL";
            }

            return result;
        }


        [HttpGet]
        [Route("OnlineExamResult")]
        public OnlineExamResultRootNewInfo OnlineExamResult(string AccademicId, string StudentId, string OexamId, string OexamAttemptId)
        {
            return _onlineexamRepository.OnlineExamResult(AccademicId, StudentId, OexamId, OexamAttemptId);
        }


        [HttpGet]
        [Route("ChapterList")]
        public ChapterRootInfo ChapterList(string AccademicId, string ClassId, string SubjectId)
        {
            return _onlineexamRepository.ChapterList(AccademicId, ClassId, SubjectId);
        }


        [HttpGet]
        [Route("YoutubeList")]
        public YoutubeListRootInfo YoutubeList(string AccademicId, string ClassId, string SubjectId, string ChapterId)
        {
            YoutubeListRootInfo result = new YoutubeListRootInfo();
            try {
                result= _onlineexamRepository.YoutubeList(AccademicId, ClassId, SubjectId, ChapterId);
           }
            catch(Exception ee)
            {
                //string error= ee.Message.ToString();
                result.YoutubeList[0].YOUTUBE_TITLE = ee.Message.ToString();
            }
            return result;
        }

        [HttpGet]
        [Route("AssignmentList")]
        public AssignmentListRootInfo AssignmentList(string AccademicId, string ClassId, string StudentId,string SubjectId)
        {
            AssignmentListRootInfo result = new AssignmentListRootInfo();
            try
            {
                result = _onlineexamRepository.AssignmentList( AccademicId,  ClassId,  StudentId,  SubjectId);
            }
            catch (Exception ee)
            {
                //string error= ee.Message.ToString();
                result.AssignmentList[0].ASSIGNMENT_NAME = ee.Message.ToString();
            }
            return result;
        }

        [HttpGet]
        [Route("AssignmentStatusByStudent")]
        public AssignmentStatusRootInfo AssignmentStatusByStudent(string AccademicId, string ClassId, string StudentId, string AssignmentId)
        {
            AssignmentStatusRootInfo result = new AssignmentStatusRootInfo();
            try
            {
                result = _onlineexamRepository.AssignmentStatusByStudent(AccademicId, ClassId, StudentId, AssignmentId);
            }
            catch (Exception ee)
            {
                //string error= ee.Message.ToString();
                result.AssignmentDetails.ASSIGNMENT_NAME= ee.Message.ToString();
            }
            return result;
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
                sPath = "C:/inetpub/vhosts/passdaily.in/subdomains/" + SubDomain + "/AssignmentFile/";
                //sPath = "C:/inetpub/vhosts/gtgroups.in/subdomains/" + SubDomain + "/AssignmentFile/";
                //sPath = "C:/inetpub/vhosts/classdaily.in/subdomains/" + SubDomain + "/AssignmentFile/";

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
        [Route("AssignmentSubmit")]
        public DbResultInfo AssignmentSubmit(AssignmentInsertInfo asm)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result = _onlineexamRepository.AssignmentSubmit(asm);
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAIL";
            }

            return result;
        }

        [HttpGet]
        [Route("AssignmentFileDelete")]
        public DbResultInfo AssignmentFileDelete(string AssignmentFileId)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result = _onlineexamRepository.AssignmentFileDelete(AssignmentFileId);
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAIL";
            }

            return result;
        }

        [HttpGet]
        [Route("PlayLog")]
        public DbResultInfo PlayLog(string AccademicId, string ClassId, string StudentId, string YoutubeId)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result = _onlineexamRepository.PlayLog(AccademicId, ClassId, StudentId, YoutubeId);
                //result.RESULT = "SUCCESS";
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAILED";
            }
            finally
            {

            }
            return result;
        }


        [HttpGet]
        [Route("AssignmentStatusByStudentNew")]
        public AssignmentStatusNewRootInfo AssignmentStatusByStudentNew(string AccademicId, string ClassId, string StudentId, string AssignmentId)
        {
            AssignmentStatusNewRootInfo result = new AssignmentStatusNewRootInfo();
            try
            {
                result = _onlineexamRepository.AssignmentStatusByStudentNew(AccademicId, ClassId, StudentId, AssignmentId);
            }
            catch (Exception ee)
            {
                //string error= ee.Message.ToString();
                result.AssignmentDetails.ASSIGNMENT_NAME = ee.Message.ToString();
            }
            return result;
        }

        [HttpGet]
        [Route("BlockStatus")]
        public BlockStatusRootInfo BlockStatus(string AccademicId, string StudentId)
        {            
            
         return _onlineexamRepository.BlockStatus(AccademicId, StudentId);             
        }



        [HttpGet]
        [Route("OnlineExamResultNew")]
        public OnlineExamListRootNewInfo OnlineExamResultNew(string AccademicId, string StudentId, string OexamId, string OexamAttemptId)
        {
            return _onlineexamRepository.OnlineExamResultNew(AccademicId, StudentId, OexamId, OexamAttemptId);
        }

        [HttpGet]
        [Route("MeetingList")]
        public ZoomMeetingRootInfo MeetingList(string AccademicId, string ClassId, string StudentId)
        {
            return _onlineexamRepository.MeetingList(AccademicId, ClassId, StudentId);
        }

        [HttpGet]
        [Route("MeetingLog")]
        public DbResultInfo MeetingLog(string ZMeetingId, string AccademicId, string ClassId, string StudentId)
        {
            return _onlineexamRepository.MeetingLog(ZMeetingId,AccademicId, ClassId, StudentId);
        }

        [HttpGet]
        [Route("DownloadLog")]
        public DbResultInfo DownloadLog(string AccademicId, string ClassId, string StudentId, string YoutubeId)
        {
            DbResultInfo result = new DbResultInfo();
            try
            {
                result = _onlineexamRepository.DownloadLog(AccademicId, ClassId, StudentId, YoutubeId);
                //result.RESULT = "SUCCESS";
            }
            catch (Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = "FAILED";
            }
            finally
            {

            }
            return result;
        }

        [HttpGet]
        [Route("LiveClassList")]
        public StartMeetingRootInfo LiveClassList(string AccademicId, string ClassId, string SubjectId, string StudentId, string SchoolId)
        {
            return _onlineexamRepository.LiveClassList(AccademicId, ClassId,SubjectId, StudentId, SchoolId);
        }

        [HttpGet]
        [Route("MeetingAttend")]
        public DbResultInfo MeetingAttend(string ZLiveClassId, string AccademicId, string StudentId, string ZoomMeetingStatus)
        {
            return _onlineexamRepository.MeetingAttend( ZLiveClassId,  AccademicId,  StudentId,  ZoomMeetingStatus);
        }

        [HttpGet]
        [Route("MeetingAttend")]
        public DbResultInfo MeetingStatusUpdate(string ZLiveClassId, string AccademicId, string StudentId, string MeetingStatus)
        {
            DbResultInfo result = new DbResultInfo();
            string ZoomMeetingStatus = "0";

            try
            {

                if (MeetingStatus.ToString() == "MEETING_STATUS_CONNECTING")
                {
                    ZoomMeetingStatus = "1";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_DISCONNECTING")
                {
                    ZoomMeetingStatus = "2";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_FAILED")
                {
                    ZoomMeetingStatus = "3";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_IDLE")
                {
                    ZoomMeetingStatus = "4";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_IN_WAITING_ROOM")
                {
                    ZoomMeetingStatus = "5";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_INMEETING")
                {
                    ZoomMeetingStatus = "6";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_RECONNECTING")
                {
                    ZoomMeetingStatus = "7";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_UNKNOWN")
                {
                    ZoomMeetingStatus = "8";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_WAITINGFORHOST")
                {
                    ZoomMeetingStatus = "9";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_WEBINAR_DEPROMOTE")
                {
                    ZoomMeetingStatus = "10";
                }
                if (MeetingStatus.ToString() == "MEETING_STATUS_WEBINAR_PROMOTE")
                {
                    ZoomMeetingStatus = "11";
                }
                result = _onlineexamRepository.MeetingStatusUpdate(ZLiveClassId, AccademicId, StudentId, ZoomMeetingStatus);

            }

            catch(Exception ee)
            {
                string error = ee.Message.ToString();
                result.RESULT = error;
            }

            return result;
            
        }





    }
}
