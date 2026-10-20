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
    public class LibraryRepository : ILibraryRepository
    {
        public LibraryInfoRoot LibraryDetailsGet(int StudentId)
        {
            LibraryInfoRoot result = new LibraryInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    var Library = context.Database.SqlQuery<LibraryInfo>("dbo.sms_app_LIBRARY_DETAILS_FOR_PARENT @STUDENT_ID", parameters);
                    result.BookIssueDetails = Library.ToArray();
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
