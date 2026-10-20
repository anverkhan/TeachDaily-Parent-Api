using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AssignmentInsertInfo
    {
        public int ACCADEMIC_ID { get; set; }
        public int CLASS_ID { get; set; }
        public int STUDENT_ID { get; set; }
        public int ASSIGNMENT_ID { get; set; }
        public string ASSIGNMENT_DETAILS { get; set; }
        public string ASSIGNMENT_FILE { get; set; }

    }
}
