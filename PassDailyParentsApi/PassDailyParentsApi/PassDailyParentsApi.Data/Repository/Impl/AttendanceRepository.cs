using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;
using PassDailyParentsApi.Data.Repository.Abstract;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;


namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public AttendanceReportInfoRoot AttendanceReportGet(int STUDENT_ID, int ACCADEMIC_ID)
        {
            AttendanceReportInfoRoot result = new AttendanceReportInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, STUDENT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, ACCADEMIC_ID);
                    var AttendanceDetails = context.Database.SqlQuery<AttendanceReportInfo>("dbo.sms_app_ATTENDANCE_REPORT @STUDENT_ID,@ACCADEMIC_ID", parameters);
                    result.AttendanceReport = AttendanceDetails.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }


        public CarryingTypeRootInfo CarryingTypeList(int StudentId)
        {
            CarryingTypeRootInfo result = new CarryingTypeRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    var CarryingTypes = context.Database.SqlQuery<CarryingTypeInfo>("dbo.sms_app_CARRYING_TYPE_LOAD @STUDENT_ID", parameters);
                    result.TypeList = CarryingTypes.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public CarryingListRootInfo CarryingDetailsList(int StudentId, int TypeId)
        {
            CarryingListRootInfo result = new CarryingListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    parameters[1] = DataHelper.CreateSqlParameter("@EL_TYPLE", DbType.Int32, TypeId);
                    var Carryingdetails = context.Database.SqlQuery<CarryingListInfo>("dbo.sms_STUDENT_LATE_COMING_CARRYING_LIST_PARENT @STUDENT_ID,@EL_TYPLE", parameters);
                    result.CarryingList = Carryingdetails.ToArray();
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
