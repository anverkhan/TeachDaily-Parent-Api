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
    public class NoticeBoardController : ApiController
    {
        private INoticeBoardRepository _noticeboardRepository;
       
       
        public NoticeBoardController()
        {
            _noticeboardRepository = new NoticeBoardRepository();
           
           
        }
        [HttpGet]
        public NoticeBoardListInfoRoot NoticeBoardGet(string NoticeId)
        {
            
                return _noticeboardRepository.NoticeBoardGet();
            
        }

        [HttpGet]
        public NoticeBoardListInfoRoot NoticeBoardGetById(int UpdatesId)
        {

            return _noticeboardRepository.NoticeBoardGetById(UpdatesId);

        }

        
        

    }
}
