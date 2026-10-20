using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class AlbumInfo
    {
        
        public int ALBUM_CATEGORY_ID { get; set; }

        
        public string ALBUM_CATEGORY_NAME { get; set; }

        public int? COUNT { get; set; }

    }
}
