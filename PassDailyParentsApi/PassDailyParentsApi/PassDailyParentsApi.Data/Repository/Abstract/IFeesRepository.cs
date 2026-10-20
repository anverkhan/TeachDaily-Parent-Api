using System;
using PassDailyParentsApi.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IFeesRepository
    {
        FeesPaidInfoRoot FeesPaidListGet(int classId, int accademicId, int studentId, int studentRollNo);

        TermFeeReceiptRoot FeesPaidListGetNew(int StudentId, int ReceiptId);

        TermFeeReceiptRoot1 FeesPaidListGetV1(int StudentId, int ReceiptId);
    }
}
