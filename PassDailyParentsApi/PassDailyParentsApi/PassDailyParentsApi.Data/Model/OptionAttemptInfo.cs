using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class OptionAttemptInfo
    {
        public int? OEXAM_ATTEMPT_D_ID { get; set; }
	    public int? OEXAM_ATTEMPT_ID { get; set; }
        public int? QUESTION_ID { get; set; }
        public int? ANSWERED_OPTION_ID { get; set; }
        public int? CORRECT_OPTION_ID { get; set; }
        public int? IS_CORRECT { get; set; }
    }
}
