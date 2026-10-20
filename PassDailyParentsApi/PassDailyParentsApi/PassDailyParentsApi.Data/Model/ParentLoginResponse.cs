using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class ParentLoginResponse
    {
        
        public int PLOGIN_ID { get; set; }
        
        public string LOGIN_ROLE { get; set; }

        public int? SCHOOL_ID { get; set; }
    }
}
