using System.Collections.Generic;
using System.Web.Mvc;

namespace Liki.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Method
        
        /// <summary>
        /// About Us
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutUs()
        {
            return View();
        }

        /// <summary>
        /// User Agreement
        /// </summary>
        /// <returns></returns>
        public ActionResult UserAgreement()
        {
            return View();
        }

        /// <summary>
        /// Privacy Policy
        /// </summary>
        /// <returns></returns>
        public ActionResult PrivacyPolicy()
        {
            return View();
        }


        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// GoToEditor
        /// </summary>
        /// <returns></returns>
        public ActionResult GoToEditor()
        {
            return View("EasyQuery");
        }

        public ActionResult SeachResult(List<Liki.App.Service.DTO.UserDTO> lstUsers)
        {
            return View("SearchResult", lstUsers);
        }
        #endregion
        
    }
}
