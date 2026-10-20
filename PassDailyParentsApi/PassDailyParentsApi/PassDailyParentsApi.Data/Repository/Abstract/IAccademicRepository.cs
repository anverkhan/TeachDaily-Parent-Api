using System;
using PassDailyParentsApi.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IAccademicRepository
    {
        AccademicInfoRoot AccademicYearGet();

        HolidayRootInfo GetHolidayList(string StudentId, string Date);

        HolidayRootInfo GetHolidayListById(string StudentId, string AccademicId);

        ActivityInfoRoot GetActivityListById(string StudentId, string AccademicId);
    }
}
