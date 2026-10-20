using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class HolidayInfo
    {
        public int? WORKING_ID { get; set; }
        public int? WORKING_DAY { get; set; }
        public int? WORKING_MONTH { get; set; }
        public int? WORKING_YEAR { get; set; }
        public int? ACCADEMIC_YEAR { get; set; }
        public byte? WORKING_STATUS { get; set; }
        public string WORKING_DESCRIPTION { get; set; }
        public DateTime? WORKING_DATE { get; set; }
        public string ACCADEMIC_TIME { get; set; }

    }
}
