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
    public class EnquiryListController : ApiController
    {
        private IEnquiryRepository _enquiryRepository;
        public EnquiryListController()
        {
            _enquiryRepository = new EnquiryRepository();

        }

        [HttpPost]
        public EnquiryListInfoRoot EnquiryList(EnquiryFilterInfo enq)
        {

            return _enquiryRepository.EnquiryList(enq);

        }
    }
}
