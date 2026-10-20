using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class FeesPaidInfo
    {

        //public int RECEIPT_ID { get; set; }

        public Int64 RECEIPT_ID { get; set; }

        public int STUDENT_ID { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public int ACCADEMIC_ID { get; set; }
       
        public int ROLL_NUMBER { get; set; }
        
        public int RECEIPT_TOTAL { get; set; }
       
        public DateTime? RECEIPT_DATE { get; set; }
        
        public string CLASS_NAME { get; set; }
       
        public string STUDENT_FNAME { get; set; }
       
        public string ACCADEMIC_TIME { get; set; }

        public string PAYMENT_MODE { get; set; } 

        public string FEE_TYPE { get; set; } 

        public string BALANCE { get; set; }

        public string DOWNLOAD_LINK { get; set; } 

        public string BALANCE_SHOW { get; set; } 

        public string DETAILS_SHOW { get; set; } 

        public string DOWNLOAD_SHOW { get; set; } 

        public string REDIRECT_SHOW { get; set; } 


    }
}
