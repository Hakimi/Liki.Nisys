using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liki.Core.Model
{
    public partial class ProductLease
    {
        public string ID { get; set; }
        public string Loan_ID { get; set; }
        public string Customer_ID { get; set; }
        public string ProductActual_ID { get; set; }
        public string Transaction_ID { get; set; }
        public string ProductLeaseFID { get; set; }
        public int State { get; set; }

    }
}
