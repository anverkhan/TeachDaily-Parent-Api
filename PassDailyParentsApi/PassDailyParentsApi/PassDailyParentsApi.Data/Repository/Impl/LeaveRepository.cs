using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;
using PassDailyParentsApi.Data.Repository.Abstract;


namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class LeaveRepository : ILeaveRepository
    {
        public DbResultInfo LeaveRequest(LeaveRequestInfo leave)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[9];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, leave.ACCADEMIC_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, leave.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, leave.STUDENT_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, leave.STUDENT_ROLL_NUMBER);
                    parameters[4] = DataHelper.CreateSqlParameter("@LEAVE_SUBJECT", DbType.String, leave.LEAVE_SUBJECT);
                    parameters[5] = DataHelper.CreateSqlParameter("@LEAVE_DESCRIPTION", DbType.String, leave.LEAVE_DESCRIPTION);
                    parameters[6] = DataHelper.CreateSqlParameter("@LEAVE_FROM_DATE", DbType.DateTime, Convert.ToDateTime(leave.LEAVE_FROM_DATE));
                    parameters[7] = DataHelper.CreateSqlParameter("@LEAVE_TO_DATE", DbType.DateTime, Convert.ToDateTime(leave.LEAVE_TO_DATE));
                    parameters[8] = DataHelper.CreateSqlParameter("@SCHOOL_ID", DbType.Int32, leave.SCHOOL_ID);

                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_LEAVE_REQUEST_PARENT @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@STUDENT_ROLL_NUMBER,@LEAVE_SUBJECT,@LEAVE_DESCRIPTION,@LEAVE_FROM_DATE,@LEAVE_TO_DATE,@SCHOOL_ID", parameters);
                    return result.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public LeaveListInfoRoot LeaveList(LeaveFilterInfo leave)
        {
            LeaveListInfoRoot result = new LeaveListInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[7];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, leave.ACCADEMIC_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, leave.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, leave.STUDENT_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, leave.STUDENT_ROLL_NUMBER);
                    parameters[4] = DataHelper.CreateSqlParameter("@LEAVE_SUBMITTED_DATE", DbType.String, leave.LEAVE_SUBMITTED_DATE);
                    parameters[5] = DataHelper.CreateSqlParameter("@TODate", DbType.String, leave.TODate);
                    parameters[6] = DataHelper.CreateSqlParameter("@SCHOOL_ID", DbType.Int32, leave.SCHOOL_ID);

                    var LeaveDetailss = context.Database.SqlQuery<LeaveListInfo>("dbo.sms_LEAVE_REQUEST_PARENT_LIST @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@STUDENT_ROLL_NUMBER,@LEAVE_SUBMITTED_DATE,@TODate,@SCHOOL_ID", parameters);
                    result.LeaveDetails = LeaveDetailss.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DbResultInfo LeaveDelete(string Leave_Id)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@LEAVE_ID", DbType.Int32, System.Convert.ToInt32(Leave_Id));
                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_LEAVE_REQUEST_PARENT_DROP @LEAVE_ID", parameters);
                    return result.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public LeaveListInfoRoot LeaveListForEdit(string Leave_Id)
        {
            LeaveListInfoRoot result = new LeaveListInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@LEAVE_ID", DbType.Int32, System.Convert.ToInt32(Leave_Id));
                    var LeaveDetailss = context.Database.SqlQuery<LeaveListInfo>("dbo.sms_LEAVE_DETAILS_GET_BY_LEAVE_ID @LEAVE_ID", parameters);
                    result.LeaveDetails = LeaveDetailss.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DbResultInfo LeaveRequestUpdate(LeaveRequestInfo leave)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[10];
                    parameters[0] = DataHelper.CreateSqlParameter("@LEAVE_ID", DbType.Int32, leave.LEAVE_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, leave.ACCADEMIC_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, leave.CLASS_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, leave.STUDENT_ID);
                    parameters[4] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, leave.STUDENT_ROLL_NUMBER);
                    parameters[5] = DataHelper.CreateSqlParameter("@LEAVE_SUBJECT", DbType.String, leave.LEAVE_SUBJECT);
                    parameters[6] = DataHelper.CreateSqlParameter("@LEAVE_DESCRIPTION", DbType.String, leave.LEAVE_DESCRIPTION);
                    parameters[7] = DataHelper.CreateSqlParameter("@LEAVE_FROM_DATE", DbType.DateTime, Convert.ToDateTime(leave.LEAVE_FROM_DATE));
                    parameters[8] = DataHelper.CreateSqlParameter("@LEAVE_TO_DATE", DbType.DateTime, Convert.ToDateTime(leave.LEAVE_TO_DATE));
                    parameters[9] = DataHelper.CreateSqlParameter("@SCHOOL_ID", DbType.Int32, leave.SCHOOL_ID);

                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_LEAVE_DETAILS_SET_BY_LEAVE_ID @LEAVE_ID,@ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@STUDENT_ROLL_NUMBER,@LEAVE_SUBJECT,@LEAVE_DESCRIPTION,@LEAVE_FROM_DATE,@LEAVE_TO_DATE,@SCHOOL_ID", parameters);
                    return result.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }
    }
}
