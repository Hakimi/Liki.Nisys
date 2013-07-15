using System;
using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.LeaseAgg
{
    public class ProductLease
        : Entity
    {
        #region Property
        
        public string ID { get; set; }
        public string Loan_ID { get; set; }
        public string Customer_ID { get; set; }
        public string ProductActual_ID { get; set; }
        public string Transaction_ID { get; set; }
        public string ProductLeaseFID { get; set; }
        public int State { get; set; }
        #endregion
       
        #region Method
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
