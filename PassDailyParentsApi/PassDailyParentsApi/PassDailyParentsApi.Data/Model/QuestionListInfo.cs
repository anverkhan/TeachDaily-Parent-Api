using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class QuestionListInfo
    {
        public int? QUESTION_ID { get; set; }
        public int? QUESTION_KEY { get; set; }
        public int? ADMIN_ID { get; set; }
        public int? OEXAM_ID { get; set; }
        public int? QUESTION_TYPE_ID { get; set; }
        public int? QUESTION_ORDER { get; set; }
        public string QUESTION_TITLE { get; set; }
        public string QUESTION_CONTENT { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public int? STATUS { get; set; }
        public string OEXAM_NAME { get; set; }

        public int? TOTAL_QUESTIONS { get; set; }
        public int? ANSWERED_QUESTIONS { get; set; }
        public int? ELAPSED_TIME { get; set; }

        public int? OEXAM_ATTEMPT_D_ID { get; set; }
        public int? QUESTION_ID_ATTEMPT { get; set; }
        public int? ANSWERED_OPTION_ID { get; set; }

        public int? OEXAM_ATTEMPT_ID { get; set; }

        public string ANSWER_KEY { get; set; }
        public int? ANSWER_KEY_FILE_TYPE { get; set; }
        public string ANSWER_KEY_FILE { get; set; }
}
}
