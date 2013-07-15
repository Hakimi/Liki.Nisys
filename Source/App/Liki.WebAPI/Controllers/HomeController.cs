using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liki.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        #region Method
       
        public ActionResult Index()
        {
            return View();
        } 
        #endregion
    }
}
