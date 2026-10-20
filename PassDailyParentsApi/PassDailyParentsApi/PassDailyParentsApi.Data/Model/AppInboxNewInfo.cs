using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AppInboxNewInfo
    {
        public int VIRTUAL_MAIL_SENT_STUNDENT_ID { get; set; }
        public int VIRTUAL_MAIL_SENT_ID { get; set; }

        public string VIRTUAL_MAIL_TITLE { get; set; }

        public string VIRTUAL_MAIL_CONTENT { get; set; }

        public int? VIRTUAL_MAIL_TYPE { get; set; }

        public int ACCADEMIC_ID { get; set; }

        public string CLASS_SECTION { get; set; }

        public int CLASS_ID { get; set; }

        public int STUDENT_ID { get; set; }

        public DateTime? VIRTUAL_MAIL_SENT_DATE { get; set; }

        public int? VIRTUAL_MAIL_SENT_BY { get; set; }

        public int? VIRTUAL_MAIL_SENT_STATUS { get; set; }

        public DateTime? VIRTUAL_MAIL_READ_DATE { get; set; }

        public int? VIRTUAL_MAIL_READ_STATUS { get; set; }
    }
}
