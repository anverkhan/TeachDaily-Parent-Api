using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class TermFeeReceiptDetail
    {
        public Int64 ReceiptId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolPhone { get; set; }
        public string SchoolEmail { get; set; }
        public string SchoolLogo { get; set; }
        public int StudentId { get; set; }
        public string AdmissionNo { get; set; }
        public string StudentName { get; set; }
        public string StudentImage { get; set; }
        public string ContactNo { get; set; }
        public string ClassName { get; set; }
        public int TotalAmount { get; set; }
        public int ScholarshipAmount { get; set; }
        public int DiscountAmount { get; set; }
        public int FineAmount { get; set; }
        public int GrandTotal { get; set; }
        public string GrandTotalWords { get; set; }
        public string Remarks { get; set; }
        public string ReceiptType { get; set; }

    }
}
