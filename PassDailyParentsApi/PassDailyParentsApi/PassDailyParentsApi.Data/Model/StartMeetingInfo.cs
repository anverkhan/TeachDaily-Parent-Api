using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class StartMeetingInfo
    {
        public int? SUBJECT_ID { get; set; }
        public string SUBJECT_NAME { get; set; }
        public byte? SUBJECT_STATUS { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? CLASS_ID { get; set; }
        public int? STAFF_ID { get; set; }
        public int? Z_LIVE_CLASS_ID { get; set; }
        public string ZOOM_MEETING_ID { get; set; }
        public string ZOOM_MEETING_PASSWORD { get; set; }
        public int? ZOOM_MEETING_STATUS { get; set; }
        public string ZOOM_MEETING_LINK { get; set; }
        public int? ZOOM_ACCADEMIC_ID { get; set; }
        public int? ZOOM_CLASS_ID { get; set; }
        public int? ZOOM_SUBJECT_ID { get; set; }
        public int? ADMIN_ID { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public DateTime? ZOOM_START_DATE { get; set; }
        public DateTime? ZOOM_END_DATE { get; set; }
        public int? Z_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public int? TOTAL_STUDENT { get; set; }

        public string SUBJECT_ICON { get; set; } = "General.png";

        public int? MEETING_DETAILS { get; set; }
        public int? PARTICIPANT_DETAILS { get; set; }
        public int? INVITE_OPTION { get; set; }
        public int? UNMUTE_AUDIO { get; set; }

        public string APP_KEY { get; set; }
        public string APP_SECRET_KEY { get; set; }
    }
}
