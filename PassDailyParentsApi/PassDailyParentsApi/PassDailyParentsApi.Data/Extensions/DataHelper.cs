using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Extensions
{
    public static class DataHelper
    {
        public static void AddParameter(this DbCommand cmd, string parameterName, System.Data.DbType type, object value, ParameterDirection? parameterDirection = null)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = parameterName;
            param.DbType = type;
            param.Value = value ?? DBNull.Value;
            param.Direction = parameterDirection ?? ParameterDirection.Input;
            cmd.Parameters.Add(param);
        }

        public static SqlParameter CreateSqlParameter(string parameterName, System.Data.DbType type, object value, ParameterDirection? parameterDirection = null)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.DbType = type;
            param.Value = value;
            param.Direction = parameterDirection ?? ParameterDirection.Input;
            return param;
        }
    }
}
