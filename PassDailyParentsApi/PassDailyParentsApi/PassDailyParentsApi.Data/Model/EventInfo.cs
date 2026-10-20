using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class EventInfo
    {
        public int? EVENT_ID { get; set; }
        public int? ACCADEMIC_ID{ get; set; }
        public string EVENT_TITLE{ get; set; }
        public string EVENT_DESCRIPTION { get; set; }
        public string EVENT_FILE { get; set; }
        public DateTime? EVENT_DATE{ get; set; }
        public int? ADMIN_ID{ get; set; }
        public byte? EVENT_STATUS{ get; set; }
        public int? EVENT_TYPE { get; set; }
        public string EVENT_LINK_FILE { get; set; }
    }

}
