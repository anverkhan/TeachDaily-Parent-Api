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
    public class ExamRepository : IExamRepository
    {
        public ExamNameInfoRoot ExamNameGet()
        {
            ExamNameInfoRoot result = new ExamNameInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    //SqlParameter[] parameters = new SqlParameter[1];
                    //parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    //var Exams = context.Database.SqlQuery<ExamNameInfo>("dbo.sms_EXAM_GETALL_DROPDOWN");
                    var Exams = context.Database.SqlQuery<ExamNameInfo>("dbo.sms_app_EXAM_GETALL_DROPDOWN_PARENT");
                    result.ExamDetails = Exams.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public ExamMarkDetailsInfoRoot ExamMarkDetailsGet(int AccademicId, int ClassId, int ExamId, int StudentRollNo, int StudentId)
        {
            ExamMarkDetailsInfoRoot result = new ExamMarkDetailsInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[5];
                    parameters[0] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    parameters[2] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, ExamId);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, StudentRollNo);
                    parameters[4] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    // var Marks = context.Database.SqlQuery<ExamMarkDetailsInfo>("dbo.sms_app_MARK_DETAILS_GET_ROLL_NUMBER_ICA @CLASS_ID,@ACCADEMIC_ID,@EXAM_ID,@STUDENT_ROLL_NUMBER", parameters);
                    //var Marks = context.Database.SqlQuery<ExamMarkDetailsInfo>("dbo.sms_app_MARK_DETAILS_GET_ROLL_NUMBER @CLASS_ID,@ACCADEMIC_ID,@EXAM_ID,@STUDENT_ROLL_NUMBER", parameters);
                    var Marks = context.Database.SqlQuery<ExamMarkDetailsInfo>("dbo.sms_app_MARK_DETAILS_GET_STUDENT_CBSE @CLASS_ID,@ACCADEMIC_ID,@EXAM_ID,@STUDENT_ROLL_NUMBER,@STUDENT_ID", parameters);
                    result.MarkDetails = Marks.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }


        public ExamMarkDetailsCEInfoRoot ExamMarkDetailsCEGet(int AccademicId, int ClassId, int ExamId, int StudentRollNo)
        {
            ExamMarkDetailsCEInfoRoot result = new ExamMarkDetailsCEInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];
                    parameters[0] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    parameters[2] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, ExamId);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ROLL_NUMBER", DbType.Int32, StudentRollNo);
                    var Marks = context.Database.SqlQuery<ExamMarkDetailsCEInfo>("dbo.sms_app_MARK_DETAILS_GET_ROLL_NUMBER_CON @CLASS_ID,@ACCADEMIC_ID,@EXAM_ID,@STUDENT_ROLL_NUMBER", parameters);
                    result.MarkDetails = Marks.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }


        public MarkInfoRoot TakeProgressReportType1(int AccademicId, int ClassId, int ExamId, int StudentId)
        {
            MarkInfoRoot result = new MarkInfoRoot();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];
                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    parameters[2] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, ExamId);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    var Mark = context.Database.SqlQuery<MarkInfo>("dbo.sms_app_TakeProgressReport_Type1 @ACCADEMIC_ID,@CLASS_ID,@EXAM_ID,@STUDENT_ID", parameters);
                    result.MarkDetails = Mark.ToArray();

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
