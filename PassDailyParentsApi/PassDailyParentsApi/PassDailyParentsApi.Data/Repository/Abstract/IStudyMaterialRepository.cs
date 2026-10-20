using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IStudyMaterialRepository
    {
        StudyMaterialListInfoRoot StudyMaterialGet(int ClassId, int AccademicId);

        DbResultInfo StudyMaterialDownload(string AccademicId,string ClassId,string StudentId,string StudyMeterialId );

        StudyMaterialListInfoRoot StudyMaterialList(int AccademicId, int ClassId, int StudentId, int SubjectId);

        FileListRootInfo FileList(int StudyMeterialId);

        DbResultInfo FileDownloadLog(int AccademicId, int ClassId, int StudentId, int StudyMeterialId,int FileId);
    }
}
