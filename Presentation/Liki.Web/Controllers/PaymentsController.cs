using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Liki.Core.Model;

namespace Liki.Web.Controllers
{
    public class PaymentsController : ApiController
    {
        // GET api/payments
        public Customer Get()
        {
            Customer _customer = new Customer();
            _customer.CustomerID = 1;
            _customer.EmailAddress = "tarun.jadav@gmail.com";
            _customer.FirstName = "tarun";
            _customer.LastName = "jadav";

            return _customer;
        }
        // GET api/payments/5
        public Customer Get(Customer _customer)
        {
            _customer.CustomerID = 100;
            _customer.EmailAddress = "100tarun.jadav@gmail.com";
            _customer.FirstName = "100tarun";
            _customer.LastName = "100jadav";

            return _customer;
        }

        // POST api/payments
        public void Post([FromBody]string value)
        {
        }

        // PUT api/payments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/payments/5
        public void Delete(int id)
        {
        }
        public string payment()
        {
            return "Payment Done";
        }
    }
}
