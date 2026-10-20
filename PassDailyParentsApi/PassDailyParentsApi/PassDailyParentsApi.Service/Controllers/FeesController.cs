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
    [RoutePrefix("PassDailyParentsApi/Fees")]
    public class FeesController : ApiController
    {
        private FeesRepository _feesRepository;

        private IOnlineExamRepository _onlineexamRepository = null;

        static string PayFeeId = ConfigurationManager.AppSettings["PayFeeId"].ToString();

        static string PayFeeType = ConfigurationManager.AppSettings["PayFeeType"].ToString();

        static string PayFeeLink = ConfigurationManager.AppSettings["PayFeeLink"].ToString();

        static string PayFeeRestriction = ConfigurationManager.AppSettings["PayFeeRestriction"].ToString();

        static string PayFeeClassIds = ConfigurationManager.AppSettings["PayFeeClassIds"].ToString();

        public FeesController()
        {
            _feesRepository = new FeesRepository();

            _onlineexamRepository = new OnlineExamRepository();

        }
        [HttpGet]
        [Route("FeesPaidListGet")]
        public FeesPaidInfoRoot FeesPaidListGet(int ClassId, int AccademicId, int StudentId, int StudentRollNo)
       {
            FeesPaidInfoRoot result = new FeesPaidInfoRoot();
            string error = string.Empty;
            try
            {
                

                result = _feesRepository.FeesPaidListGet(ClassId, AccademicId, StudentId, StudentRollNo);
            }
            catch(Exception ee)
            {
                error = ee.Message.ToString();
                
            }
           

            return result;
        }

        [HttpGet]
        [Route("FeesPaidDetailsForPrint")]
        public TermFeeReceiptRoot1 FeesPaidDetailsForPrint(int StudentId, int ReceiptId)
        {
            TermFeeReceiptRoot1 result = new TermFeeReceiptRoot1();
            string error = string.Empty; 
            try
            {
                
                result = _feesRepository.FeesPaidListGetV1(StudentId,  ReceiptId);
            }
            catch (Exception ee)
            {
                error = ee.Message.ToString();

            }


            return result;
        }

        [HttpGet]
        [Route("FeesPaidDetailsForPrintV")]
        public TermFeeReceiptRoot FeesPaidDetailsForPrintV(int StudentId, int ReceiptId)
        {
            TermFeeReceiptRoot result = new TermFeeReceiptRoot();
            string error = string.Empty;
            try
            {

                result = _feesRepository.FeesPaidListGetNew(StudentId, ReceiptId);
            }
            catch (Exception ee)
            {
                error = ee.Message.ToString();

            }


            return result;
        }

        [HttpGet]
        [Route("PayFeeStupGet")]
        public TermFeePay_FeeSetup PayFeeStupGet(int StudentId,int ClassId)
        {
            TermFeePay_FeeSetup result = new TermFeePay_FeeSetup();
            string error = string.Empty;
            try
            {

                //if (ClassId == 73 || ClassId == 59 || ClassId == 60 || ClassId == 61 || ClassId == 65 || ClassId == 62 || ClassId == 63 || ClassId == 64 || ClassId == 66 || ClassId == 67)
                //// if (ClassId == 1073)
                //{
                //    result.PayFeeId = StudentId;
                //    result.PayFeeType = "Webview";
                //    //result.PayFeeLink = "https://modern.pasdaily.in/?TransId=";
                //    result.PayFeeLink = "http://holy.pasdaily.in/parent/pay-fee?StudentId=";
                //    result.Status = 1;
                //} // holy


                 



                //else
                //{
                //result.PayFeeId = 4;
                //    result.PayFeeType = "ComingSoon";
                //    result.PayFeeLink = "No Record Found";
                //    result.Status = 1;
                //}


                //if (ClassId == 26 || ClassId == 29 || ClassId == 37 || ClassId == 38 || ClassId == 40 || ClassId == 39 || ClassId == 36 || ClassId == 37 || ClassId == 24 || ClassId == 67)
                //{
                //    result.PayFeeId = StudentId;
                //    result.PayFeeType = "Webview";
                //    //result.PayFeeLink = "https://modern.pasdaily.in/?TransId=";
                //    result.PayFeeLink = "http://passdaily.in/parent/pay-fee?StudentId=";
                //    result.Status = 1;
                //}
                //else
                //{
                //    result.PayFeeId = 4;
                //    result.PayFeeType = "ComingSoon";
                //    result.PayFeeLink = "No Record Found";
                //    result.Status = 1;
                //}



                //if (StudentId == 3938) 
                //{
                //    result.PayFeeId = 1;
                //    result.PayFeeType = "Browser";
                //    //result.PayFeeLink = "https://modern.pasdaily.in/?StudentId=";
                //    result.PayFeeLink = "http://passdaily.in/parent/pay-fee?StudentId=";
                //    result.Status = 1;
                //}
                //else if (StudentId == 3172)
                //{
                //    result.PayFeeId = 2;
                //    result.PayFeeType = "Webview";
                //    //result.PayFeeLink = "https://modern.pasdaily.in/?TransId=";
                //    result.PayFeeLink = "http://passdaily.in/parent/pay-fee?TransId=";
                //    result.Status = 1;
                //}
                //else if (StudentId == 3679)
                //{
                //    result.PayFeeId = 3;
                //    result.PayFeeType = "App";
                //    result.PayFeeLink = "show native layout";
                //    result.Status = 1;
                //}
                //else 
                //{
                //    result.PayFeeId = 4;
                //    result.PayFeeType = "ComingSoon";
                //    result.PayFeeLink = "No Record Found";
                //    result.Status = 1;
                //}

                //    if (ClassId == 53 || ClassId == 54)
                //    {

                //        result.PayFeeId = 2;
                //        result.PayFeeType = "Webview";
                //        result.PayFeeLink = "https://lodha.pasdaily.in/payswipe?StudentId=";
                //        result.Status = 1;
                //        // lodha mswipe
                //    }
                //    else
                //    {

                //        result.PayFeeId = 4;
                //        result.PayFeeType = "ComingSoon";
                //        result.PayFeeLink = "No Record Found";
                //        result.Status = 1;
                //    }

                //}
                //catch (Exception ee)
                //{
                //    error = ee.Message.ToString();

                //}

                BlockStatusRootInfo result1 = _onlineexamRepository.BlockStatus("13", StudentId.ToString());

                if (result1.BlockDetails.Length > 0)

                {
                    if (result1.BlockDetails[0].BLOCK_STATUS == 0)
                    {
                        if (PayFeeRestriction == "No")
                        {

                            if (PayFeeId == "1")
                            {
                                result.PayFeeId = 1;
                                result.PayFeeType = "Browser";
                                result.PayFeeLink = PayFeeLink;
                                result.Status = 1;
                            }
                            else if (PayFeeId == "2")
                            {
                                result.PayFeeId = 2;
                                result.PayFeeType = "Webview";
                                result.PayFeeLink = PayFeeLink;
                                result.Status = 1;
                            }
                            else if (PayFeeId == "3")
                            {
                                result.PayFeeId = 3;
                                result.PayFeeType = "App";
                                result.PayFeeLink = "show native layout";
                                result.Status = 1;
                            }
                            else if (PayFeeId == "4")
                            {
                                result.PayFeeId = 4;
                                result.PayFeeType = "ComingSoon";
                                result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                                result.Status = 1;
                            }
                            else
                            {
                                result.PayFeeId = 4;
                                result.PayFeeType = "ComingSoon";
                                result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                                result.Status = 1;
                            }
                        }

                        else if (PayFeeRestriction == "Yes")
                        {
                            if (PayFeeClassIds.Split(',').Select(x => x.Trim()).Contains(ClassId.ToString()))
                            {

                                if (PayFeeId == "1")
                                {
                                    result.PayFeeId = 1;
                                    result.PayFeeType = "Browser";
                                    result.PayFeeLink = PayFeeLink;
                                    result.Status = 1;
                                }
                                else if (PayFeeId == "2")
                                {
                                    result.PayFeeId = 2;
                                    result.PayFeeType = "Webview";
                                    result.PayFeeLink = PayFeeLink;
                                    result.Status = 1;
                                }
                                else if (PayFeeId == "3")
                                {
                                    result.PayFeeId = 3;
                                    result.PayFeeType = "App";
                                    result.PayFeeLink = "show native layout";
                                    result.Status = 1;
                                }
                                else if (PayFeeId == "4")
                                {
                                    result.PayFeeId = 4;
                                    result.PayFeeType = "ComingSoon";
                                    result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                                    result.Status = 1;
                                }
                                else
                                {
                                    result.PayFeeId = 4;
                                    result.PayFeeType = "ComingSoon";
                                    result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                                    result.Status = 1;
                                }
                            }
                            else
                            {
                                result.PayFeeId = 4;
                                result.PayFeeType = "ComingSoon";
                                result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                                result.Status = 1;

                            }


                        }


                    }
                    else
                    {
                        result.PayFeeId = 4;
                        result.PayFeeType = "ComingSoon";
                        result.PayFeeLink = result1.BlockDetails[0].BLOCK_MESSAGE;
                        result.Status = 1;
                    }

                }
                else
                {
                    if (PayFeeRestriction == "No")
                    {

                        if (PayFeeId == "1")
                        {
                            result.PayFeeId = 1;
                            result.PayFeeType = "Browser";
                            result.PayFeeLink = PayFeeLink;
                            result.Status = 1;
                        }
                        else if (PayFeeId == "2")
                        {
                            result.PayFeeId = 2;
                            result.PayFeeType = "Webview";
                            result.PayFeeLink = PayFeeLink;
                            result.Status = 1;
                        }
                        else if (PayFeeId == "3")
                        {
                            result.PayFeeId = 3;
                            result.PayFeeType = "App";
                            result.PayFeeLink = "show native layout";
                            result.Status = 1;
                        }
                        else if (PayFeeId == "4")
                        {
                            result.PayFeeId = 4;
                            result.PayFeeType = "ComingSoon";
                            result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                            result.Status = 1;
                        }
                        else
                        {
                            result.PayFeeId = 4;
                            result.PayFeeType = "ComingSoon";
                            result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                            result.Status = 1;
                        }
                    }

                    else if (PayFeeRestriction == "Yes")
                    {
                        if (PayFeeClassIds.Split(',').Select(x => x.Trim()).Contains(ClassId.ToString()))
                        {

                            if (PayFeeId == "1")
                            {
                                result.PayFeeId = 1;
                                result.PayFeeType = "Browser";
                                result.PayFeeLink = PayFeeLink;
                                result.Status = 1;
                            }
                            else if (PayFeeId == "2")
                            {
                                result.PayFeeId = 2;
                                result.PayFeeType = "Webview";
                                result.PayFeeLink = PayFeeLink;
                                result.Status = 1;
                            }
                            else if (PayFeeId == "3")
                            {
                                result.PayFeeId = 3;
                                result.PayFeeType = "App";
                                result.PayFeeLink = "show native layout";
                                result.Status = 1;
                            }
                            else if (PayFeeId == "4")
                            {
                                result.PayFeeId = 4;
                                result.PayFeeType = "ComingSoon";
                                result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                                result.Status = 1;
                            }
                            else
                            {
                                result.PayFeeId = 4;
                                result.PayFeeType = "ComingSoon";
                                result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                                result.Status = 1;
                            }
                        }
                        else
                        {
                            result.PayFeeId = 4;
                            result.PayFeeType = "ComingSoon";
                            result.PayFeeLink = "Online fee payment is currently unavailable. The service is expected to be available within few days.";
                            result.Status = 1;

                        }


                    }

                }



            }
            catch (Exception ee)
            {
                error = ee.Message.ToString();

                result.PayFeeId = 4;
                result.PayFeeType = "ComingSoon";
                result.PayFeeLink = error;
                result.Status = 1;

            }


            return result;
        }


    }
}
