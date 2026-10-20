using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Repository.Abstract;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;


namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class MessageRepository : IMessageRepository
    {
        public MessageInfo[] GetMessageDetails(string title, string date, string status)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@MESSAGE_TITLE", DbType.String, title);
                    parameters[1] = DataHelper.CreateSqlParameter("@MESSAGE_DATE", DbType.String, date);
                    parameters[2] = DataHelper.CreateSqlParameter("@MESSAGE_STATUS", DbType.String, status);

                    var result = context.Database.SqlQuery<MessageInfo>("dbo.sms_MESSAGE_DETAILS_GETALL_LIST @MESSAGE_TITLE,@MESSAGE_DATE,@MESSAGE_STATUS", parameters);
                    return result.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }
    }
}
