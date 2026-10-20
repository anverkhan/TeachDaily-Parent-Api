using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IConveyorRepository
    {
        ConveyorsInfoRoot ConveyorGet(int StudentId, int ClassId);

        DbResultInfo ConveyorUpdate(ConveyorsInfo conv);

        DbResultInfo ConveyorCreate(ConveyorsInfo conv);
    }
}
