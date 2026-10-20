using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class ConveyorsInfo
    {
        
        public int CONVEYORS_ID { get; set; }
        
        public string CONVEYORS_NAME { get; set; }
        
        public string CONVEYORS_MOBILE { get; set; }
        
        public string CONVEYORS_VEHICLE_NO { get; set; }
        
        public string CONVEYORS_ADDRESS { get; set; }
        
        public int STUDENT_ID { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public byte? CONVEYORS_STATUS { get; set; }
        
        public DateTime? CONVEYORS_DATE { get; set; }

    }
}
