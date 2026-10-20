using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IParentAccountRepository
    {
        ParentAccountInfo ParentAccountCreate(string MobileNumber, string SchoolCode);
    }
}
