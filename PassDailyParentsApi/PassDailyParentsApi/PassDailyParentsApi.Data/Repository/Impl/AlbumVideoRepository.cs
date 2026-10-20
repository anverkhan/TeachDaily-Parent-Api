using System;
using PassDailyParentsApi.Data.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;
using System.Data;
namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class AlbumVideoRepository : IAlbumVideoRepository
    {
        public AlbumInfoRoot AlbumVideoGet(int AccademicId)
        {
            AlbumInfoRoot result = new AlbumInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@ACCADEMIC_ID", DbType.Int32, AccademicId);
                    var Albums = context.Database.SqlQuery<AlbumInfo>("dbo.sms_ALBUM_VIDEO_CATEGORY_GET @ACCADEMIC_ID", parameters);
                    result.AlbumList = Albums.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public AlbumImageInfoRoot AlbumVideoFilesGet(int AlbumCategoryId)
        {
            AlbumImageInfoRoot result = new AlbumImageInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = DataHelper.CreateSqlParameter("@ALBUM_CATEGORY_ID", DbType.Int32, AlbumCategoryId);
                    var AlbumVideos = context.Database.SqlQuery<AlbumImageInfo>("dbo.sms_ALBUM_VIDEO_LIST_ALBUM_CATEGORY @ALBUM_CATEGORY_ID", parameters);
                    result.AlbumImageList = AlbumVideos.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }
    }
}
