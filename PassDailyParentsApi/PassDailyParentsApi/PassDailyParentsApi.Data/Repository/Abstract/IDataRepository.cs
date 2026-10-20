using System;
using PassDailyParentsApi.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IDataRepository
    {
        string DataRequest(string datavalue1, string datavalue2);
    }
}
