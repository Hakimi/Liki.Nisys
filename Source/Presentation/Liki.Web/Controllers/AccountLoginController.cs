
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Liki.Web.Helpers;
using Liki.Web.Models;

namespace Liki.Web.Controllers
{
    public class AccountLoginController : Controller
    {
        #region Method
        
        public ActionResult Index()
        {
            GetPostData();
            ViewBag.ApiUrl = Config.WebAPIUrl + "/api";
            return View();
        }

        /// <summary>
        /// Save session value
        /// </summary>
        /// <param name="UserId">User's Id</param>
        /// <param name="EmailAddress">User's EmailAddress</param>
        public void SaveSession(int UserId, string EmailAddress)
        {
            SessionHelper.UserId = UserId;
            SessionHelper.EmailAddress = EmailAddress;
        }

        public void GetPostData()
        {

            Encoding encodeRequest = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readerPostData = new StreamReader(Request.InputStream, encodeRequest);
            string strPostDate;
            strPostDate = readerPostData.ReadToEnd();
         
            var postDateList = strPostDate.Split('&').ToList();
            if (postDateList.Count() > 1)
            {
                for (int i = 0; i < postDateList.Count(); i++)
                {
                    if (postDateList[i].ToLower().Contains("action"))
                    {
                        ViewBag.action = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("order_id"))
                    {
                        ViewBag.order_id = postDateList[i].Split('=')[1];
                    }

                    if (postDateList[i].ToLower().Contains("merchant_id"))
                    {
                        ViewBag.merchant_id = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("amount"))
                    {
                        ViewBag.amount = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("redirect_url"))
                    {
                        ViewBag.redirect_url = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("working_key"))
                    {
                        ViewBag.working_key = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("checksum"))
                    {
                        ViewBag.checksum = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("billing_cust_name"))
                    {
                        ViewBag.billing_cust_name = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("billing_cust_address'"))
                    {
                        ViewBag.billing_cust_address = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("billing_cust_state'"))
                    {
                        ViewBag.billing_cust_state = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("billing_cust_country'"))
                    {
                        ViewBag.billing_cust_country = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("billing_cust_tel'"))
                    {
                        ViewBag.billing_cust_tel = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("billing_cust_email'"))
                    {
                        ViewBag.billing_cust_email = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("delivery_cust_name'"))
                    {
                        ViewBag.delivery_cust_name = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("delivery_cust_address'"))
                    {
                        ViewBag.delivery_cust_address = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("delivery_cust_state'"))
                    {
                        ViewBag.delivery_cust_state = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("delivery_cust_country'"))
                    {
                        ViewBag.delivery_cust_country = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("delivery_cust_tel'"))
                    {
                        ViewBag.delivery_cust_tel = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("merchant_param'"))
                    {
                        ViewBag.merchant_param = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("billing_city'"))
                    {
                        ViewBag.billing_city = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("billing_zip'"))
                    {
                        ViewBag.billing_zip = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("delivery_city'"))
                    {
                        ViewBag.delivery_city = postDateList[i].Split('=')[1];
                    }
                    if (postDateList[i].ToLower().Contains("delivery_zip'"))
                    {
                        ViewBag.delivery_zip = postDateList[i].Split('=')[1];
                    }

                    if (postDateList[i].ToLower().Contains("billing_cust_notes'"))
                    {
                        ViewBag.billing_cust_notes = postDateList[i].Split('=')[1];
                    }
                }
            }
        }
        #endregion

    }
}
