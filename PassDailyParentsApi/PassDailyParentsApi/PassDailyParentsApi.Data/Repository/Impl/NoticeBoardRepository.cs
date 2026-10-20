using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Repository.Abstract;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;


namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class NoticeBoardRepository :INoticeBoardRepository
    {
        public NoticeBoardListInfoRoot NoticeBoardGet()
        {
            NoticeBoardListInfoRoot result = new NoticeBoardListInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@UPDATES_ID", DbType.Int32, 0);
                    var Notice = context.Database.SqlQuery<NoticeBoardListInfo>("dbo.sms_app_NOTICE_BOARD_GETALL @UPDATES_ID", parameters);
                    result.NoticeBoardDetails = Notice.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public NoticeBoardListInfoRoot NoticeBoardGetById(int UpdatesId)
        {
            NoticeBoardListInfoRoot result = new NoticeBoardListInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@UPDATES_ID", DbType.Int32, UpdatesId);
                    var Notice = context.Database.SqlQuery<NoticeBoardListInfo>("dbo.sms_app_NOTICE_BOARD_GET_BY_ID @UPDATES_ID", parameters);
                    result.NoticeBoardDetails = Notice.ToArray();
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
