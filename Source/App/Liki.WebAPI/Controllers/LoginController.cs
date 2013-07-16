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
        public UserDTO Post(UserDTO dto)
        {
            if (ModelState.IsValidField("EmailAddress") && ModelState.IsValidField("Password"))
            {
                UserDTO UserDto = _iAuthenticationService.UserLogin(dto.EmailAddress, dto.Password);

                if (UserDto != null)
                {
                    return UserDto;
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return null;
            }
            return null;
        }

        #endregion
    }
}
