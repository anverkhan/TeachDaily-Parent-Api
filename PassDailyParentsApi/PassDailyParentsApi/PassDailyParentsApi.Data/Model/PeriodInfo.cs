using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class PeriodInfo
    {
        public int? CLASS_ID { get; set; }
        public int? SUBJECT_ID { get; set; }
        public string SUBJECT_NAME { get; set; }
        public string PERIOD_NAME { get; set; }
        public string SUBJECT_ICON { get; set; } = "General.png";
    }
}
