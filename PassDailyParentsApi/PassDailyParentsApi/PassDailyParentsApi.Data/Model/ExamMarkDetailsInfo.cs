using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class ExamMarkDetailsInfo
    {
        
        public int MARK_ID { get; set; }
        
        public int ACCADEMIC_ID { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public int EXAM_ID { get; set; }
        
        public int SUBJECT_ID { get; set; }
        
        public int STUDENT_ROLL_NUMBER { get; set; }

        //public int PASS_MARK { get; set; }

        //public int OUTOFF_MARK { get; set; }

        //public int TOTAL_MARK { get; set; }


        public string PASS_MARK { get; set; }

        public string OUTOFF_MARK { get; set; }

        public string TOTAL_MARK { get; set; }


        public string SHOW_MARK { get; set; }


        //public string TOTAL_MARK { get; set; } 

        //public DateTime? MARK_DATE { get; set; }

        // public int MARKED_BY { get; set; }

        public string MARK_GRADE { get; set; }
        
        //public int SUBJECT_TOTALMARK { get; set; }
        
        //public int SUBJECT_PASSMARK { get; set; }
        
        public string SUBJECT_NAME { get; set; }

        public string SUBJECT_ICON { get; set; } = "General.png";

        public string GRANDTOTAL { get; set; } = "YES";

        public string PERCENTAGE { get; set; } = "YES";

    }
}
