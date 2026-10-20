using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class ZoomMeetingInfo
    {
        public int? Z_MEETING_ID { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? CLASS_ID { get; set; }
        public string MEETING_TITLE { get; set; }
        public string MEETING_ID { get; set; }
        public string MEETING_PASSWORD { get; set; }
        public string MEETING_LINK { get; set; }
        public DateTime? MEETING_STATR_DATE { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? CREATED_BY { get; set; }
        public int? MEETING_STATUS { get; set; }
        public string ACCADEMIC_TIME { get; set; }
        public string CLASS_NAME { get; set; }
        public int? ADMIN_ID { get; set; }
    }
}
