using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class OnlineDExamListInfo
    {
        public int? EXAM_ID { get; set; }
        public string EXAM_KEY { get; set; }
        public int? ADMIN_ID { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? CLASS_ID { get; set; }
        public int? SUBJECT_ID { get; set; }
        public string EXAM_NAME { get; set; }
        public string EXAM_DESCRIPTION { get; set; }
        public int? EXAM_DURATION { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? ALLOWED_PAUSE { get; set; }
        public int? STATUS { get; set; }
        public string CLASS_NAME { get; set; }
        public string SUBJECT_NAME { get; set; }
        public string ACCADEMIC_TIME { get; set; }
        public int? TOTAL_QUESTION { get; set; }
        public int? TOTAL_OUTOFF_MARK { get; set; }
        public int? EXAM_ATTEMPT_ID { get; set; }
        public int? IS_AUTO_ENDED { get; set; }
        public int? IS_SUBMITTED { get; set; }
        public int? EXAM_ATTEMPT_STATUS { get; set; }
        public DateTime? TIME_NOW { get; set; }
        public int? PAUSED_COUNT { get; set; }
        public int? TOTAL_ANSWERED_QUESTIONS { get; set; }
        public DateTime? ATTEMPTED_ON { get; set; }

        public string SUBJECT_ICON { get; set; } = "General.png";

    }
}
