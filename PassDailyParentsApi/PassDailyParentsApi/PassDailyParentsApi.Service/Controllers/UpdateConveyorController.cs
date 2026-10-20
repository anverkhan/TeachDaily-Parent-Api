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
    public class UpdateConveyorController : ApiController
    {
        private IConveyorRepository _conveyorRepository;


        public UpdateConveyorController()
        {
            _conveyorRepository = new ConveyorRepository();


        }

        [HttpPost]
        public DbResultInfo ConveyorUpdate(ConveyorsInfo conv)
        {

            return _conveyorRepository.ConveyorUpdate(conv);

        }
    }
}
