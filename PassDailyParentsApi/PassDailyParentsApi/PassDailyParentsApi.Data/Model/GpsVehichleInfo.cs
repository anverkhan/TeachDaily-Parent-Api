using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class GpsVehichleInfo
    {
        public int VEHICLE_ID { get; set; }
        public string VEHICLE_REG_NO { get; set; }
        public string VEHICLE_NAME { get; set; }
        public string VEHICLE_ROOT { get; set; }
        public string DRIVER_NAME { get; set; }
        public string DRIVER_MOBILE { get; set; }
        public string TERMINAL_ID { get; set; }
        public string SIM_NUMBER { get; set; }
        public string EXE_NAME { get; set; }
        public string IP_ADDRESS { get; set; }
        public string PORT_NUMBER { get; set; }
        public byte? VEHICLE_STATUS { get; set; }
    }
}
