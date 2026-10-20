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
    [RoutePrefix("PassDailyParentsApi/Login")]
    public class LoginController : ApiController
    {
        static string EntityId = ConfigurationManager.AppSettings["EntityId"].ToString();
        static string SchoolName = ConfigurationManager.AppSettings["SchoolName"].ToString();
        static string SenderId = ConfigurationManager.AppSettings["SenderId"].ToString();

        private IParentAccountRepository _parentaccountRepository;
        private IParentLoginRepository _parentloginRepository;
        


        public LoginController()
        {
            _parentaccountRepository = new ParentAccountRepository();
            _parentloginRepository = new ParentLoginRepository();
           
        }

        [HttpGet]
        [Route("ParentAccountCreate")]
        public ParentAccountInfo ParentAccountCreate(string MobileNumber, string SchoolCode="3030")
        {
            string mobile = "";
            string username = "";
            string password = "";
            ParentAccountInfo info = _parentaccountRepository.ParentAccountCreate(MobileNumber, SchoolCode);
            try
            {
               
                if (info.RESULT == "EXIST")
                {
                    if (info.PUSER_NAME != "" && info.PPASSWORD != "")
                    {
                        mobile = info.PUSER_NAME.ToString();
                        username = info.PUSER_NAME.ToString();
                        password = info.PPASSWORD.ToString();
                    }

                    string content = "Your Login Credential is username : " + username + " & password : " + password + "";

                    content = ContentFiltering(content);

                    //string content = "Your Login Information  LoginId : " + username + " Password: " + password;                    
                    //string strUrl = "http://vasbay.com/webservice/smsSimpleApi.php?usersName=616e766572&key=d63c0fcf1b06113a10aee317cdce23bc&route=2&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&numbers=" + mobile + "&senderId=" + SenderId + "";
                    //string strUrl = "http://bulksms.360marketings.in/vendorsms/pushsms.aspx?user=anverkhan&password=anver1986&msisdn=" + mobile + "&sid=" + SenderId + "&msg=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&fl=0&gwid=2";                    
                    //string strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20" + "Parent" + "%2C%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=" + SenderId + "";

                    string strUrl = "https://api.onex-aura.com/api/sms?key=Ds8cX4bE&to=" + mobile + "&from=" + SenderId + "&body=Dear%20" + "Parent" + "%2C%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&entityid=" + EntityId + "&templateid=" + "1707161589848176103" + "";

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    WebRequest request = HttpWebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();

                    

                }
                if (info.RESULT == "SUCCESS")
                {
                    if (info.PUSER_NAME != "" && info.PPASSWORD != "")
                    {
                        mobile = info.PUSER_NAME.ToString();
                        username = info.PUSER_NAME.ToString();
                        password = info.PPASSWORD.ToString();
                    }

                    string content = "Your Login Credential is username : " + username + " & password : " + password + "";

                    content = ContentFiltering(content);

                    //string content = "Your Login Information  LoginId : " + username + " Password: " + password;                                        
                    //string strUrl = "http://bulksms.360marketings.in/vendorsms/pushsms.aspx?user=anverkhan&password=anver1986&msisdn=" + mobile + "&sid=" + SenderId + "&msg=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&fl=0&gwid=2";                    
                    //string strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20" + "Parent" + "%2C%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=" + SenderId + "";

                    string strUrl = "https://api.onex-aura.com/api/sms?key=Ds8cX4bE&to=" + mobile + "&from=" + SenderId + "&body=Dear%20" + "Parent" + "%2C%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&entityid=" + EntityId + "&templateid=" + "1707161589848176103" + "";

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    WebRequest request = HttpWebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();

                    


                }

               
            }
            catch (Exception ex)
            {
                info.RESULT = ex.Message.ToString();  
            }
            return info;
        }

        [HttpGet]
        [Route("ValidateLogin")]
        public ParentLoginResponse ValidateLogin(string Username, string Password, string SchoolCode="3030")
        {
            
                return _parentloginRepository.Login(Username, Password, SchoolCode);
            
            
        }

        [HttpGet]
        [Route("GetChildrenDetails")]
        public ChildInfoRoot GetChildrenDetails(int parentId)
        {

         return _parentloginRepository.GetChildrenDetails(parentId);
            
        }

        [HttpGet]
        [Route("DistrictClassList")]
        public DistrictClassListRootInfo DistrictClassList()
        {

            return _parentloginRepository.DistrictClassList();


        }

        [HttpPost]
        [Route("Registration")]
        public ParentAccountInfo Registration(RegistrationInfo Rginfo)
        {
            string mobile = "";
            string username = "";
            string password = "";
            ParentAccountInfo info = _parentloginRepository.Registration(Rginfo);
            try
            {

                if (info.RESULT == "EXIST")
                {
                    if (info.PUSER_NAME != "" && info.PPASSWORD != "")
                    {
                        mobile = info.PUSER_NAME.ToString();
                        username = info.PUSER_NAME.ToString();
                        password = info.PPASSWORD.ToString();
                    }
                    string content = "Your Login Information  LoginId : " + username + " Password: " + password;
                    //string strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=" + SenderId + "";
                    //string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=anver.khan86@gmail.com:anwar1986&senderID=" + SenderId + "&receipientno=" + mobile + "&msgtxt=Dear%20Parent%2C%20%0A" + content + "%0A" + SchoolName + "&state=4";
                    //string strUrl = "http://vasbay.com/webservice/smsSimpleApi.php?usersName=616e766572&key=d63c0fcf1b06113a10aee317cdce23bc&route=2&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&numbers=" + mobile + "&senderId=" + SenderId + "";
                    string strUrl = "http://bulksms.360marketings.in/vendorsms/pushsms.aspx?user=anverkhan&password=anver1986&msisdn=" + mobile + "&sid=" + SenderId + "&msg=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&fl=0&gwid=2";
                    WebRequest request = HttpWebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();

                    try
                    {
                        strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=" + SenderId + "";

                        request = HttpWebRequest.Create(strUrl);
                        response = (HttpWebResponse)request.GetResponse();
                        s = (Stream)response.GetResponseStream();
                        readStream = new StreamReader(s);
                        dataString = readStream.ReadToEnd();
                        response.Close();
                        s.Close();
                        readStream.Close();
                    }
                    catch (Exception ee)
                    {
                        string error = ee.Message.ToString();
                    }

                }
                if (info.RESULT == "SUCCESS")
                {
                    if (info.PUSER_NAME != "" && info.PPASSWORD != "")
                    {
                        mobile = info.PUSER_NAME.ToString();
                        username = info.PUSER_NAME.ToString();
                        password = info.PPASSWORD.ToString();
                    }
                    string content = "Your Login Information  LoginId : " + username + " Password: " + password;
                    //string strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=" + SenderId + "";
                    //string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=anver.khan86@gmail.com:anwar1986&senderID=" + SenderId + "&receipientno=" + mobile + "&msgtxt=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&state=4";
                    string strUrl = "http://bulksms.360marketings.in/vendorsms/pushsms.aspx?user=anverkhan&password=anver1986&msisdn=" + mobile + "&sid=" + SenderId + "&msg=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&fl=0&gwid=2";

                    WebRequest request = HttpWebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();

                    try
                    {
                        strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=PASSDL";
                        request = HttpWebRequest.Create(strUrl);
                        response = (HttpWebResponse)request.GetResponse();
                        s = (Stream)response.GetResponseStream();
                        readStream = new StreamReader(s);
                        dataString = readStream.ReadToEnd();
                        response.Close();
                        s.Close();
                        readStream.Close();
                    }
                    catch (Exception ee)
                    {
                        string error = ee.Message.ToString();
                    }


                }


            }
            catch (Exception ex)
            {
                info.RESULT = ex.Message.ToString();
            }
            return info;

            //return _parentloginRepository.Registration(Rginfo);


        }

        [HttpGet]
        [Route("Logout")]
        public DbResultInfo Logout(int parentId)
        {

            return _parentloginRepository.Logout(parentId);

        }

        [HttpGet]
        [Route("LandingPage")]
        public LandingPageRootInfo LandingPage()
        {

            return _parentloginRepository.LandingPage();


        }

        [HttpPost]
        [Route("SibilingsAdd")]
        public DbResultInfo SibilingsAdd(RegistrationInfo Rginfo)
        {

            return _parentloginRepository.SibilingsAdd(Rginfo);


        }

        [HttpGet]
        [Route("GetSyllabus")]
        public SyllabusRootInfo GetSyllabus()
        {

            return _parentloginRepository.GetSyllabus();


        }

        [HttpGet]
        [Route("GetClassListBySyllabus")]
        public ClassListRootInfo GetClassListBySyllabus(string ClassCategoryId)
        {

            return _parentloginRepository.GetClassListBySyllabus(ClassCategoryId);

        }


        [HttpPost]
        [Route("RegistrationNew")]
        public ParentAccountInfo RegistrationNew(RegistrationInfo Rginfo)
        {
            string mobile = "";
            string username = "";
            string password = "";
            ParentAccountInfo info = _parentloginRepository.RegistrationNew(Rginfo);
            try
            {

                if (info.RESULT == "EXIST")
                {
                    if (info.PUSER_NAME != "" && info.PPASSWORD != "")
                    {
                        mobile = info.PUSER_NAME.ToString();
                        username = info.PUSER_NAME.ToString();
                        password = info.PPASSWORD.ToString();
                    }
                    string content = "Your Login Information  LoginId : " + username + " Password: " + password;
                    //string strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=" + SenderId + "";
                    //string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=anver.khan86@gmail.com:anwar1986&senderID=" + SenderId + "&receipientno=" + mobile + "&msgtxt=Dear%20Parent%2C%20%0A" + content + "%0A" + SchoolName + "&state=4";
                    //string strUrl = "http://vasbay.com/webservice/smsSimpleApi.php?usersName=616e766572&key=d63c0fcf1b06113a10aee317cdce23bc&route=2&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&numbers=" + mobile + "&senderId=" + SenderId + "";
                    string strUrl = "http://bulksms.360marketings.in/vendorsms/pushsms.aspx?user=anverkhan&password=anver1986&msisdn=" + mobile + "&sid=" + SenderId + "&msg=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&fl=0&gwid=2";
                    WebRequest request = HttpWebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();

                    try
                    {
                        strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=" + SenderId + "";

                        request = HttpWebRequest.Create(strUrl);
                        response = (HttpWebResponse)request.GetResponse();
                        s = (Stream)response.GetResponseStream();
                        readStream = new StreamReader(s);
                        dataString = readStream.ReadToEnd();
                        response.Close();
                        s.Close();
                        readStream.Close();
                    }
                    catch (Exception ee)
                    {
                        string error = ee.Message.ToString();
                    }

                }
                if (info.RESULT == "SUCCESS")
                {
                    if (info.PUSER_NAME != "" && info.PPASSWORD != "")
                    {
                        mobile = info.PUSER_NAME.ToString();
                        username = info.PUSER_NAME.ToString();
                        password = info.PPASSWORD.ToString();
                    }
                    string content = "Your Login Information  LoginId : " + username + " Password: " + password;
                    //string strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=" + SenderId + "";
                    //string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=anver.khan86@gmail.com:anwar1986&senderID=" + SenderId + "&receipientno=" + mobile + "&msgtxt=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&state=4";
                    string strUrl = "http://bulksms.360marketings.in/vendorsms/pushsms.aspx?user=anverkhan&password=anver1986&msisdn=" + mobile + "&sid=" + SenderId + "&msg=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&fl=0&gwid=2";

                    WebRequest request = HttpWebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();

                    try
                    {
                        strUrl = "https://api.textlocal.in/send?username=anver.khan86@gmail.com&password=Anver1986&sendapikey=QWV4icgvv1cjX6BJ9gcSO6NxEIbLPTyE00SVikCT6&numbers=" + mobile + "&message=Dear%20Parent%2C%20%0A" + content + "%0ARgds%2C%0A" + SchoolName + "&sender=PASSDL";
                        request = HttpWebRequest.Create(strUrl);
                        response = (HttpWebResponse)request.GetResponse();
                        s = (Stream)response.GetResponseStream();
                        readStream = new StreamReader(s);
                        dataString = readStream.ReadToEnd();
                        response.Close();
                        s.Close();
                        readStream.Close();
                    }
                    catch (Exception ee)
                    {
                        string error = ee.Message.ToString();
                    }


                }


            }
            catch (Exception ex)
            {
                info.RESULT = ex.Message.ToString();
            }
            return info;

            //return _parentloginRepository.Registration(Rginfo);


        }


        [HttpPost]
        [Route("SibilingsAddNew")]
        public DbResultInfo SibilingsAddNew(RegistrationInfo Rginfo)
        {

            return _parentloginRepository.SibilingsAddNew(Rginfo);


        }

        protected string ContentFiltering(string content)
        {
            content = content.Replace("%", "%25");
            content = content.Replace("`", "%60");
            content = content.Replace("@", "%40");
            content = content.Replace("#", "%23");
            content = content.Replace("$", "%24");
            content = content.Replace("^", "%5E");
            content = content.Replace("&", "%26");
            content = content.Replace("=", "%3D");
            content = content.Replace("{", "%7B");
            content = content.Replace("}", "%7D");
            content = content.Replace("+", "%2B");
            content = content.Replace("|", "%7C");
            // content = content.Replace("\", "%5C");
            content = content.Replace(":", "%3A");
            content = content.Replace(";", "%3B");
            // content = content.Replace(""", "%22");
            content = content.Replace("'", "%27");
            content = content.Replace("<", "%3C");
            content = content.Replace(">", "%3E");
            content = content.Replace(",", "%2C");
            content = content.Replace("?", "%3F");
            content = content.Replace("/", "%2F");
            content = content.Replace("[", "%5B");
            content = content.Replace("]", "%5D");
            return content;

        }

        [HttpGet]
        [Route("DeleteAccount")]
        public DbResultInfo DeleteAccount(int parentId)
        {

            return _parentloginRepository.DeleteAccount(parentId);

        }
    }
}
