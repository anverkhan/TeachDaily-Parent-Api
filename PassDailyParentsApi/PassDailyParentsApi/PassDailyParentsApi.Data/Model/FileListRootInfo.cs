using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class FileListRootInfo
    {
        public StudyMaterialListInfo[] StudyMaterialDetails { get; set; }

        public FileListInfo[] FilesDetails { get; set; }
    }

}
