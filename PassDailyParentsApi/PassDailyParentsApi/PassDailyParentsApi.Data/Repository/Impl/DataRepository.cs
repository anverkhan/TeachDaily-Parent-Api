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
    public class DataRepository:IDataRepository
    {

        public string DataRequest(string datavalue1, string datavalue2)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@DATA_VALUE1", DbType.String, datavalue1);
                    parameters[1] = DataHelper.CreateSqlParameter("@DATA_VALUE2", DbType.String, datavalue2);

                    var result = context.Database.SqlQuery<string>("dbo.sms_DATA_DETAILS_NEW @DATA_VALUE1,@DATA_VALUE2", parameters);
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
