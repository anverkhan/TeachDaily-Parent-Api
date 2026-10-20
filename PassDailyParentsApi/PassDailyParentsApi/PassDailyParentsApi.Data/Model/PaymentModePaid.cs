using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class PaymentModePaid
    {
        public int? PaymentModeId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? ReceiptId { get; set; }
        public string PaymentType { get; set; }
        public int? Amount { get; set; }
        public string ChequeOrDDNo { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public DateTime? DeppositDate { get; set; }
        public DateTime? ClearingDate { get; set; }
        public int? BankId { get; set; }
        public string BankName { get; set; }

    }
}
