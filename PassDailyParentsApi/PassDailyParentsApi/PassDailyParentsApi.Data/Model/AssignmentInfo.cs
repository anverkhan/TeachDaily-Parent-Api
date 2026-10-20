using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AssignmentInfo
    {
        public int? ASSIGNMENT_ID { get; set; }
        public int? ADMIN_ID { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? CLASS_ID { get; set; }
        public int? SUBJECT_ID { get; set; }
        public string ASSIGNMENT_NAME { get; set; }
        public string ASSIGNMENT_DESCRIPTION { get; set; }
        public int? ASSIGNMENT_OUTOFF_MARK { get; set; }
        public DateTime? START_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? STATUS { get; set; }
        public DateTime? TIME_NOW { get; set; }
        public int? SCHOOL_ID { get; set; }
        public string CHAPTER_NO { get; set; } = string.Empty;
        public string PAGE_NO { get; set; } = string.Empty;

    }
}
