using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface ILeaveRepository
    {
        DbResultInfo LeaveRequest(LeaveRequestInfo leave);

        LeaveListInfoRoot LeaveList(LeaveFilterInfo leave);

        DbResultInfo LeaveDelete(string Leave_Id);

        LeaveListInfoRoot LeaveListForEdit(string Leave_Id);

        DbResultInfo LeaveRequestUpdate(LeaveRequestInfo leave);

    }
}
