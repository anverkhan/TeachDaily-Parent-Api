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
    public class LibraryController : ApiController
    {
        private ILibraryRepository _libraryRepository;


        public LibraryController()
        {
            _libraryRepository = new LibraryRepository();


        }
        [HttpGet]
        public LibraryInfoRoot LibraryDetailsGet(int StudentId)
        {

            return _libraryRepository.LibraryDetailsGet(StudentId);

        }
    }
}
