using System;
using PassDailyParentsApi.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IGpsRepository
    {


        GpsRootInfo GetLocation(string VehichleId, string TerminalId, string SimNumber);

        GpsVehichleRootInfo GetAllVehichles(string Dummy);
    }
}
