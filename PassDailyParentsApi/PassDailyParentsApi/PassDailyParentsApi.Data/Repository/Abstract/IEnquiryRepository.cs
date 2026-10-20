using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IEnquiryRepository
    {
        DbResultInfo EnquiryRequest(EnquiryRequestInfo enq);

        EnquiryListInfoRoot EnquiryList(EnquiryFilterInfo enq);

        DbResultInfo EnquiryDelete(string Leave_Id);

        EnquiryListInfoRoot EnquiryListForEdit(string Enquiry_Id);

        DbResultInfo EnquiryRequestUpdate(EnquiryRequestInfo enq);
    }
}
