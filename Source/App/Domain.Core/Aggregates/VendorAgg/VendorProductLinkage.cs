using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.VendorAgg
{
    public class VendorProductLinkage
         : ValueObject<VendorProductLinkage>
    {
        #region Property
        public string ID { get; set; }
        public string Vendor_ID { get; set; }
        public string Vendor_Product_ID { get; set; }
        public string ProductType_ID { get; set; }
        #endregion
    }
}
