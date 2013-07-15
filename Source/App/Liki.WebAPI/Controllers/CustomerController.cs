using System.Web.Http;
using Liki.App.Service;
using Liki.App.Service.DTO;

namespace Liki.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        #region Members
        ICustomerService _CustomerService;
        #endregion

        #region Constructors
        
        public CustomerController(ICustomerService _customerservice)
            : base()
        {
            _CustomerService = _customerservice;
        }
        #endregion
    
        #region Method

        // GET api/customer
        public CustomerDTO Get()
        {
             
            CustomerDTO _customer = new CustomerDTO();
            _customer.CustomerID = 31;
            _customer.EmailAddress = "tarun11111111";
            _customer.FirstName = "tarun";
            _customer.LastName = "jadav";
            _customer.Title = "TEST";
            _customer.MiddleName = "test22222";
            _customer.Password = "testss";
            _customer.Suffix = "sdfsdf";
           
            
            return _CustomerService.AddNewCustomer(_customer);

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
        #endregion

    }
}
