using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Liki.App.Service;
using Liki.App.Service.DTO;

namespace Liki.WebAPI.Controllers
{
    public class RegisterController : ApiController
    {
        #region Members
        private readonly ICustomerService _iCustomerService;
        #endregion
        #region Constructors

        public RegisterController(ICustomerService customerservice)
        {
            _iCustomerService = customerservice;
        }
        #endregion
        #region Method

        // GET api/register
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerDTO> Get()
        {
            return _iCustomerService.GetAllCustomer();
        }

        // GET api/values/5
        public CustomerDTO Get(int id)
        {
            return _iCustomerService.FindCustomer(id);
        }

        // POST api/register
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="dto">customerdto object</param>
        /// <returns></returns>
        public bool Post(CustomerDTO dto)
        {
            
            if (ModelState.IsValid)
            {
                _iCustomerService.AddNewCustomer(dto);

                return true;
            }
            return false;
        }
        
        // PUT api/register/5
        /// <summary>
        /// Edit Customer Details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        public HttpResponseMessage PutRegister(int id, CustomerDTO customerDto)
        {
            _iCustomerService.UpdateCustomer(customerDto);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion
    }

}
