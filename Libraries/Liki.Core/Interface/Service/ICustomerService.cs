using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liki.Core.Model;

namespace Liki.Core.Interface.Service
{
    public  interface ICustomerService
    {
        void AddCustomer(Customer _customer);
    }
}
