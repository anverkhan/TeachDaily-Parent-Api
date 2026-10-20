using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PassDailyParentsApi.Service.Controllers
{
    public class ServerController : ApiController
    {
        public ServerController()
        {

        }

        [HttpGet]
        public string Ping()
        {

            return "Connected";

        }
    }
}
