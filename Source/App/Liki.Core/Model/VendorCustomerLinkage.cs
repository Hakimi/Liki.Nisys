using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liki.Core.Model
{
    public class VendorCustomerLinkage
    {
        public string ID { get; set; }
        public string Vendor_ID { get; set; }
        public string Vendor_Customer_ID { get; set; }
        public string Customer_ID { get; set; }
    }
}
