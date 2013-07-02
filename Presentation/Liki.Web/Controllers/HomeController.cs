using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Liki.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          

          //  Merchant_Id=&Amount=12010&Order_Id=100000008&Redirect_Url=http%3A%2F%2Flocalhost%3A85%2Fccavenue%2Fpayment%2Fresponse&Checksum=1899959722&billing_cust_name=tarun+jadav&billing_cust_address=test+nennee%0D%0Aeee&billing_cust_country=United+States&billing_cust_state=Arizona&billing_zip=895002&billing_cust_tel=324234234&billing_cust_email=tarun.jadav@gmail.com&delivery_cust_name=tarun+jadav&delivery_cust_address=test+nennee%0D%0Aeee&delivery_cust_country=United+States&delivery_cust_state=Arizona&delivery_cust_tel=324234234&billing_cust_notes=&Merchant_Param=&billing_cust_city=reno&billing_zip_code=895002&delivery_cust_city=reno&delivery_zip_code=895002 

            Encoding encodeRequest = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readerPostData = new StreamReader( Request.InputStream, encodeRequest);
            string strPostDate = readerPostData.ReadToEnd();
           // ViewBag.requestData = strPostDate;
            var postDateList = strPostDate.Split('&').ToList ();
            if (postDateList.Count() > 1)
            {
                //Response.Redirect("http://localhost:1518/Default.aspx");
                for (int i = 0; i < postDateList.Count(); i++)
                {
                    if (postDateList[i].ToLower ().Contains("action"))
                    {
                        ViewBag.action = postDateList[i].Split('=')[1];
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
            ViewBag.Message = "test";
            return View();
        }
        public ActionResult SelectCategory()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Action", Value = "0" });

            items.Add(new SelectListItem { Text = "Drama", Value = "1" });

            items.Add(new SelectListItem { Text = "Comedy", Value = "2", Selected = true });

            items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

            ViewBag.MovieType = items;

            return View();

        }
    }
}
