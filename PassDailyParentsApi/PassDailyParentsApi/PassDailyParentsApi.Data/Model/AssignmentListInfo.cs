using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AssignmentListInfo
    {
         public int? ASSIGNMENT_ID { get; set; }
        public int? ADMIN_ID { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? CLASS_ID { get; set; }
        public int? SUBJECT_ID { get; set; }
        public string ASSIGNMENT_NAME { get; set; }
        public string ASSIGNMENT_DESCRIPTION { get; set; }
        public DateTime? START_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? STATUS { get; set; }
        public string CLASS_NAME { get; set; }
        public string SUBJECT_NAME { get; set; }
        public string ACCADEMIC_TIME { get; set; }
        public int? ASSIGNMENT_SUBMIT_ID { get; set; }
        public int? ASSIGNMENT_MARK { get; set; }
        public int? ASSIGNMENT_STUTUS { get; set; }
        public DateTime? TIME_NOW { get; set; }

        public string SUBJECT_ICON { get; set; } = "General.png";

        public int? SCHOOL_ID { get; set; }
        public string CHAPTER_NO { get; set; } = string.Empty;
        public string PAGE_NO { get; set; } = string.Empty;
    }
}
