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
    public class AlbumImageController : ApiController
    {
        private IAlbumImageRepository _albumimageRepository;


        public AlbumImageController()
        {
            _albumimageRepository = new AlbumImageRepository();


        }
        [HttpGet]
        public AlbumInfoRoot AlbumImageGet(int AccademicId)
        {
            
                return _albumimageRepository.AlbumImageGet(AccademicId);
           
        }
        [HttpGet]
        public AlbumImageInfoRoot AlbumImageFilesGet(int AlbumCategoryId)
        {
            
                return _albumimageRepository.AlbumImageFilesGet(AlbumCategoryId);
           
        }
    }
}
