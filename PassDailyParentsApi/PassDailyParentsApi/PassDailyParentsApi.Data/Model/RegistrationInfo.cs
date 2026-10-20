using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class RegistrationInfo
    {
        public string STUDENT_FNAME { get; set; }
	    public int? STUDENT_GENDER { get; set; }
        public string STUDENT_GUARDIAN_NUMBER { get; set; }
        public int? CLASS_ID { get; set; }
        public string CLASS_NAME { get; set; }
        public int? DISTRICT_ID { get; set; }
        public int? STUDENT_ID { get; set; }

    }
}
