using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class AppInboxRequestInfo
    {
        
        public int ACCADEMIC_ID { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public int STUDENT_ID { get; set; }
        
        public string VIRTUAL_MAIL_SENT_DATE { get; set; }
        
        public string TODate { get; set; }
    }
}
