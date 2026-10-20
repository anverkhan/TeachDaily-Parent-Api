using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;
using PassDailyParentsApi.Data.Repository.Abstract;
using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class StudyMaterialRepository :IStudyMaterialRepository
    {
        public StudyMaterialListInfoRoot StudyMaterialGet(int ClassId, int AccademicId)
        {
            StudyMaterialListInfoRoot result = new StudyMaterialListInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    var StudyMaterialDetails = context.Database.SqlQuery<StudyMaterialListInfo>("dbo.sms_STUDY_METERIAL_DETAILS_LIST_PARENT @CLASS_ID,@ACCADEMIC_ID", parameters);
                    result.StudyMaterials = StudyMaterialDetails.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DbResultInfo StudyMaterialDownload(string AccademicId, string ClassId, string StudentId, string StudyMeterialId)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];
                    parameters[0] = DataHelper.CreateSqlParameter("@STUDY_METERIAL_ID", DbType.Int32, System.Convert.ToInt32( StudyMeterialId));
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[2] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));

                    var result1 = context.Database.SqlQuery<DbResultInfo>("dbo.sms_STUDY_METERILAS_DOWNLOAD_REPORT_PARENT @STUDY_METERIAL_ID,@ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID", parameters);                    
                    result=result1.FirstOrDefault();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public StudyMaterialListInfoRoot StudyMaterialList(int AccademicId, int ClassId, int StudentId, int SubjectId)
        {
            StudyMaterialListInfoRoot result = new StudyMaterialListInfoRoot();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    parameters[3] = DataHelper.CreateSqlParameter("@SUBJECT_ID", DbType.Int32, SubjectId);

                    var StudyMaterialDetails = context.Database.SqlQuery<StudyMaterialListInfo>("dbo.sms_STUDY_METERIALS_V1_LIST_PARENT @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@SUBJECT_ID", parameters);

                    result.StudyMaterials = StudyMaterialDetails.ToArray();

                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }


        public FileListRootInfo FileList(int StudyMeterialId)
        {
            FileListRootInfo result = new FileListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_STUDY_METERIALS_V1_DETAILS_GET_METERIAL_ID";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.AddParameter("@STUDY_METERIAL_ID", DbType.Int32, StudyMeterialId);
                

                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var Materials = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<StudyMaterialListInfo>(reader);


                    result.StudyMaterialDetails = Materials.ToArray();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var Files = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<FileListInfo>(reader);

                    result.FilesDetails = Files.ToArray();



                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }

        public DbResultInfo FileDownloadLog(int AccademicId, int ClassId, int StudentId, int StudyMeterialId, int FileId)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[5];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, ClassId);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, StudentId);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDY_METERIAL_ID", DbType.Int32, StudyMeterialId);
                    parameters[4] = DataHelper.CreateSqlParameter("@FILE_ID", DbType.Int32, FileId);

                    var result1 = context.Database.SqlQuery<DbResultInfo>("dbo.sms_STUDY_METERIALS_V1_DOWNLOAD_REPORT_PARENT @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@STUDY_METERIAL_ID,@FILE_ID", parameters);
                    result = result1.FirstOrDefault();
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
