using Liki.App.Service.DTO;

namespace Liki.App.Service
{
   public interface IAuthenticationService
   {
       #region Method
     
       /// <summary>
       /// Customer Login
       /// </summary>
       /// <param name="sUserName"></param>
       /// <param name="sPassword"></param>
       /// <returns></returns>
       CustomerDTO CustomerLogin(string sUserName, string sPassword);
       #endregion
   }
}
