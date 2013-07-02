using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Liki.Core.Interface.Service;
using Liki.Core.Model;
using Liki.Service;


namespace Liki.Web.Controllers
{
    public class CustomerController : ApiController
    {

        ICustomerService _CustomerService;
          public CustomerController()
            : this(DependencyResolver.Current.GetService<CustomerService>())
        {
        }

          public CustomerController(CustomerService customerservice)
              : base()
        {
            _CustomerService = customerservice;
        }

        // GET api/customer
        public IEnumerable<string> Get()
        {
            Customer _customer = new Customer();
            _customer.CustomerID = 0;
            _customer.EmailAddress = "tarun";
            _customer.FirstName = "tarun";
            _customer.LastName = "jadav";
            
            _CustomerService.AddCustomer(_customer);
            return new string[] { "value1", "value2" };
        }

        // GET api/customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/customer
        public void Post([FromBody]string value)
        {
        }

        // PUT api/customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customer/5
        public void Delete(int id)
        {
        }
    }
}
