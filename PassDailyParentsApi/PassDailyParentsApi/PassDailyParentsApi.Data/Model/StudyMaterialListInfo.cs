using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class StudyMaterialListInfo
    {
        

        public int? STUDY_METERIAL_ID { get; set; }
        
        public int? ACCADEMIC_ID { get; set; }
        
        public int? CLASS_ID { get; set; }
        
        public string STUDY_METERIAL_TITLE { get; set; }
        
        public string STUDY_METERIAL_DESCRIPTION { get; set; }
        
        public string STUDY_METERIAL_FILE { get; set; }
        
        public byte? STUDY_METERIAL_STATUS { get; set; }
        
        public string CLASS_NAME { get; set; }

        public string SUBJECT_NAME { get; set; }

        public DateTime? STUDY_METERIAL_DATE { get; set; }

        public int? SUBJECT_ID { get; set; }
        public string ACCADEMIC_TIME { get; set; }

        public int? TOTAL_FILE { get; set; }

        public string SUBJECT_ICON { get; set; } = "General.png";
    }
}
