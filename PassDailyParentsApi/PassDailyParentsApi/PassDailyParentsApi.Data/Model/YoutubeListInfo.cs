using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class YoutubeListInfo
    {
        public int? YOUTUBE_ID { get; set; }
        public string YOUTUBE_TITLE { get; set; }
        public string YOUTUBE_DESCRIPTION { get; set; }
        public string YOUTUBE_LINK { get; set; }
        public int? YOUTUBE_SORT_ORDER { get; set; }
        public DateTime? YOUTUBE_DATE { get; set; }
        public string YOUTUBE_CREATED_BY { get; set; }
        public byte? YOUTUBE_STATUS { get; set; }
        public string CLASS_NAME { get; set; }
        public string SUBJECT_NAME { get; set; }
        public string ACCADEMIC_TIME { get; set; }
        public string CHAPTER_NAME { get; set; }
        public string ORGINAL_FILE { get; set; }

        public string SUBJECT_ICON { get; set; } = "General.png";
    }
}
