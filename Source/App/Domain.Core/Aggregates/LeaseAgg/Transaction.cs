using System;
using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.LeaseAgg
{
    public class Transaction
        : ValueObject<Transaction>
    {
        #region Property
        public string ID { get; set; }
        public string TransactionFID { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string ProductLease_ID { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public ProductLease ProductLease { get; set; }
        #endregion
    }
}
