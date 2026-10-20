using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class ChildInfo
    {
        
        public string STUDENT_FNAME { get; set; }
        
        public string STUDENT_MNAME { get; set; }
        
        public string STUDENT_LNAME { get; set; }
        
        public string STUDENT_IMAGE { get; set; }
        
        public string STUDENT_GUARDIAN_NAME { get; set; }
        
        public int? PLSTUDENT_ID { get; set; }
        
        public int? PLOGIN_ID { get; set; }
        
        public int? STUDENT_ID { get; set; }
        
        public string CLASS_NAME { get; set; }

        public int? CLASS_ID { get; set; }

        public string CLASS_SECTION { get; set; }

        public int? INBOX_COUNT { get; set; }

        public int? SCHOOL_ID { get; set; }

        
    }
}
