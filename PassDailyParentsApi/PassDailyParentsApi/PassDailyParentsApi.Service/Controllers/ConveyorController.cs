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
    public class ConveyorController : ApiController
    {
        private IConveyorRepository _conveyorRepository;


        public ConveyorController()
        {
            _conveyorRepository = new ConveyorRepository();


        }

        [HttpGet]
        public ConveyorsInfoRoot ConveyorGet(int StudentId, int ClassId)
        {
           
                return _conveyorRepository.ConveyorGet(StudentId, ClassId);
            
        }


        [HttpPost]
        public DbResultInfo ConveyorCreate(ConveyorsInfo conv)
        {
            
                return _conveyorRepository.ConveyorCreate(conv);
           
        }
    }
}
