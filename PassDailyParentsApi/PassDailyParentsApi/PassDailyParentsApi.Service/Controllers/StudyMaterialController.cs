using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PassDailyParentsApi.Data.Model;
using PassDailyParentsApi.Data.Repository.Abstract;
using PassDailyParentsApi.Data.Repository.Impl;

namespace PassDailyParentsApi.Service.Controllers
{
    [RoutePrefix("PassDailyParentsApi/StudyMaterial")]
    public class StudyMaterialController : ApiController
    {
        private IStudyMaterialRepository _studymaterialRepository;


        public StudyMaterialController()
        {
            _studymaterialRepository = new StudyMaterialRepository();


        }
        [HttpGet]
        [Route("StudyMaterialGet")]
        public StudyMaterialListInfoRoot StudyMaterialGet(int ClassId, int AccademicId)
        {
            
                return _studymaterialRepository.StudyMaterialGet(ClassId, AccademicId);
            
        }

        [HttpGet]
        [Route("StudyMaterialDownload")]
        public DbResultInfo StudyMaterialDownload(string AccademicId, string ClassId, string StudentId, string StudyMeterialId)
        {

            return _studymaterialRepository.StudyMaterialDownload(AccademicId, ClassId, StudentId, StudyMeterialId);

        }

        [HttpGet]
        [Route("StudyMaterialList")]
        public StudyMaterialListInfoRoot StudyMaterialList(int AccademicId, int ClassId, int StudentId, int SubjectId)
        {

            return _studymaterialRepository.StudyMaterialList(AccademicId, ClassId, StudentId, SubjectId);

        }

        [HttpGet]
        [Route("FileList")]
        public FileListRootInfo FileList(int StudyMeterialId)
        {

            return _studymaterialRepository.FileList(StudyMeterialId);

        }

        [HttpGet]
        [Route("FileDownloadLog")]
        public DbResultInfo FileDownloadLog(int AccademicId, int ClassId, int StudentId, int StudyMeterialId, int FileId)
        {

            return _studymaterialRepository.FileDownloadLog(AccademicId, ClassId, StudentId, StudyMeterialId, FileId);

        }



    }
}
