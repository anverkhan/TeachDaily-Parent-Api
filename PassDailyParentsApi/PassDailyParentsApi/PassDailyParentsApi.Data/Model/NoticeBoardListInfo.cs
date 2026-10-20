using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class NoticeBoardListInfo
    {
        
        public int UPDATES_ID { get; set; }
        
        public string UPDATES_TITLE { get; set; }
        
        public string UPDATES_DATE { get; set; }
        
        public string UPDATES_DESCRIPTION { get; set; }
        
        public byte? UPDATES_STATUS { get; set; }

    }
}
