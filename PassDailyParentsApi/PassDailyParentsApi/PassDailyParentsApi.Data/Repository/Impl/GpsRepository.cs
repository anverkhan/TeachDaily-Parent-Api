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
    public class GpsRepository : IGpsRepository
    {
        public GpsRootInfo GetLocation(string VehichleId, string TerminalId, string SimNumber)
        {
            GpsRootInfo result = new GpsRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@VEHICHLE_ID", DbType.Int32, System.Convert.ToInt32(VehichleId));
                    parameters[1] = DataHelper.CreateSqlParameter("@TERMINAL_ID", DbType.String, TerminalId);
                    parameters[2] = DataHelper.CreateSqlParameter("@SIM_NUMBER", DbType.String, SimNumber);
                    var cls = context.Database.SqlQuery<GpsInfo>("dbo.sms_app_GET_GPS_LOCATION @VEHICHLE_ID,@TERMINAL_ID,@SIM_NUMBER", parameters);
                    result.GpsLocation = cls.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }

            }
            return result;
        }


        public GpsVehichleRootInfo GetAllVehichles(string Dummy)
        {
            GpsVehichleRootInfo result = new GpsVehichleRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@VEHICLE_NAME", DbType.String, string.Empty);
                    parameters[1] = DataHelper.CreateSqlParameter("@VEHICLE_REG_NO", DbType.String, string.Empty);
                    parameters[2] = DataHelper.CreateSqlParameter("@SIM_NUMBER", DbType.String, string.Empty);
                    parameters[3] = DataHelper.CreateSqlParameter("@VEHICLE_STATUS", DbType.String, "-1");
                    var vehichle = context.Database.SqlQuery<GpsVehichleInfo>("dbo.sms_GPS_VEHICLE_DETAILS_GET_ALL_LIST @VEHICLE_NAME,@VEHICLE_REG_NO,@SIM_NUMBER,@VEHICLE_STATUS", parameters);
                    result.Vehichles = vehichle.ToArray();
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
