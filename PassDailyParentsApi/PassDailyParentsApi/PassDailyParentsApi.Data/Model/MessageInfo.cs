using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class MessageInfo
    {
        
        public int MESSAGE_ID { get; set; }
        
        public string MESSAGE_TITLE { get; set; }
        
        public string MESSAGE_CONTENT { get; set; }
        
        public DateTime MESSAGE_DATE { get; set; }
        
        public string MESSAGE_CREATED_BY { get; set; }
        
        public byte? MESSAGE_STATUS { get; set; }
    }
}
