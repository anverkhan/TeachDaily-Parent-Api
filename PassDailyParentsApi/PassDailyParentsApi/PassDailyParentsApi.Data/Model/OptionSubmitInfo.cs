using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class OptionSubmitInfo
    {
        public int? OEXAM_ATTEMPT_ID { get; set; }
        public int? QUESTION_ID { get; set; }
        public int? ANSWERED_OPTION_ID { get; set; }
        public int? ELAPSED_TIME { get; set; }
        public int? OEXAM_ID { get; set; }
    }
}
