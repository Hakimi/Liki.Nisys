using System;
using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.VendorAgg
{
    public class Vendor
        : Entity
    {
        #region Property
        public string ID { get; set; }
        public string Vendor_ID { get; set; }
        public string Name { get; set; }
        #endregion
        #region Method
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
