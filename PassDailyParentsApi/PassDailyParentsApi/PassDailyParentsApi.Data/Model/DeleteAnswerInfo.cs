using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class DeleteAnswerInfo
    {
        public int? EXAM_ATTEMPT_ID { get; set; }
        public int? EXAM_ID { get; set; }
        public int? QUESTION_ID { get; set; }
        public int? ELAPSED_TIME { get; set; }
    }
}
