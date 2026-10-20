using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class AttendanceReportInfo
    {
        
        public int STUDENT_ID { get; set; }
        
        public int STUDENT_ROLL_NUMBER { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public DateTime? ABSENT_DATE { get; set; }
        
        public string MONTH_NAME { get; set; }
        
        public string DAY_NAME { get; set; }
        
        public int ACCADEMIC_ID { get; set; }
        
        public string CLASS_NAME { get; set; }
        
        public string STUDENT_NAME { get; set; }
        
        public string ACCADEMIC_NAME { get; set; }
    }
}
