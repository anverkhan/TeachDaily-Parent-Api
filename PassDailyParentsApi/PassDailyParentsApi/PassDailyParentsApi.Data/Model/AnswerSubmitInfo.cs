using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AnswerSubmitInfo
    {
        public int? EXAM_ATTEMPT_ID { get; set; }
        public int? QUESTION_ID { get; set; }
        public int? ELAPSED_TIME { get; set; }
        public string ANSWER { get; set; }
        public string ANSWER_FILE_1 { get; set; }
        public string ANSWER_FILE_2 { get; set; }
        public string ANSWER_FILE_3 { get; set; }
    }
}
