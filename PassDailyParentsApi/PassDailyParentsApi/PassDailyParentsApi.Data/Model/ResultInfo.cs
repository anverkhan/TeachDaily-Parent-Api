using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class ResultInfo
    {
        
        public int RESULT_ID { get; set; }
        
        public int ACCADEMIC_ID { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public int ROLL_NUMBER { get; set; }
        
        public int STUDENT_ID { get; set; }
        
        public int? RESULT_STATUS { get; set; }
        
        public string RESULT_STATUS_NAME { get; set; }
        
        public int? STATUS { get; set; }
        
        public string CLASS_NAME { get; set; }
        
        public string STUDENT_NAME { get; set; }

        public string ADMISSION_NUMBER { get; set; }

        public byte? STUDENT_GENDER { get; set; }

        public string STUDENT_IMAGE { get; set; }

        public string ACCADEMIC_YEAR { get; set; }
        
        public string RESULT_DESCRIPTION { get; set; }

        public string RESULT_REMARK { get; set; }
    }
}
