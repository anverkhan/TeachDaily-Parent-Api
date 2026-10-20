using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class DExamResultRootInfo
    {
        public DOnlineExamStudentResultInfo OnlineExamDetails { get; set; }

        public DQuestionListInfo[] DOnlineExamResult { get; set; }
    }

}
