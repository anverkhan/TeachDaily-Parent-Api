using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class DashboardInfo
    {        
        public AcademicInfo AcademicDetails { get; set; }
        
        public DashboardTileInfo TileDetails { get; set; }

        public EventInfo[] EventDetails { get; set; }

        public AppInboxNewInfo[] InboxDetails { get; set; }

        public VideoInfo[] VideoDetails { get; set; }

        public PeriodInfo[] PeriodDetails { get; set; }

        public SubjectListInfo[] SubjectDetails { get; set; }

    }
}
