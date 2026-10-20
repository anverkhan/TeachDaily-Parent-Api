using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IResultRepository
    {

        ResultInfoRoot AnnualResultGet(int STUDENT_ID, int ACCADEMIC_ID);
    }
}
