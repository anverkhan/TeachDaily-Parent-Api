using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class AlbumImageInfo
    {
        
        public int ALBUM_CATEGORY_ID{ get; set; }
        
        public string ALBUM_CATEGORY_NAME{ get; set; }
        
        public byte? ALBUM_CATEGORY_TYPE { get; set; }
        
        public string ALBUM_TITLE{ get; set; }
        
        public string ALBUM_FILE{ get; set; }
        
        public DateTime? ALBUM_DATE{ get; set; }
        
        public int? ALBUM_CREATED{ get; set; }
        
        public int? ALBUM_ID{ get; set; }

    }
}
