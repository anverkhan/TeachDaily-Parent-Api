using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class CarryingListInfo
    {

        public int? STUDENT_EL_ID { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public int? EL_TYPLE { get; set; }
        public DateTime? EL_DATE { get; set; }
        public string LATE_REMARK { get; set; }
        public string VEHICLE_DETAILS { get; set; }
        public string ID_SLIP_DETAILS { get; set; }
        public string CARRYING_NAME_RELATION { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? EL_STATUS { get; set; }
        public string ADMISSION_NUMBER { get; set; }
        public string STUDENT_FNAME { get; set; }
        public string CLASS_NAME { get; set; }
        public string ACCADEMIC_TIME { get; set; }
        public string TYPE_NAME { get; set; }


    }
}
