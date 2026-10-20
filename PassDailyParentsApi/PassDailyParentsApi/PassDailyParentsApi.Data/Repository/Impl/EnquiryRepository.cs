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
    public class EnquiryRepository : IEnquiryRepository
    {
         
        public DbResultInfo EnquiryRequest(EnquiryRequestInfo enq)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[7];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, enq.ACCADEMIC_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, enq.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, enq.STUDENT_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, enq.STUDENT_ROLL_NUMBER);
                    parameters[4] = DataHelper.CreateSqlParameter("@QUERY_SUBJECT", DbType.String, enq.QUERY_SUBJECT);
                    parameters[5] = DataHelper.CreateSqlParameter("@QUERY_DESCRIPTION", DbType.String, enq.QUERY_DESCRIPTION);
                    parameters[6] = DataHelper.CreateSqlParameter("@SCHOOL_ID", DbType.Int32, enq.SCHOOL_ID);

                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_QUERY_DETAILS_NEW_PARENT @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@STUDENT_ROLL_NUMBER,@QUERY_SUBJECT,@QUERY_DESCRIPTION,@SCHOOL_ID", parameters);
                    return result.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DbResultInfo EnquiryDelete(string Enquiry_Id)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@QUERY_ID", DbType.Int32, System.Convert.ToInt32(Enquiry_Id));
                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_QUERY_DETAILS_PARENT_DROP @QUERY_ID", parameters);
                    return result.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public EnquiryListInfoRoot EnquiryList(EnquiryFilterInfo enq)
        {
            EnquiryListInfoRoot result = new EnquiryListInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[6];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, enq.ACCADEMIC_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, enq.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, enq.STUDENT_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, enq.STUDENT_ROLL_NUMBER);
                    parameters[4] = DataHelper.CreateSqlParameter("@QUERY_SUBMITTED_DATE", DbType.String, enq.QUERY_SUBMITTED_DATE);
                    parameters[5] = DataHelper.CreateSqlParameter("@SCHOOL_ID", DbType.Int32, enq.SCHOOL_ID);

                    var EnquiryDetails = context.Database.SqlQuery<EnquiryListInfo>("dbo.sms_QUERY_DETAILS_PARENT_LIST @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@STUDENT_ROLL_NUMBER,@QUERY_SUBMITTED_DATE,@SCHOOL_ID", parameters);
                    result.EnquiryList = EnquiryDetails.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public EnquiryListInfoRoot EnquiryListForEdit(string Enquiry_Id)
        {
            EnquiryListInfoRoot result = new EnquiryListInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@QUERY_ID", DbType.Int32, System.Convert.ToInt32(Enquiry_Id));
                    var EnquiryDetails = context.Database.SqlQuery<EnquiryListInfo>("dbo.sms_QUERY_DETAILS_GET_BY_QUERY_ID @QUERY_ID", parameters);
                    result.EnquiryList = EnquiryDetails.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DbResultInfo EnquiryRequestUpdate(EnquiryRequestInfo enq)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[8];
                    parameters[0] = DataHelper.CreateSqlParameter("@QUERY_ID", DbType.Int32, enq.QUERY_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, enq.ACCADEMIC_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, enq.CLASS_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, enq.STUDENT_ID);
                    parameters[4] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, enq.STUDENT_ROLL_NUMBER);
                    parameters[5] = DataHelper.CreateSqlParameter("@QUERY_SUBJECT", DbType.String, enq.QUERY_SUBJECT);
                    parameters[6] = DataHelper.CreateSqlParameter("@QUERY_DESCRIPTION", DbType.String, enq.QUERY_DESCRIPTION);
                    parameters[7] = DataHelper.CreateSqlParameter("@SCHOOL_ID", DbType.Int32, enq.SCHOOL_ID);

                    var result = context.Database.SqlQuery<DbResultInfo>("dbo.sms_QUERY_DETAILS_SET_BY_QUERY_ID @QUERY_ID,@ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@STUDENT_ROLL_NUMBER,@QUERY_SUBJECT,@QUERY_DESCRIPTION,@SCHOOL_ID", parameters);
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
