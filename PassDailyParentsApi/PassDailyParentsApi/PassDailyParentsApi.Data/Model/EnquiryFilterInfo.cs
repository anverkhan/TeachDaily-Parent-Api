using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class EnquiryFilterInfo
    {
        
        public int ACCADEMIC_ID { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public int STUDENT_ID { get; set; }
        
        public int STUDENT_ROLL_NUMBER { get; set; }
        
        public string QUERY_SUBMITTED_DATE { get; set; }

        public int? SCHOOL_ID { get; set; } = 1;
    }
}
