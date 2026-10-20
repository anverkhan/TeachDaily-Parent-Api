using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class TermFeePay_FeeSetup
    {
        public int PayFeeId { get; set; }

        public string PayFeeType { get; set; }

        public string PayFeeLink { get; set; }

        public int Status { get; set; }
    }
}
