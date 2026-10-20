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
    public class ParentAccountRepository : IParentAccountRepository
    {

        public ParentAccountInfo ParentAccountCreate(string MobileNumber, string SchoolCode)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_GUARDIAN_NUMBER", DbType.String, MobileNumber);
                    parameters[1] = DataHelper.CreateSqlParameter("@SCHOOL_CODE", DbType.String, SchoolCode);
                    var result = context.Database.SqlQuery<ParentAccountInfo>("dbo.sms_PARENT_ACCOUNT_DETAILS_NEW @STUDENT_GUARDIAN_NUMBER,@SCHOOL_CODE", parameters);
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
