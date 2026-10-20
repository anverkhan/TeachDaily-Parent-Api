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
    public class FeesRepository : IFeesRepository
    {
        public FeesPaidInfoRoot FeesPaidListGet(int ClassId, int AccademicId, int StudentId, int StudentRollNo)
        {
            FeesPaidInfoRoot result = new FeesPaidInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];
                    parameters[0] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, StudentRollNo);
                    var Fees = context.Database.SqlQuery<FeesPaidInfo>("dbo.sms_app_FEES_PAID_LIST_PARENT @CLASS_ID,@ACCADEMIC_ID,@STUDENT_ID,@STUDENT_ROLL_NUMBER", parameters);
                    result.FeesPaidDetails = Fees.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public TermFeeReceiptRoot1 FeesPaidListGetV1(int StudentId, int ReceiptId)
        {
            TermFeeReceiptRoot1 result = new TermFeeReceiptRoot1();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = DataHelper.CreateSqlParameter("@StudentId", DbType.Int32, StudentId);
                    parameters[1] = DataHelper.CreateSqlParameter("@ReceiptId", DbType.Int32, ReceiptId);
                    var Fees = context.Database.SqlQuery<TermFeePaidDetails>("dbo.sms_react_TermFee_ReceiptDetails_Print_Parent @StudentId,@ReceiptId", parameters);
                    result.TermfeepaidList = Fees.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public TermFeeReceiptRoot FeesPaidListGetNew(int StudentId, int ReceiptId)
        {
            TermFeeReceiptRoot result = new TermFeeReceiptRoot();

            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_react_TermFee_ReceiptDetails_Print_ParentV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.AddParameter("@StudentId", DbType.Int32, StudentId);
                cmd.AddParameter("@ReceiptId", DbType.Int32, ReceiptId);

                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var Details = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<TermFeeReceiptDetail>(reader);


                    result.ReceiptDetail = Details.FirstOrDefault();

                    // Move to second result set and read Tile Details 
                    reader.NextResult();

                    var TermDetails = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<TermFeePaidDetails>(reader);

                    result.TermfeepaidList = TermDetails.ToArray();

                    // Move to second result set and read Tile Details 
                    reader.NextResult();

                    var PaymentMode = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<PaymentModePaid>(reader);

                    result.PaymentmodeList = PaymentMode.ToArray();



                }

                catch(Exception ee)
                {

                    string error = ee.Message.ToString();

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
