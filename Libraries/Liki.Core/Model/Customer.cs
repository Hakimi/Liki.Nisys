using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liki.Core.Model
{
    public partial class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        //public string CustomerFID { get; set; }
        //public ProductLease ProductLease { get; set; }
    }
}
