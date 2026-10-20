using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class ExamNameInfo
    {
        
        public int EXAM_ID { get; set; }
        
        public string EXAM_NAME { get; set; }
        
        public string EXAM_DESCRIPTION { get; set; }
        
        public byte? EXAM_STATUS{get;set;}
    }
}
