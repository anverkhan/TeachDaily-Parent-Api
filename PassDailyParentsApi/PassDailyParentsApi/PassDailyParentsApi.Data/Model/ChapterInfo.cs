using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class ChapterInfo
    {
        public int? CHAPTER_ID { get; set; }
        public string CHAPTER_NAME { get; set; }
        public byte? CHAPTER_STATUS { get; set; }
        public int? CLASS_ID { get; set; }
    }
}
