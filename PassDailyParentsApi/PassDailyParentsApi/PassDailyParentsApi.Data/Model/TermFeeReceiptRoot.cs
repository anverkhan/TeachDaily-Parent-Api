using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class TermFeeReceiptRoot
    {
        public TermFeeReceiptDetail ReceiptDetail { get; set; }
        public TermFeePaidDetails[] TermfeepaidList { get; set; }
        public PaymentModePaid[] PaymentmodeList { get; set; }
    }
}
