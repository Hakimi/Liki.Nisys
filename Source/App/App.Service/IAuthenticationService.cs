using Liki.App.Service.DTO;

namespace Liki.App.Service
{
    public interface IAuthenticationService
    {
        #region Method

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        UserDTO UserLogin(string sUserName, string sPassword);

        #endregion
    }
}
