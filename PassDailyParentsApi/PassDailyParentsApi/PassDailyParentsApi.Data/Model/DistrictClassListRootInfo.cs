using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class DistrictClassListRootInfo
    {
        public ClassListInfo[] ClassList { get; set; }
        public DistrictListInfo[] DistrictList { get; set; }
    }
}
