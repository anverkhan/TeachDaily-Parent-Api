using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class DOnlineExamStudentResultInfo
    {
        public int? EXAM_ATTEMPT_ID { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? CLASS_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public int? EXAM_ID { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public int? ELAPSED_TIME { get; set; }
        public int? TOTAL_QUESTIONS { get; set; }
        public int? TOTAL_OUTOFF_MARK { get; set; }
        public int? TOTAL_MARK_SCORED { get; set; }
        public int? ANSWERED_QUESTIONS { get; set; }
        public int? IS_PAUSED { get; set; }
        public int? PAUSED_COUNT { get; set; }
        public int? IS_AUTO_ENDED { get; set; }
        public int? IS_SUBMITTED { get; set; }
        public int? ADMIN_ID { get; set; }
        public int? EXAM_ATTEMPT_STATUS { get; set; }
        public string EXAM_NAME { get; set; }
        public string EXAM_DESCRIPTION { get; set; }
        public int? EXAM_DURATION { get; set; }
        public string CLASS_NAME { get; set; }
        public string SUBJECT_NAME { get; set; }
        public string ACCADEMIC_TIME { get; set; }
        public string STUDENT_NAME { get; set; }
    }
}
