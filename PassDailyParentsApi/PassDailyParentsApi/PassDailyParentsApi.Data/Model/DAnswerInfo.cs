using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class DAnswerInfo
    {
        public int? QUESTION_ID { get; set; }
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
