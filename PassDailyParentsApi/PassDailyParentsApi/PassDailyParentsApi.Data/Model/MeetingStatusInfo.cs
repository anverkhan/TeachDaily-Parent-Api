using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class MeetingStatusInfo
    {
        public int? Z_LIVE_CLASS_ID {get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public int? ZOOM_MEETING_STATUS { get; set; }
        public string MEETING_STATUS { get; set; }

    }
}
