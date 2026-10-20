using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class TermFeePaidDetails
    {
        public Int64 ReceiptDetailsId { get; set; }

        public int ReceiptId { get; set; }

        public int FeeId { get; set; }

        public string FeeTitle { get; set; }

        public int TermId { get; set; }

        public string TermTitle { get; set; }

        public int TotalAmount { get; set; }

        public int ScholarshipAmount { get; set; }

        public int DiscountAmount { get; set; }

        public int FineAmount { get; set; }

        public int GrandTotal { get; set; }
    }
}
