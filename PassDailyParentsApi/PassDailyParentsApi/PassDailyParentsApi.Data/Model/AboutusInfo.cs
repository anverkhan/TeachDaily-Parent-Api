using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AboutusInfo
    {

      public int? ABT_FAQ_ID { get; set; }
      public string ABT_FAQ_TITLE { get; set; }
      public string ABT_FAQ_DESCRIPTION { get; set; }
      public byte? ABT_FAQ_TYPE { get; set; }
      public int? ABT_FAQ_CREATEDBY { get; set; }
      public DateTime?  ABT_FAQ_DATE { get; set; }
      public byte? ABT_FAQ_STATUS { get; set; }
    }
}
