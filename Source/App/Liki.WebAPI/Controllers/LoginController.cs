using System.Net;
using System.Web.Http;
using Liki.App.Service;
using Liki.App.Service.DTO;

namespace Liki.WebAPI.Controllers
{
    public class LoginController : ApiController
    {

        #region Members
        private readonly IAuthenticationService _iAuthenticationService;
        #endregion

        #region Constructors
        public LoginController(IAuthenticationService iAuthenticationService)
        {
            _iAuthenticationService = iAuthenticationService;
        }
        #endregion

        #region Method
        
        // POST api/login
        [AllowAnonymous]
        public CustomerDTO Post(CustomerDTO dto)
        {
            if (ModelState.IsValidField("EmailAddress") && ModelState.IsValidField("Password"))
            {
                CustomerDTO customerDto = _iAuthenticationService.CustomerLogin(dto.EmailAddress, dto.Password);

                if (customerDto != null)
                {
                    return customerDto;
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return null;
            }
            return null;
        }
        #endregion
    }
}
