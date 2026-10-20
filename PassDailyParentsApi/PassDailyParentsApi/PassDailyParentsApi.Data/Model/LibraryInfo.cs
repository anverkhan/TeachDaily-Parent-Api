using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class LibraryInfo
    {
        public string BOOK_CODE { get; set; }
        public string BOOK_NAME { get; set; }
        public string BOOK_AUTHOR { get; set; }
        public string BOOK_PRICE { get; set; }
        public String BOOK_SUMMARY { get; set; }

        public int? STUDENT_ID { get; set; }
        public DateTime? ISSUE_DATE { get; set; }
        public DateTime? EXPECTED_DATE { get; set; }
        public DateTime? RETURNED_DATE { get; set; }
        public byte? RETURN_STATUS { get; set; }
        public int? FINE_AMOUNT { get; set; }
        public byte? FINE_STATUS { get; set; }
        public int? PAID_AMOUNT { get; set; }
    }
}
