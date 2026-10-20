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
    public class ResultRepository : IResultRepository
    {
        public ResultInfoRoot AnnualResultGet(int STUDENT_ID, int ACCADEMIC_ID)
        {
            ResultInfoRoot result = new ResultInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, STUDENT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, ACCADEMIC_ID);
                    var AnnualRes = context.Database.SqlQuery<ResultInfo>("dbo.sms_app_ANNUAL_RESULT @STUDENT_ID,@ACCADEMIC_ID", parameters);
                    result.AnnualResult = AnnualRes.ToArray();

                    if(result.AnnualResult.Length>0)
                    {
                        if (result.AnnualResult[0].STUDENT_GENDER==0)
                        {
                            result.AnnualResult[0].STUDENT_GENDER = 1;
                        }
                        if (result.AnnualResult[0].STUDENT_GENDER == 1)
                        {
                            result.AnnualResult[0].STUDENT_GENDER = 0;
                        }
                    }
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
