using PassDailyParentsApi.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PassDailyParentsApi.Data.Model;
using PassDailyParentsApi.Data.Extensions;
using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class OnlineExamRepository : IOnlineExamRepository
    {
        public SubjectListRootInfo GetSubjectByClass(string ClassId, string StudentId)
        {
            SubjectListRootInfo result = new SubjectListRootInfo();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.String, System.Convert.ToInt32(ClassId));
                    parameters[1] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.String, System.Convert.ToInt32(StudentId));
                    var subj = context.Database.SqlQuery<SubjectListInfo>("dbo.sms_app_SUBJECT_DETAILS_GETALL_BY_STUDENT @CLASS_ID,@STUDENT_ID", parameters);
                    result.Subjects = subj.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public OnlineExamListRootInfo OnlineExamList(string AccademicId, string ClassId, string SubjectId, string StudentId)
        {
            OnlineExamListRootInfo result = new OnlineExamListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));                    
                    parameters[2] = DataHelper.CreateSqlParameter("@SUBJECT_ID", DbType.Int32, System.Convert.ToInt32(SubjectId));
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(SubjectId));

                    var online = context.Database.SqlQuery<OnlineExamListInfo>("dbo.sms_app_ONLINE_EXAM_DETAILS_LIST_PARENT @ACCADEMIC_ID,@CLASS_ID,@SUBJECT_ID,@STUDENT_ID", parameters);
                    result.OnlineExamList = online.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public OnlineExamListRootInfo OnlineExamDetailsById(string StudentId, string OexamId)
        {
            OnlineExamListRootInfo result = new OnlineExamListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[1] = DataHelper.CreateSqlParameter("@OEXAM_ID", DbType.Int32, System.Convert.ToInt32(OexamId));
                    
                    var online = context.Database.SqlQuery<OnlineExamListInfo>("dbo.sms_app_ONLINE_EXAM_STATUS_PARENT @STUDENT_ID,@OEXAM_ID", parameters);
                    result.OnlineExamList = online.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public OexamResultInfo OnlineExamStatusByStudent(string AccademicId, string ClassId, string StudentId, string OexamId)
        {
            OexamResultInfo result = new OexamResultInfo();
            
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[3] = DataHelper.CreateSqlParameter("@OEXAM_ID", DbType.Int32, System.Convert.ToInt32(OexamId));

                    var examstatus = context.Database.SqlQuery<OexamResultInfo>("dbo.sms_ONLINE_EXAM_ATTEND_STUDENT @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@OEXAM_ID", parameters);
                    result = examstatus.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public QuestionListRootInfo QuestionListForStart(string OexamId, string OexamAttemptId)
        {
            QuestionListRootInfo result = new QuestionListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@OEXAM_ID", DbType.Int32, System.Convert.ToInt32(OexamId));
                    parameters[1] = DataHelper.CreateSqlParameter("@OEXAM_ATTEMPT_ID", DbType.Int32, System.Convert.ToInt32(OexamAttemptId));

                    var Question = context.Database.SqlQuery<QuestionListInfo>("dbo.sms_ONLINE_EXAM_QUESTIONS_GET_BY_OEXAM_ID_STUDENT @OEXAM_ID,@OEXAM_ATTEMPT_ID", parameters);
                    result.QuestionList = Question.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public OptionAttemptRootInfo OptionsList(string QuestionId, string OexamAttemptId)
        {
            OptionAttemptRootInfo result = new OptionAttemptRootInfo();

            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_app_ONLINE_EXAM_OPTIONS_GET_BY_QUESTION_ID_STUDENT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.AddParameter("@OEXAM_ATTEMPT_ID", DbType.String, System.Convert.ToInt32(OexamAttemptId));
                cmd.AddParameter("@QUESTION_ID", DbType.String, System.Convert.ToInt32(QuestionId));
                
                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var Options = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<OptionsListInfo>(reader);


                    result.OptionList = Options.ToArray();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var SubmittedOption = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<OptionAttemptInfo>(reader);

                    result.AttemptedOption = SubmittedOption.ToArray();



                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }

        public DbResultInfo SubmitOption(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@OEXAM_ATTEMPT_ID", DbType.Int32, osi.OEXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@QUESTION_ID", DbType.Int32, osi.QUESTION_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@ANSWERED_OPTION_ID", DbType.Int32, osi.ANSWERED_OPTION_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, osi.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ONLINE_EXAM_SUBMIT_OPTION_BY_STUDENT @OEXAM_ATTEMPT_ID,@QUESTION_ID,@ANSWERED_OPTION_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo PauseExam(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@OEXAM_ATTEMPT_ID", DbType.Int32, osi.OEXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, osi.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ONLINE_EXAM_PAUSE_BY_STUDENT @OEXAM_ATTEMPT_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo FinishExam(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@OEXAM_ATTEMPT_ID", DbType.Int32, osi.OEXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, osi.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ONLINE_EXAM_FINISH_BY_STUDENT @OEXAM_ATTEMPT_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo DoAutoEnd(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@OEXAM_ID", DbType.Int32, osi.OEXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@OEXAM_ATTEMPT_ID", DbType.Int32, osi.OEXAM_ATTEMPT_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, osi.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ONLINE_EXAM_TIME_AUTO_ENDED @OEXAM_ID,@OEXAM_ATTEMPT_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo DeleteOption(OptionSubmitInfo osi)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@OEXAM_ATTEMPT_ID", DbType.Int32, osi.OEXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@QUESTION_ID", DbType.Int32, osi.QUESTION_ID);                    
                    parameters[2] = DataHelper.CreateSqlParameter("@ANSWERED_OPTION_ID", DbType.Int32, osi.ANSWERED_OPTION_ID);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ONLINE_EXAM_DELETE_OPTION_BY_STUDENT @OEXAM_ATTEMPT_ID,@QUESTION_ID,@ANSWERED_OPTION_ID", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public OnlineExamResultRootNewInfo OnlineExamResult(string AccademicId, string StudentId, string OexamId, string OexamAttemptId)
        {
            OnlineExamResultRootNewInfo result = new OnlineExamResultRootNewInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[2] = DataHelper.CreateSqlParameter("@OEXAM_ID", DbType.Int32, System.Convert.ToInt32(OexamId));
                    parameters[3] = DataHelper.CreateSqlParameter("@OEXAM_ATTEMPT_ID", DbType.Int32, System.Convert.ToInt32(OexamAttemptId));

                    var online = context.Database.SqlQuery<OnlineExamStudentResultInfo>("dbo.sms_app_ONLINE_EXAM_RESULT_DETAILS_STUDENT @ACCADEMIC_ID,@STUDENT_ID,@OEXAM_ID,@OEXAM_ATTEMPT_ID", parameters);
                    result.OnlineExamResult = online.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public ChapterRootInfo ChapterList(string AccademicId, string ClassId, string SubjectId)
        {
            ChapterRootInfo result = new ChapterRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@SUBJECT_ID", DbType.Int32, System.Convert.ToInt32(SubjectId));
                   

                    var Chapter = context.Database.SqlQuery<ChapterInfo>("dbo.sms_app_SUBJECT_CHAPTER_DETAILS_GETALL_BY_ACCADEMIC_CLASS_SUBJECT @ACCADEMIC_ID,@CLASS_ID,@SUBJECT_ID", parameters);
                    result.ChapterList = Chapter.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public YoutubeListRootInfo YoutubeList(string AccademicId, string ClassId, string SubjectId, string ChapterId)
        {
            YoutubeListRootInfo result = new YoutubeListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.String, AccademicId);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.String, ClassId);
                    parameters[2] = DataHelper.CreateSqlParameter("@SUBJECT_ID", DbType.String, SubjectId);
                    parameters[3] = DataHelper.CreateSqlParameter("@CHAPTER_ID", DbType.String, ChapterId);

                    var Youtube = context.Database.SqlQuery<YoutubeListInfo>("dbo.sms_app_YOUTUBE_VIDEO_DETAILS_LIST_PARENT @ACCADEMIC_ID,@CLASS_ID,@SUBJECT_ID,@CHAPTER_ID", parameters);
                    result.YoutubeList = Youtube.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public AssignmentListRootInfo AssignmentList(string AccademicId, string ClassId, string StudentId, string SubjectId)
        {
            AssignmentListRootInfo result = new AssignmentListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[3] = DataHelper.CreateSqlParameter("@SUBJECT_ID", DbType.Int32, System.Convert.ToInt32(SubjectId));
                    var online = context.Database.SqlQuery<AssignmentListInfo>("dbo.sms_app_ASSIGNMENT_DETAILS_LIST_PARENT @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@SUBJECT_ID", parameters);
                    result.AssignmentList = online.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public AssignmentStatusRootInfo AssignmentStatusByStudent(string AccademicId, string ClassId, string StudentId, string AssignmentId)
        {
            AssignmentStatusRootInfo result = new AssignmentStatusRootInfo();

            using (var context = new PassDailyDataModel()) 
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_ASSIGNMENT_DETAILS_GET_PARENT_FOR_SUBMIT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.AddParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                cmd.AddParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                cmd.AddParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                cmd.AddParameter("@ASSIGNMENT_ID", DbType.Int32, System.Convert.ToInt32(AssignmentId));

                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var Assignment = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AssignmentInfo>(reader);


                    result.AssignmentDetails = Assignment.FirstOrDefault();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var AssignmentStatus = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AssignmentSubmitInfo>(reader);

                    result.AssignmentStudentStatus = AssignmentStatus.FirstOrDefault();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var AssignmentFile = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AssignmentFileInfo>(reader);

                    result.AssignmentFileList = AssignmentFile.ToArray();



                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }


        public DbResultInfo AssignmentSubmit(AssignmentInsertInfo asm)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[6];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, asm.ACCADEMIC_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, asm.CLASS_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, asm.STUDENT_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@ASSIGNMENT_ID", DbType.Int32, asm.ASSIGNMENT_ID);
                    parameters[4] = DataHelper.CreateSqlParameter("@ASSIGNMENT_DETAILS", DbType.String, asm.ASSIGNMENT_DETAILS);
                    parameters[5] = DataHelper.CreateSqlParameter("@ASSIGNMENT_FILE", DbType.String, asm.ASSIGNMENT_FILE);
                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ASSIGNMENT_DETAILS_SUBMIT_STUDENT @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@ASSIGNMENT_ID,@ASSIGNMENT_DETAILS,@ASSIGNMENT_FILE", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public DbResultInfo AssignmentFileDelete(string AssignmentFileId)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@ASSIGNMENT_FILE_ID", DbType.Int32, System.Convert.ToInt32(AssignmentFileId));
                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ASSIGNMENT_FILE_DETAILS_DROP @ASSIGNMENT_FILE_ID", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public AssignmentStatusNewRootInfo AssignmentStatusByStudentNew(string AccademicId, string ClassId, string StudentId, string AssignmentId)
        {
            AssignmentStatusNewRootInfo result = new AssignmentStatusNewRootInfo();

            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_ASSIGNMENT_DETAILS_GET_PARENT_FOR_SUBMIT_V1";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.AddParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                cmd.AddParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                cmd.AddParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                cmd.AddParameter("@ASSIGNMENT_ID", DbType.Int32, System.Convert.ToInt32(AssignmentId));

                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var Assignment = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AssignmentInfo>(reader);


                    result.AssignmentDetails = Assignment.FirstOrDefault();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var AssignmentAttachmentStatus = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AssignmentAttachmentInfo>(reader);

                    result.AssignmentAttachmentList = AssignmentAttachmentStatus.ToArray();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var AssignmentStatus = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AssignmentSubmitInfo>(reader);

                    result.AssignmentStudentStatus = AssignmentStatus.FirstOrDefault();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var AssignmentFile = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<AssignmentFileInfo>(reader);

                    result.AssignmentFileList = AssignmentFile.ToArray();



                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }


        public DbResultInfo PlayLog(string AccademicId, string ClassId, string StudentId, string YoutubeId)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];
                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[3] = DataHelper.CreateSqlParameter("@YOUTUBE_ID", DbType.Int32, System.Convert.ToInt32(YoutubeId));

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_YOUTUBE_VIDEO_LOG_NEW @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@YOUTUBE_ID", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public BlockStatusRootInfo BlockStatus(string AccademicId, string StudentId)
        {
            BlockStatusRootInfo result = new BlockStatusRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    var block = context.Database.SqlQuery<BlockStatusInfo>("dbo.sms_YOUTUBE_STUDENT_BLOCK_STATUS_GET @ACCADEMIC_ID,@STUDENT_ID", parameters);
                    result.BlockDetails = block.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public OnlineExamListRootNewInfo OnlineExamResultNew(string AccademicId, string StudentId, string OexamId, string OexamAttemptId)
        {
            OnlineExamListRootNewInfo result = new OnlineExamListRootNewInfo();

            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_app_ONLINE_EXAM_RESULT_DETAILS_STUDENT_WITH_TOPPER_LIST";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.AddParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                cmd.AddParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                cmd.AddParameter("@OEXAM_ID", DbType.Int32, System.Convert.ToInt32(OexamId));
                cmd.AddParameter("@OEXAM_ATTEMPT_ID", DbType.Int32, System.Convert.ToInt32(OexamAttemptId));

                
                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var Online = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<OnlineExamStudentResultInfo>(reader);


                    result.OnlineExamResult = Online.FirstOrDefault();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var Topper = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<OnlineExamTopperListInfo>(reader);

                    result.TopperList = Topper.ToArray();

                   
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }


        public OnlineDExamListRootInfo OnlineDExamList(string AccademicId, string ClassId, string SubjectId, string StudentId)
        {
            OnlineDExamListRootInfo result = new OnlineDExamListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@SUBJECT_ID", DbType.String, SubjectId);
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));

                    var online = context.Database.SqlQuery<OnlineDExamListInfo>("dbo.sms_app_DESCRIPTIVE_EXAM_DETAILS_LIST_PARENT @ACCADEMIC_ID,@CLASS_ID,@SUBJECT_ID,@STUDENT_ID", parameters);
                    result.OnlineExamList = online.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public OnlineDExamListRootInfo OnlineDExamDetailsById(string StudentId, string ExamId)
        {
            OnlineDExamListRootInfo result = new OnlineDExamListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[1] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, System.Convert.ToInt32(ExamId));

                    var online = context.Database.SqlQuery<OnlineDExamListInfo>("dbo.sms_app_ONLINE_DESCRIPTIVE_EXAM_STATUS_PARENT @STUDENT_ID,@EXAM_ID", parameters);
                    result.OnlineExamList = online.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public DExamResultInfo OnlineDExamStatusByStudent(string AccademicId, string ClassId, string StudentId, string OexamId)
        {
            DExamResultInfo result = new DExamResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, System.Convert.ToInt32(OexamId));
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));                    

                    var examstatus = context.Database.SqlQuery<DExamResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_ATTEND_STUDENT @ACCADEMIC_ID,@CLASS_ID,@EXAM_ID,@STUDENT_ID", parameters);
                    result = examstatus.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public DQuestionListRootInfo DQuestionListForStart(string ExamId, string ExamAttemptId)
        {
            DQuestionListRootInfo result = new DQuestionListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, System.Convert.ToInt32(ExamId));
                    parameters[1] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, System.Convert.ToInt32(ExamAttemptId));

                    var Question = context.Database.SqlQuery<DQuestionListInfo>("dbo.sms_DESCRIPTIVE_EXAM_QUESTIONS_GET_BY_EXAM_ID_STUDENT @EXAM_ID,@EXAM_ATTEMPT_ID", parameters);
                    result.QuestionList = Question.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


        public DAnswerRootInfo TakeAnswer(string ExamId, string ExamAttemptId, string QuestionId)
        {
            DAnswerRootInfo result = new DAnswerRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, System.Convert.ToInt32(ExamId));
                    parameters[1] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, System.Convert.ToInt32(ExamAttemptId));
                    parameters[2] = DataHelper.CreateSqlParameter("@QUESTION_ID", DbType.Int32, System.Convert.ToInt32(QuestionId));

                    var Answerdb = context.Database.SqlQuery<DAnswerInfo>("dbo.sms_app_DESCRIPTIVE_EXAM_ANSWER_BY_QUESTION_ID_STUDENT @EXAM_ID,@EXAM_ATTEMPT_ID,@QUESTION_ID", parameters);
                    result.Answer = Answerdb.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo SubmitAnswer(AnswerSubmitInfo asi)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[7];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, asi.EXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@QUESTION_ID", DbType.Int32, asi.QUESTION_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, asi.ELAPSED_TIME);
                    parameters[3] = DataHelper.CreateSqlParameter("@ANSWER", DbType.String, asi.ANSWER);
                    parameters[4] = DataHelper.CreateSqlParameter("@ANSWER_FILE_1", DbType.String, asi.ANSWER_FILE_1);
                    parameters[5] = DataHelper.CreateSqlParameter("@ANSWER_FILE_2", DbType.String, asi.ANSWER_FILE_2);
                    parameters[6] = DataHelper.CreateSqlParameter("@ANSWER_FILE_3", DbType.String, asi.ANSWER_FILE_3);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_SUBMIT_ANSWER_BY_STUDENT @EXAM_ATTEMPT_ID,@QUESTION_ID,@ELAPSED_TIME,@ANSWER,@ANSWER_FILE_1,@ANSWER_FILE_2,@ANSWER_FILE_3", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo DeleteAnswer(DeleteAnswerInfo Dai)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, Dai.EXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@QUESTION_ID", DbType.Int32, Dai.QUESTION_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, Dai.ELAPSED_TIME);
                    
                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_DELETE_ANSWER_BY_STUDENT @EXAM_ATTEMPT_ID,@QUESTION_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo DeleteFile1(DeleteAnswerInfo Dai)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, Dai.EXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@QUESTION_ID", DbType.Int32, Dai.QUESTION_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, Dai.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_DELETE_ANSWER_FILE_1 @EXAM_ATTEMPT_ID,@QUESTION_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo DeleteFile2(DeleteAnswerInfo Dai)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, Dai.EXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@QUESTION_ID", DbType.Int32, Dai.QUESTION_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, Dai.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_DELETE_ANSWER_FILE_2 @EXAM_ATTEMPT_ID,@QUESTION_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo DeleteFile3(DeleteAnswerInfo Dai)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, Dai.EXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@QUESTION_ID", DbType.Int32, Dai.QUESTION_ID);
                    parameters[2] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, Dai.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_DELETE_ANSWER_FILE_3 @EXAM_ATTEMPT_ID,@QUESTION_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo PauseDExamCheck(DeleteAnswerInfo Dai)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, Dai.QUESTION_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, Dai.EXAM_ATTEMPT_ID);
                    
                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_PAUSE_CHECK_STUDENT @EXAM_ID,@EXAM_ATTEMPT_ID", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo PauseDExam(DeleteAnswerInfo Dai)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, Dai.EXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, Dai.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_PAUSE_BY_STUDENT @EXAM_ATTEMPT_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo FinishDExam(DeleteAnswerInfo Dai)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, Dai.EXAM_ATTEMPT_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, Dai.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_FINISH_BY_STUDENT @EXAM_ATTEMPT_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo DoAutoEndDExam(DeleteAnswerInfo Dai)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@EXAM_ID", DbType.Int32, Dai.EXAM_ID);
                    parameters[1] = DataHelper.CreateSqlParameter("@EXAM_ATTEMPT_ID", DbType.Int32, Dai.EXAM_ATTEMPT_ID);                    
                    parameters[2] = DataHelper.CreateSqlParameter("@ELAPSED_TIME", DbType.Int32, Dai.ELAPSED_TIME);

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_DESCRIPTIVE_EXAM_TIME_AUTO_ENDED @EXAM_ID,@EXAM_ATTEMPT_ID,@ELAPSED_TIME", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DExamResultRootInfo DOnlineExamResult(string AccademicId, string StudentId, string ExamId, string ExamAttemptId)
        {
            DExamResultRootInfo result = new DExamResultRootInfo();

            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_DESCRIPTIVE_EXAM_RESULT_DETAILS_STUDENT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.AddParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                cmd.AddParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                cmd.AddParameter("@EXAM_ID", DbType.Int32, System.Convert.ToInt32(ExamId));
                cmd.AddParameter("@EXAM_ATTEMPT_ID", DbType.Int32, System.Convert.ToInt32(ExamAttemptId));


                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var Online = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<DOnlineExamStudentResultInfo>(reader);


                    result.OnlineExamDetails = Online.FirstOrDefault();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var Dresult = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<DQuestionListInfo>(reader);

                    result.DOnlineExamResult = Dresult.ToArray();


                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }

        public ZoomMeetingRootInfo MeetingList(string AccademicId, string ClassId, string StudentId)
        {
            ZoomMeetingRootInfo result = new ZoomMeetingRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32,System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));                    

                    var results = context.Database.SqlQuery<ZoomMeetingInfo>("dbo.sms_ZOOM_MEETING_DETAILS_LIST_PARENT @ACCADEMIC_ID,@CLASS_ID", parameters);
                    result.ZoomMeetingList = results.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo MeetingLog(string ZMeetingId, string AccademicId, string ClassId, string StudentId)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@Z_MEETING_ID", DbType.Int32, System.Convert.ToInt32(ZMeetingId));
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[2] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ZOOM_MEETING_REPORT_NEW_PARENT @Z_MEETING_ID,@ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo DownloadLog(string AccademicId, string ClassId, string StudentId, string YoutubeId)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];
                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[3] = DataHelper.CreateSqlParameter("@YOUTUBE_ID", DbType.Int32, System.Convert.ToInt32(YoutubeId));

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_YOUTUBE_VIDEO_DOWNLOAD_LOG_NEW @ACCADEMIC_ID,@CLASS_ID,@STUDENT_ID,@YOUTUBE_ID", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public StartMeetingRootInfo LiveClassList(string AccademicId, string ClassId, string SubjectId, string StudentId, string SchoolId="1")
        {
            StartMeetingRootInfo result = new StartMeetingRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[5];

                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.Int32, System.Convert.ToInt32(ClassId));
                    parameters[2] = DataHelper.CreateSqlParameter("@SUBJECT_ID", DbType.Int32, System.Convert.ToInt32(SubjectId));
                    parameters[3] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[4] = DataHelper.CreateSqlParameter("@SCHOOL_ID", DbType.Int32, System.Convert.ToInt32(SchoolId));

                    var results = context.Database.SqlQuery<StartMeetingInfo>("dbo.sms_ZOOM_LIVE_CLASS_DETAILS_LIST_PARENT @ACCADEMIC_ID,@CLASS_ID,@SUBJECT_ID,@STUDENT_ID,@SCHOOL_ID", parameters);
                    result.LiveClassList = results.ToArray();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo MeetingAttend(string ZLiveClassId, string AccademicId, string StudentId, string ZoomMeetingStatus)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@Z_LIVE_CLASS_ID", DbType.Int32, System.Convert.ToInt32(ZLiveClassId));
                    //parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32("8"));
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[3] = DataHelper.CreateSqlParameter("@ZOOM_MEETING_STATUS", DbType.Int32, System.Convert.ToInt32(ZoomMeetingStatus));

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ZOOM_LIVE_CLASS_ATTEND_STUDENT @Z_LIVE_CLASS_ID,@ACCADEMIC_ID,@STUDENT_ID,@ZOOM_MEETING_STATUS", parameters);
                    result = results.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo MeetingStatusUpdate(string ZLiveClassId, string AccademicId, string StudentId, string ZoomMeetingStatus)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = DataHelper.CreateSqlParameter("@Z_LIVE_CLASS_ID", DbType.Int32, System.Convert.ToInt32(ZLiveClassId));
                    //parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32(AccademicId));
                    parameters[1] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, System.Convert.ToInt32("8"));
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_ID", DbType.Int32, System.Convert.ToInt32(StudentId));
                    parameters[3] = DataHelper.CreateSqlParameter("@ZOOM_MEETING_STATUS", DbType.Int32, System.Convert.ToInt32(ZoomMeetingStatus));

                    var results = context.Database.SqlQuery<DbResultInfo>("dbo.sms_ZOOM_LIVE_CLASS_ATTEND_MEETING_STATUS_UPDATE_STUDENT @Z_LIVE_CLASS_ID,@ACCADEMIC_ID,@STUDENT_ID,@ZOOM_MEETING_STATUS", parameters);
                    result = results.FirstOrDefault();
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
