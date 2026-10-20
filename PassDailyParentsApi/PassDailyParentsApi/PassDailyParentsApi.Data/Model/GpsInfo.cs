using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class GpsInfo
    {
            public Int32? LOCATION_ID { get; set; }
            public string TERMINAL_ID { get; set; }
            public string SIM_NUMBER { get; set; }
            public string LATITUDE { get; set; }
            public string LONGITUDE { get; set; }
            public DateTime? LOCATION_DATE { get; set; }
            public DateTime? TRACK_DATE {get; set;}
            public string ACC{ get; set; }
            public string ROTATION{ get; set; }
            public string SPEED{ get; set; }
            public string MCC{ get; set; }
            public string MNC{ get; set; }
            public string LAC{ get; set; }
            public string CELLID{ get; set; }
            public string ACC2{ get; set; }
    }
}
