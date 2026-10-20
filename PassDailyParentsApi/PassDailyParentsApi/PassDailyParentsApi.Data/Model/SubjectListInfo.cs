using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class SubjectListInfo
    {
        public int SUBJECT_ID { get; set; }
        public string SUBJECT_NAME { get; set; }
        public byte? SUBJECT_STATUS { get; set; }
        public int CLASS_ID { get; set; }
    }
}
