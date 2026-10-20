using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class OexamResultInfo
    {
        public string RESULT { get; set; }
        public int? OEXAM_ATTEMPT_ID { get; set; }
        public int? OEXAM_DURATION { get; set; }
        public int? ELAPSED_TIME { get; set; }
        public string JSON_ERROR { get; set; }
    }
}
