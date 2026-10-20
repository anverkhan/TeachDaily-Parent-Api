using System;
using PassDailyParentsApi.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface ILibraryRepository
    {
        LibraryInfoRoot LibraryDetailsGet(int StudentId);
    }
}
