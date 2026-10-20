using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class OnlineExamListRootNewInfo
    {
        public OnlineExamStudentResultInfo OnlineExamResult { get; set; }

        public OnlineExamTopperListInfo[] TopperList { get; set; }

    }
}
