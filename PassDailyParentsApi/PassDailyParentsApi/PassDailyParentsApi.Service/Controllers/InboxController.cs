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
    [RoutePrefix("PassDailyParentsApi/Inbox")]
    public class InboxController : ApiController
    {
        static string SchoolName = ConfigurationManager.AppSettings["SchoolName"].ToString();
        static string SenderId = ConfigurationManager.AppSettings["SenderId"].ToString();
        static string SubDomain = ConfigurationManager.AppSettings["subdomain"].ToString();

        private AppInboxRepository _appinboxRepository;
        
        public InboxController()
        {
            _appinboxRepository = new AppInboxRepository();
          
        }

        [HttpPost]
        [Route("AppInboxGet")]
        public AppInboxInfoRoot AppInboxGet(AppInboxRequestInfo inbox) 
        {
            
         return _appinboxRepository.AppInboxGet(inbox);
           
            
        }


        [HttpGet]
        [Route("AppInboxGetById")]
        public AppInboxInfoRoot AppInboxGetById(string Inbox_Id)
        {
           
         return _appinboxRepository.AppInboxGetById(Inbox_Id);
            
        }


        [HttpGet]
        [Route("AppInboxReadById")]
        public DbResultInfo AppInboxReadById(string StudentId,string InboxId)
        {

            DbResultInfo result = new DbResultInfo();
            try {
                //string Content = "Inbox Read By StudentId="+StudentId+"; InboxId="+InboxId+"";
                //string strUrl = "http://smsalertbox.com/api/sms.php?uid=616e766572&pin=4d1c73500c53c7937d63b897aed1ffe2&sender=" + SenderId + "&route=12&tempid=1&mobile=7092171154&message=" + Content + "%0ARgds%2C%0A" + SchoolName + "&pushid=1";
                //WebRequest request = HttpWebRequest.Create(strUrl);
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Stream s = (Stream)response.GetResponseStream();
                //StreamReader readStream = new StreamReader(s);
                //string dataString = readStream.ReadToEnd();
                //response.Close();
                //s.Close();
                //readStream.Close();
                //result.RESULT = "SUCCESS";

                result = _appinboxRepository.AppInboxReadById(StudentId, InboxId);
            }
            catch(Exception ee)
            {
                result.RESULT = ee.Message.ToString();

            }
            return result;

        }

        [HttpGet]
        [Route("AppInboxGetByIdNew")]
        public AppInboxInfoNewRoot AppInboxGetByIdNew(string Inbox_Id, string StudentId)
        {

            return _appinboxRepository.AppInboxGetByIdNew(Inbox_Id, StudentId);

        }


        [HttpPost()]
        [Route("UploadFiles")]
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

                sPath = "C:/inetpub/vhosts/passdaily.in/subdomains/" + SubDomain + "/Upload/VMailFile/";

                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                string fileName = Guid.NewGuid().ToString();
                // CHECK THE FILE COUNT.
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];

                    if (hpf.ContentLength > 0)
                    {

                        // Extract the file extension of the original file
                        string fileExtension = Path.GetExtension(hpf.FileName);

                        // Generate a new file name with the GUID and the original file extension
                        fileName = fileName + fileExtension;

                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                        if (!File.Exists(sPath + fileName))
                        {
                            // SAVE THE FILES IN THE FOLDER.
                            hpf.SaveAs(sPath + fileName);
                            iUploadedCnt = iUploadedCnt + 1;

                            filenameresult = fileName;
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
        [Route("SubmitReply")]
        public ResultNewInfo SubmitReply(InboxReplyInfo inbox)
        {

            return _appinboxRepository.SubmitReply(inbox);


        }



    }
}
