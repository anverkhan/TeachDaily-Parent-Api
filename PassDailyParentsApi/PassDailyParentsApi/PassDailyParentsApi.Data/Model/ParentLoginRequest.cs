using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class ParentLoginRequest
    {
        
        public string PARENT_LOGIN_NAME { get; set; }
        
        public string PARENT_PASSWORD { get; set; }
    }
}
