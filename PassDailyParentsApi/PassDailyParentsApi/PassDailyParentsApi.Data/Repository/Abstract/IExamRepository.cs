using System;
using PassDailyParentsApi.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IExamRepository
    {
        ExamNameInfoRoot ExamNameGet();
        ExamMarkDetailsInfoRoot ExamMarkDetailsGet(int AccademicId, int ClassId,int ExamId, int StudentRollNo, int StudentId);

        ExamMarkDetailsCEInfoRoot ExamMarkDetailsCEGet(int AccademicId, int ClassId, int ExamId, int StudentRollNo);

        MarkInfoRoot TakeProgressReportType1(int AccademicId, int ClassId, int ExamId, int StudentId);
    }
}
