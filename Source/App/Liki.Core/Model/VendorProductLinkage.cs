using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liki.Core.Model
{
    public class VendorProductLinkage
    {
        public string ID { get; set; }
        public string Vendor_ID { get; set; }
        public string Vendor_Product_ID { get; set; }
        public string ProductType_ID { get; set; }
    }
}
