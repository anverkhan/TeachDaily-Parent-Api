using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class LeaveListInfo
    {
        
        public int LEAVE_ID { get; set; }
        
        public string LEAVE_SUBJECT { get; set; }
        
        public string LEAVE_DESCRIPTION { get; set; }
        
        public int STUDENT_ID { get; set; }
        
        public int STUDENT_ROLL_NUMBER { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public int ACCADEMIC_ID { get; set; }
        
        public DateTime? LEAVE_FROM_DATE { get; set; }
        
        public DateTime? LEAVE_TO_DATE { get; set; }
        
        public DateTime? LEAVE_SUBMITTED_DATE { get; set; }
        
        public DateTime? LEAVE_APPROVED_DATE { get; set; }
        
        public int? LEAVE_APPROVED_BY { get; set; }
        
        public byte LEAVE_STATUS { get; set; }

        public int? SCHOOL_ID { get; set; } = 1;
    }
}
