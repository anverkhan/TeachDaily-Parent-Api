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
    public class ConveyorRepository : IConveyorRepository
    {
        public ConveyorsInfoRoot ConveyorGet(int StudentId, int ClassId)
        {
            ConveyorsInfoRoot result = new ConveyorsInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    var conv = context.Database.SqlQuery<ConveyorsInfo>("dbo.sms_CONVEYORS_DETAILS_GET @STUDENT_ID,@CLASS_ID", parameters);
                    result.Conveyor = conv.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DbResultInfo ConveyorUpdate(ConveyorsInfo conv)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[6];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, conv.STUDENT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, conv.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@CONVEYORS_NAME", DbType.String, conv.CONVEYORS_NAME);
                    parameters[3] = DataHelper.CreateSqlParameter("@CONVEYORS_MOBILE", DbType.String, conv.CONVEYORS_MOBILE);
                    parameters[4] = DataHelper.CreateSqlParameter("@CONVEYORS_VEHICLE_NO", DbType.String, conv.CONVEYORS_VEHICLE_NO);
                    parameters[5] = DataHelper.CreateSqlParameter("@CONVEYORS_ADDRESS", DbType.String, conv.CONVEYORS_ADDRESS);
                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_CONVEYORS_DETAILS_SET @STUDENT_ID,@CLASS_ID,@CONVEYORS_NAME,@CONVEYORS_MOBILE,@CONVEYORS_VEHICLE_NO,@CONVEYORS_ADDRESS", parameters);
                    return result.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DbResultInfo ConveyorCreate(ConveyorsInfo conv)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[6];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, conv.STUDENT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, conv.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@CONVEYORS_NAME", DbType.String, conv.CONVEYORS_NAME);
                    parameters[3] = DataHelper.CreateSqlParameter("@CONVEYORS_MOBILE", DbType.String, conv.CONVEYORS_MOBILE);
                    parameters[4] = DataHelper.CreateSqlParameter("@CONVEYORS_VEHICLE_NO", DbType.String, conv.CONVEYORS_VEHICLE_NO);
                    parameters[5] = DataHelper.CreateSqlParameter("@CONVEYORS_ADDRESS", DbType.String, conv.CONVEYORS_ADDRESS);
                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_CONVEYORS_DETAILS_NEW @STUDENT_ID,@CLASS_ID,@CONVEYORS_NAME,@CONVEYORS_MOBILE,@CONVEYORS_VEHICLE_NO,@CONVEYORS_ADDRESS", parameters);
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
