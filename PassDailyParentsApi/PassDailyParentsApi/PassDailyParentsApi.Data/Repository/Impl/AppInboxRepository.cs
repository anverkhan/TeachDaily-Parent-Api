using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;
using PassDailyParentsApi.Data.Repository.Abstract;
using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class AppInboxRepository : IAppInboxRepository
    {

        public AppInboxInfoRoot AppInboxGet(AppInboxRequestInfo inbox)
        {
            AppInboxInfoRoot result = new AppInboxInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[5];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, inbox.ACCADEMIC_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, inbox.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, inbox.STUDENT_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@VIRTUAL_MAIL_SENT_DATE", DbType.String, inbox.VIRTUAL_MAIL_SENT_DATE);
                    parameters[4] = DataHelper.CreateSqlParameter("@TODate", DbType.String, inbox.TODate);
                    var Inbox = context.Database.SqlQuery<AppInboxInfo>("dbo.sms_app_VIRTUAL_MAIL_PARENT_LIST @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@VIRTUAL_MAIL_SENT_DATE,@TODate", parameters);
                    result.InboxDetails = Inbox.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public AppInboxInfoRoot AppInboxGetById(string Inbox_Id)
        {
            AppInboxInfoRoot result = new AppInboxInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@VIRTUAL_MAIL_SENT_ID", DbType.Int32, System.Convert.ToInt32(Inbox_Id));
                    var Inbox = context.Database.SqlQuery<AppInboxInfo>("dbo.sms_VIRTUAL_MAIL_SENT_DETAILS_VIEW_PARENT @VIRTUAL_MAIL_SENT_ID", parameters);
                    result.InboxDetails = Inbox.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DbResultInfo AppInboxReadById(string StudentId, string InboxId)
        {
            
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = DataHelper.CreateSqlParameter("@VIRTUAL_MAIL_SENT_ID", DbType.Int32, System.Convert.ToInt32(InboxId));
                    parameters[1] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_VIRTUAL_MAIL_SENT_PARENT_READ_STATUS @VIRTUAL_MAIL_SENT_ID,@STUDENT_ID", parameters);
                    return result.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public AppInboxInfoRootNew AppInboxGetNew(AppInboxRequestInfo inbox)
        {
            AppInboxInfoRootNew result = new AppInboxInfoRootNew();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[5];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, inbox.ACCADEMIC_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, inbox.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, inbox.STUDENT_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@VIRTUAL_MAIL_SENT_DATE", DbType.String, inbox.VIRTUAL_MAIL_SENT_DATE);
                    parameters[4] = DataHelper.CreateSqlParameter("@TODate", DbType.String, inbox.TODate);
                    var Inbox = context.Database.SqlQuery<AppInboxInfoNew>("dbo.sms_app_VIRTUAL_MAIL_PARENT_LIST_NEW @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@VIRTUAL_MAIL_SENT_DATE,@TODate", parameters);
                    result.InboxDetails = Inbox.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public AppInboxInfoNewRoot AppInboxGetByIdNew(string Inbox_Id,string StudentId)
        {
            AppInboxInfoNewRoot result = new AppInboxInfoNewRoot();

            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_app_VIRTUAL_MAIL_SENT_DETAILS_VIEW_PARENT_NEW";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.AddParameter("@VIRTUAL_MAIL_SENT_STUDENT_ID", DbType.Int32, System.Convert.ToInt32(Inbox_Id));
                cmd.AddParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));


                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var InboxDetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AppInboxInfo>(reader);


                    result.InboxDetails = InboxDetails.FirstOrDefault();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var Files = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<InboxFileDetailsInfo>(reader);

                    result.FileDetails = Files.ToArray();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var ReplyFiles = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<InboxReplyFileDetailsInfo>(reader);

                    result.ReplyFileDetails = ReplyFiles.ToArray();


                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }


        public ResultNewInfo SubmitReply(InboxReplyInfo inbox)
        {
            ResultNewInfo result = new ResultNewInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@VIRTUAL_MAIL_SENT_STUDENT_ID", DbType.Int32, inbox.VIRTUAL_MAIL_SENT_STUDENT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@VIRTUAL_MAIL_REPLY", DbType.String, inbox.VIRTUAL_MAIL_REPLY);
                    parameters[2] = DataHelper.CreateSqlParameter("@VIRTUAL_MAIL_REPLY_FILE", DbType.String, inbox.VIRTUAL_MAIL_REPLY_FILE);

                    var Inbox = context.Database.SqlQuery<ResultNewInfo>("dbo.sms_app_VIRTUALMAIL_SUBMIT_REPLY @VIRTUAL_MAIL_SENT_STUDENT_ID,@VIRTUAL_MAIL_REPLY,@VIRTUAL_MAIL_REPLY_FILE", parameters);
                    result = Inbox.FirstOrDefault();
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
