using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class VideoInfo
    {
        public int? CLASS_ID { get; set; }
        public int? SUBJECT_ID { get; set; }
        public string SUBJECT_NAME { get; set; }
        public int? TOTAL_VIDEOS { get; set; }
        public string SUBJECT_ICON { get; set; } = "General.png";
    }
}
