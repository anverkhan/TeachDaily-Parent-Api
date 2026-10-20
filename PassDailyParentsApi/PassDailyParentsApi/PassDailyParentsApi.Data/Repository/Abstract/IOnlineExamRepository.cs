using PassDailyParentsApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IOnlineExamRepository
    {
        SubjectListRootInfo GetSubjectByClass(string ClassId, string StudentId);

        OnlineExamListRootInfo OnlineExamList(string AccademicId, string ClassId, string SubjectId, string StudentId);

        OnlineExamListRootInfo OnlineExamDetailsById(string StudentId, string OexamId);

        OexamResultInfo OnlineExamStatusByStudent(string AccademicId, string ClassId, string StudentId, string OexamId);

        QuestionListRootInfo QuestionListForStart(string OexamId, string OexamAttemptId);

        OptionAttemptRootInfo OptionsList(string QuestionId, string OexamAttemptId);

        DbResultInfo SubmitOption(OptionSubmitInfo osi);

        DbResultInfo PauseExam(OptionSubmitInfo osi);

        DbResultInfo FinishExam(OptionSubmitInfo osi);

        DbResultInfo DoAutoEnd(OptionSubmitInfo osi);

        DbResultInfo DeleteOption(OptionSubmitInfo osi);

        OnlineExamResultRootNewInfo OnlineExamResult(string AccademicId, string StudentId, string OexamId, string OexamAttemptId);

        ChapterRootInfo ChapterList(string AccademicId, string ClassId, string SubjectId);

        YoutubeListRootInfo YoutubeList(string AccademicId, string ClassId, string SubjectId, string ChapterId);

        AssignmentListRootInfo AssignmentList(string AccademicId, string ClassId, string StudentId, string SubjectId);

        AssignmentStatusRootInfo AssignmentStatusByStudent(string AccademicId, string ClassId, string StudentId, string AssignmentId);

        DbResultInfo AssignmentSubmit(AssignmentInsertInfo asm);

        DbResultInfo AssignmentFileDelete(string AssignmentFileId);

        AssignmentStatusNewRootInfo AssignmentStatusByStudentNew(string AccademicId, string ClassId, string StudentId, string AssignmentId);

        DbResultInfo PlayLog(string AccademicId, string ClassId, string StudentId, string YoutubeId);

        BlockStatusRootInfo BlockStatus(string AccademicId, string StudentId);

        OnlineExamListRootNewInfo OnlineExamResultNew(string AccademicId, string StudentId, string OexamId, string OexamAttemptId);

        OnlineDExamListRootInfo OnlineDExamList(string AccademicId, string ClassId, string SubjectId, string StudentId);

        OnlineDExamListRootInfo OnlineDExamDetailsById(string StudentId, string ExamId);

        DExamResultInfo OnlineDExamStatusByStudent(string AccademicId, string ClassId, string StudentId, string ExamId);

        DQuestionListRootInfo DQuestionListForStart(string ExamId, string ExamAttemptId);

        DAnswerRootInfo TakeAnswer(string ExamId, string ExamAttemptId, string QuestionId);

        DbResultInfo SubmitAnswer(AnswerSubmitInfo asi);

        DbResultInfo DeleteAnswer(DeleteAnswerInfo Dai);

        DbResultInfo DeleteFile1(DeleteAnswerInfo Dai);

        DbResultInfo DeleteFile2(DeleteAnswerInfo Dai);

        DbResultInfo DeleteFile3(DeleteAnswerInfo Dai);

        DbResultInfo PauseDExamCheck(DeleteAnswerInfo Dai);

        DbResultInfo PauseDExam(DeleteAnswerInfo Dai);

        DbResultInfo FinishDExam(DeleteAnswerInfo Dai);

        DbResultInfo DoAutoEndDExam(DeleteAnswerInfo Dai);

        DExamResultRootInfo DOnlineExamResult(string AccademicId, string StudentId, string ExamId, string ExamAttemptId);

        ZoomMeetingRootInfo MeetingList(string AccademicId, string ClassId,string StudentId);

        DbResultInfo MeetingLog(string ZMeetingId,string AccademicId, string ClassId, string StudentId);

        DbResultInfo DownloadLog(string AccademicId, string ClassId, string StudentId, string YoutubeId);

        StartMeetingRootInfo LiveClassList(string AccademicId, string ClassId, string SubjectId, string StudentId, string SchoolId);

        DbResultInfo MeetingAttend(string ZLiveClassId, string AccademicId, string StudentId, string ZoomMeetingStatus);
        DbResultInfo MeetingStatusUpdate(string ZLiveClassId, string AccademicId, string StudentId, string ZoomMeetingStatus);



    }
}
