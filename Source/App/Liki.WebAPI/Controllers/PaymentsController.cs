using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Liki.App.Service.DTO.Payments;

namespace Liki.WebAPI.Controllers
{
    public class PaymentsController : ApiController
    {
        #region Method
        
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //public string Payment()
        //{
        //    return "test11";
        //}
        // GET api/payments/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/payments
        public PaymentResponse Post(PaymentRequest paymentRequest)
        {
            return new PaymentResponse(ConfigurationManager.AppSettings["returnURL"].ToString(), paymentRequest.AuthorizationID);
        }

        // PUT api/payments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/payments/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}
