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
    public class AlbumVideoController : ApiController
    {
        private IAlbumVideoRepository _albumvideoRepository;


        public AlbumVideoController()
        {
            _albumvideoRepository = new AlbumVideoRepository();


        }
        [HttpGet]
        public AlbumInfoRoot AlbumVideoGet(int AccademicId)
        {
            
                return _albumvideoRepository.AlbumVideoGet(AccademicId);
            
        }
        [HttpGet]
        public AlbumImageInfoRoot AlbumVideoFilesGet(int AlbumCategoryId)
        {
            
                return _albumvideoRepository.AlbumVideoFilesGet(AlbumCategoryId);
           
        }
    }
}
