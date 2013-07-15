using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.VendorAgg
{
    public class VendorCustomerLinkage
         : ValueObject<VendorCustomerLinkage>
    {
        #region Property
        public string ID { get; set; }
        public string Vendor_ID { get; set; }
        public string Vendor_Customer_ID { get; set; }
        public string Customer_ID { get; set; }
        #endregion
    }
}
