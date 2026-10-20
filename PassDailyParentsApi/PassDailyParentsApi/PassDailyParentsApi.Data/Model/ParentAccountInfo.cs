using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class ParentAccountInfo
    {
        
        public string PUSER_NAME { get; set; }
        
        public string PPASSWORD { get; set; }
        
        public string RESULT { get; set; }

        public int? SCHOOL_ID { get; set; }
    }
}
