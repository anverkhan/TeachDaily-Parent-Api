using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class AccademicInfo
    {
        
        public int ACCADEMIC_ID { get; set; }
        
        public string ACCADEMIC_TIME { get; set; }
        
        public byte? ACCADEMIC_STATUS { get; set; }

        public string YOUTUBE_LINK { get; set; } = "https://youtube.com/watch?v=VQLEf6DuraI&feature=share";
    }
}
