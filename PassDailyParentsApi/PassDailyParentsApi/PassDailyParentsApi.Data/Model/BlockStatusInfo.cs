using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class BlockStatusInfo
    {
        public Int64? STUDENT_BLOCK_ID { get; set; } 
        public int? ACCADEMIC_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public int? BLOCK_STATUS { get; set; }
        public string BLOCK_MESSAGE { get; set; }
        public DateTime? BLOCK_DATE { get; set; }
    }
}
