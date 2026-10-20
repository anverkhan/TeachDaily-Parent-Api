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
    public class GpsController : ApiController
    {
        private IGpsRepository _gpsRepository = null;

        public GpsController()
        {

            _gpsRepository = new GpsRepository();
        }

        [HttpGet]
        public GpsRootInfo GetLocation(string VehichleId, string TerminalId, string SimNumber)
        {

            return _gpsRepository.GetLocation(VehichleId, TerminalId, SimNumber);

        }

        [HttpGet]
        public GpsVehichleRootInfo GetAllVehichles(string Dummy)
        {

            return _gpsRepository.GetAllVehichles(Dummy);

        }
    }
}
