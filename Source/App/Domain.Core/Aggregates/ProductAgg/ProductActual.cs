using System;
using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.ProductAgg
{
    public class ProductActual
        : Entity
    {

        #region Property
        public string ID { get; set; }
        public string SerialNumber { get; set; }
        public string Owner { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
        public string ProductType_ID { get; set; }
        #endregion

        #region Method
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
