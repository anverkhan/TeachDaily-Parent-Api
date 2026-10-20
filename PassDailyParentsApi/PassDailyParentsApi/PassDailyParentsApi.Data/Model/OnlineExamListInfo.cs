using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class OnlineExamListInfo
    {
        public int? OEXAM_ID { get; set; }
        public string OEXAM_KEY { get; set; }
        public int? ADMIN_ID { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? CLASS_ID { get; set; }
        public int? SUBJECT_ID { get; set; }
        public string OEXAM_NAME { get; set; }
        public string OEXAM_DESCRIPTION { get; set; }
        public int? OEXAM_DURATION { get; set; }
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
        public int? OEXAM_ATTEMPT_ID { get; set; }
        public int? IS_AUTO_ENDED { get; set; }
        public int? IS_SUBMITTED { get; set; }
        public DateTime? ATTEMPTED_ON { get; set; }
        public int? PAUSED_COUNT { get; set; }
        public int? ANSWERED_QUESTIONS { get; set; }
        public string STUDENT_NAME { get; set; }
        public DateTime? TIME_NOW { get; set; }

        public string SUBJECT_ICON { get; set; } = "General.png";
    }
}
