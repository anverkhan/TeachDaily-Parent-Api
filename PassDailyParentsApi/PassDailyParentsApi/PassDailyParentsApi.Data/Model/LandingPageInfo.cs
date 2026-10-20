using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class LandingPageInfo
    {
        public int? LANDING_ID { get; set; }
        public string LANDING_TITLE { get; set; }
        public string LANDING_DESCRIPTION { get; set; }
        public string LANDING_IMAGE { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? LANDING_STATUS { get; set; }
    }
}
