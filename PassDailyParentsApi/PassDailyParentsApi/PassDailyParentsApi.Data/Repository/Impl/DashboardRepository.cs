using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using PassDailyParentsApi.Data.Repository.Abstract;

namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class DashboardRepository : IDashboardRepository
    {
        public DashboardInfo GetDashboardDetails(int studentId)
        {
            DashboardInfo result = new DashboardInfo();
            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_app_GET_PARENT_DASHBOARD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.AddParameter("@STUDENT_ID", DbType.Int32, studentId);
                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var academicdetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AcademicInfo>(reader);


                    result.AcademicDetails = academicdetails.FirstOrDefault();

                    // Move to second result set and read Tile Details 
                    reader.NextResult();

                    var tileDetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<DashboardTileInfo>(reader);

                    result.TileDetails = tileDetails.FirstOrDefault();

                    // Move to second result set and read Tile Details 
                    reader.NextResult();

                    var eventDetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<EventInfo>(reader);

                    result.EventDetails = eventDetails.ToArray();

                    // Move to second result set and read Tile Details 
                    reader.NextResult();

                    var inboxDetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AppInboxNewInfo>(reader);

                    result.InboxDetails = inboxDetails.ToArray();

                    // Move to second result set and read Tile Details 
                    reader.NextResult();

                    var videoDetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<VideoInfo>(reader);

                    result.VideoDetails = videoDetails.ToArray();

                    // Move to second result set and read Tile Details 
                    reader.NextResult();

                    var periodDetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<PeriodInfo>(reader);

                    result.PeriodDetails = periodDetails.ToArray();


                    // Move to second result set and read Tile Details 
                    reader.NextResult();

                    var subjectDetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<SubjectListInfo>(reader);

                    result.SubjectDetails = subjectDetails.ToArray();


                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public EventRootInfo EventListAll(string AccademicId, string ClassId, string StudentId)
        {
            EventRootInfo result = new EventRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.String, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.String, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.String, System.Convert.ToInt32(StudentId));
                    var Event = context.Database.SqlQuery<EventInfo>("dbo.sms_app_EVENT_DETAILS_LIST @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID", parameters);
                    result.EventList = Event.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo FromOldServer(int studentId)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.String, studentId);
                    var DbResult = context.Database.SqlQuery<DbResultInfo>("dbo.sms_OLD_SERVER_ENTRY_NEW @STUDENT_ID", parameters);
                    result = DbResult.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public StudentProfileInfo TakeProfile(int studentId)
        {
            StudentProfileInfo result = new StudentProfileInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.String, studentId);
                    var DbResult = context.Database.SqlQuery<StudentProfileInfo>("dbo.sms_app_Take_StudentProfile @STUDENT_ID", parameters);
                    result = DbResult.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

    }
}
