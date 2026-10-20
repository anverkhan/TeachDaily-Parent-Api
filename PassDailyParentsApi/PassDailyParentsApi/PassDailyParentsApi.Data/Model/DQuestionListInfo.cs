using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class DQuestionListInfo
    {
        public int? QUESTION_ID { get; set; }
        public string QUESTION_KEY { get; set; }
        public int? ADMIN_ID { get; set; }
        public int? EXAM_ID { get; set; }
        public int? QUESTION_TYPE_ID { get; set; }
        public int? QUESTION_ORDER { get; set; }
        public string QUESTION_TITLE { get; set; }
        public string QUESTION_CONTENT { get; set; }
        public int? QUESTION_MARK { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? STATUS { get; set; }
        public string EXAM_NAME { get; set; }

        public int? TOTAL_QUESTIONS { get; set; }
        public int? ANSWERED_QUESTIONS { get; set; }
        public int? ELAPSED_TIME { get; set; }

        public int? EXAM_ATTEMPT_D_ID { get; set; }
        public int? QUESTION_ID_ATTEMPT { get; set; }
        public string ANSWER { get; set; }
        public string ANSWER_FILE_1 { get; set; }
        public string ANSWER_FILE_2 { get; set; }
        public string ANSWER_FILE_3 { get; set; }
        public int? ANSWER_MARK { get; set; }

        public string TEACHER_COMMENT { get; set; }
        public int? COMMENT_TYPE { get; set; }
        public string COMMENT_FILE { get; set; }

    }
}
