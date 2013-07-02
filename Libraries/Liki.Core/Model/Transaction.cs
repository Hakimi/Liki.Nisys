using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liki.Core.Model
{
    public partial class Transaction
    {
        public string ID { get; set; }
        public string TransactionFID { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string ProductLease_ID { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public ProductLease ProductLease { get; set; }
    }
}
