using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IDashboardRepository
    {
        DashboardInfo GetDashboardDetails(int studentId);

        EventRootInfo EventListAll(string AccademicId, string ClassId, string StudentId);

        DbResultInfo FromOldServer(int studentId);

        StudentProfileInfo TakeProfile(int studentId);
    }
}
