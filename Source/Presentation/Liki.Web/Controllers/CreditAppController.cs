using System.Web.Mvc;
using Liki.Web.Helpers;
using Liki.Web.Models;

namespace Liki.Web.Controllers
{
    public class CreditAppController : Controller
    {
        #region Method
        
        /// <summary>
        /// HomePage
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePage()
        {
            ViewBag.ApiUrl = Config.WebAPIUrl + "/api";
            return View();
        }

        /// <summary>
        /// Index Page of register
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            ViewBag.ApiUrl = Config.WebAPIUrl + "/api";
            ViewBag.CustomerID = SessionHelper.CustomerId;
            return View("Index");

            //ViewBag.ApiUrl = Config.WebAPIUrl + "/api";
            //return View();
        }
        /// <summary>
        /// Get Data from Request  
        /// </summary>
        

        public ActionResult Create()
        {
            return View();
        }
        #endregion
    }
}
