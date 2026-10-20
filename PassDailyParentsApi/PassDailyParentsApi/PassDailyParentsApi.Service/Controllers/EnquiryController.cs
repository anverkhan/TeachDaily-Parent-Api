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
    public class EnquiryController : ApiController
    {
        private IEnquiryRepository _enquiryRepository;
        public EnquiryController()
        {
            _enquiryRepository = new EnquiryRepository();
           
        }
        [HttpPost]
        public DbResultInfo EnquiryRequest(EnquiryRequestInfo enq)
        {
            
        return _enquiryRepository.EnquiryRequest(enq);
           
        }
        
        [HttpGet]
        public EnquiryListInfoRoot EnquiryListForEdit(string EnquiryId)
        {
            
        return _enquiryRepository.EnquiryListForEdit(EnquiryId);
            
        }
        
        [HttpGet]
        public DbResultInfo EnquiryDelete(string Enquiry_Id)
        {
           
        return _enquiryRepository.EnquiryDelete(Enquiry_Id);
            
        }
    }
}
