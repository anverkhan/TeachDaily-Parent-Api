using System;
using PassDailyParentsApi.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IAttendanceRepository
    {
        AttendanceReportInfoRoot AttendanceReportGet(int STUDENT_ID, int ACCADEMIC_ID);

        CarryingTypeRootInfo CarryingTypeList(int StudentId);

        CarryingListRootInfo CarryingDetailsList(int StudentId, int TypeId);
    }
}
