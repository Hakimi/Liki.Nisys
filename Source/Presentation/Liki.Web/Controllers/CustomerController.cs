﻿using System.Web.Mvc;
using Liki.Web.Models;


namespace Liki.Web.Controllers
{
    public class CustomerController : Controller
    {
        #region Method
        public ActionResult Index()
        {
            ViewBag.ApiUrl = Config.WebAPIUrl + "/api";
            return View();
        }
        #endregion

    }
}
