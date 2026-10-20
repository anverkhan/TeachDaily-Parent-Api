using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AssignmentSubmitInfo
    {
        public int? ASSIGNMENT_SUBMIT_ID { get; set; }
        public int? ACCADEMIC_ID { get; set; }
        public int? CLASS_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public int? ASSIGNMENT_ID { get; set; }
        public string ASSIGNMENT_DETAILS { get; set; }
        public int? ASSIGNMENT_MARK { get; set; }
        public string ASSIGNMENT_REPLY { get; set; }
        public DateTime? ASSIGNMENT_SUBMIT_DATE { get; set; }
        public int? ASSIGNMENT_STUTUS { get; set; }
    }
}
