using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class InboxReplyFileDetailsInfo
    {

        public int? FILE_ID { get; set; }
        public int? VIRTUAL_MAIL_SENT_STUDENT_ID { get; set; }
        public string FILE_NAME { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? CREATED_BY { get; set; }
        public int? FILE_STATUS { get; set; }


    }
}
