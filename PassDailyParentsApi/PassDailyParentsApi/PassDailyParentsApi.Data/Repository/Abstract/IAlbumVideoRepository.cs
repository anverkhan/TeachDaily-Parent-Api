using System;
using PassDailyParentsApi.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IAlbumVideoRepository
    {
        AlbumInfoRoot AlbumVideoGet(int AccademicId);

        AlbumImageInfoRoot AlbumVideoFilesGet(int AlbumCategoryId);
    }
}
