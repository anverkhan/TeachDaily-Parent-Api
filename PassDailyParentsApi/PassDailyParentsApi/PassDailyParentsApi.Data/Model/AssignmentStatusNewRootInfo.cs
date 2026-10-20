using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AssignmentStatusNewRootInfo
    {
        public AssignmentInfo AssignmentDetails { get; set; }
        public AssignmentAttachmentInfo[] AssignmentAttachmentList { get; set; }
        public AssignmentSubmitInfo AssignmentStudentStatus { get; set; }
        public AssignmentFileInfo[] AssignmentFileList { get; set; }
    }
}
