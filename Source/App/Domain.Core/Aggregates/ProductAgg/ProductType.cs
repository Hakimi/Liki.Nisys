using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.ProductAgg
{
    public class ProductType
        : ValueObject<ProductType>
    {
        #region Property
        public string ID { get; set; }
        public string ManuFacturerProduct_ID { get; set; }
        public string Description { get; set; }
        public string ProductType_FID { get; set; }
        #endregion
    }
}
