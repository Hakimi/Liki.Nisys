using System;
using Liki.App.Service.DTO;
using Liki.Domain.Core.Aggregates.CustomerAgg;

namespace Liki.App.Service
{
   public class AuthenticationService:IAuthenticationService
    {
      
       #region Members

       private readonly ICustomerRepository _customerRepository;

       #endregion
       #region Constructors
       public AuthenticationService()
       {


       }
       /// <summary>
       /// Create a new instance of Authentication Service
       /// </summary>
       /// <param name="customerRepository"></param>
       public AuthenticationService(ICustomerRepository customerRepository)
       {
            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");

            _customerRepository = customerRepository;
        }
       #endregion
       #region IAuthenticationService Members
       /// <summary>
       /// Customer Login 
       /// </summary>
       /// <param name="sUserName"></param>
       /// <param name="sPassword"></param>
       /// <returns></returns>
       public CustomerDTO CustomerLogin(string sUserName, string sPassword)
       {
           var current= _customerRepository.FindOne(x => x.EmailAddress == sUserName && x.Password == sPassword);
           if (current != null)
           {
               AutoMapper.Mapper.CreateMap<Customer, CustomerDTO>();
               return AutoMapper.Mapper.Map<Customer, CustomerDTO>(current);
           }
           return null;
       }

       #endregion
    }
}
