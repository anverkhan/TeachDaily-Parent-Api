using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class ActivityInfo
    {

        public int? ACTIVITY_ID { get; set; }
        public int? ACTIVITY_DAY { get; set; }
        public int? ACTIVITY_MONTH { get; set; }
        public int? ACTIVITY_YEAR { get; set; }
        public string ACTIVITY_DESCRIPTION { get; set; }
        public DateTime? ACTIVITY_DATE { get; set; }
        public int? ACADEMIC_YEAR { get; set; }
        public byte? ACTIVITY_STATUS { get; set; }

    }
}
