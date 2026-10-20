using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class ClassListInfo
    {
        public int? CLASS_ID { get; set; }
        public string CLASS_NAME { get; set; }
        public string CLASS_DESCRIPTION { get; set; }
        public byte? CLASS_STATUS{ get; set; }
    }
}
