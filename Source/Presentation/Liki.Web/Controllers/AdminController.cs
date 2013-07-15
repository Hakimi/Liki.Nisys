using System.Web.Mvc;
using Liki.Web.Models;

namespace Liki.Web.Controllers
{
    public class AdminController : Controller
    {
        #region Method
        
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
        //public ActionResult Index()
        //{

        //    return View();
        //}

        /// <summary>
        /// Details
        /// </summary>
        /// <returns></returns>
        public ActionResult Details()
        {
            ViewBag.ApiUrl = Config.WebAPIUrl + "/api/register";
            return View("Details");
        }

        #endregion
    }
}
