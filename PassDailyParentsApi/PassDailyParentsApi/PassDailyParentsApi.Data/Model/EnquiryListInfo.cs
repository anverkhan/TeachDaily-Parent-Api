using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class EnquiryListInfo
    {
        
        public int QUERY_ID { get; set; }
        
        public string QUERY_SUBJECT { get; set; }
        
        public string QUERY_DESCRIPTION { get; set; }
        
        public int STUDENT_ID { get; set; }
        
        public int STUDENT_ROLL_NUMBER { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public int ACCADEMIC_ID { get; set; }
        
        public DateTime? QUERY_SUBMITTED_DATE { get; set; }
        
        public string QUERY_REPLY { get; set; }
        
        public DateTime? QUERY_REPLYED_DATE { get; set; }
        
        public int? QUERY_REPLYED_BY { get; set; }
        
        public byte? QUERY_STATUS { get; set; }

    }
}
