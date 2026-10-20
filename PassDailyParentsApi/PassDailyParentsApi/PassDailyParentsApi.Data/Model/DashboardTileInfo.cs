using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class DashboardTileInfo
    {
        
        public int TOTAL_ABSENTS { get; set; }
        
        public int TOTAL_LEAVENOTES { get; set; }
        
        public int TOTAL_ENQUIRY { get; set; }
        
        public int TOTAL_INBOX { get; set; }
        
        public int TOTAL_NOTICEBOARD { get; set; }
        
        public int TOTAL_STUDYMATERIAL { get; set; }

        public int TOTAL_VIDEOS { get; set; }

        public int TOTAL_OBJECTIVE { get; set; }

        public int TOTAL_DESCRIPTIVE { get; set; }

        public int TOTAL_ASSIGNMENT { get; set; }

        public int TOTAL_LIVE_CLASS { get; set; }
    }
}
