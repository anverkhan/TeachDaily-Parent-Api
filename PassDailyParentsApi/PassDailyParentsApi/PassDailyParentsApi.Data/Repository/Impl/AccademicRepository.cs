using System;
using PassDailyParentsApi.Data.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;
using System.Data;

namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class AccademicRepository : IAccademicRepository
    {
        public AccademicInfoRoot AccademicYearGet()
        {
            AccademicInfoRoot result = new AccademicInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    //SqlParameter[] parameters = new SqlParameter[2];
                    //parameters[0] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    var AccademicDetails = context.Database.SqlQuery<AccademicInfo>("dbo.sms_ACCADEMIC_YEARS_GETALL");
                    result.AccademicYears = AccademicDetails.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

        }

        public HolidayRootInfo GetHolidayList(string StudentId, string Date)
        {
            HolidayRootInfo result = new HolidayRootInfo();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@DATE", DbType.String, Date);
                    var Holiday = context.Database.SqlQuery<HolidayInfo>("dbo.sms_SELECT_HOLIDAY_BY_DATE @DATE", parameters);
                    result.HolidayList = Holiday.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public HolidayRootInfo GetHolidayListById(string StudentId, string AccademicId)
        {
            HolidayRootInfo result = new HolidayRootInfo();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    var Holiday = context.Database.SqlQuery<HolidayInfo>("dbo.sms_app_SELECT_HOLIDAY_BY_DATE @ACCADEMIC_ID", parameters);
                    result.HolidayList = Holiday.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }


        public ActivityInfoRoot GetActivityListById(string StudentId, string AccademicId)
        {
            ActivityInfoRoot result = new ActivityInfoRoot();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    var Activity = context.Database.SqlQuery<ActivityInfo>("dbo.sms_app_SELECT_ACTIVITY_BY_DATE @ACCADEMIC_ID", parameters);
                    result.ActivityList = Activity.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }


    }
}
