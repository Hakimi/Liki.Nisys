using System.Web;

namespace Liki.Web.Helpers
{
    public class SessionHelper
    {
        public static int CustomerId
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session["CustomerId"] == null)
                    return 0;

                return HttpContext.Current.Session["CustomerId"] is int
                           ? (int) HttpContext.Current.Session["CustomerId"]
                           : 0;

            }
            set { HttpContext.Current.Session["CustomerId"] = value; }
        }


        public static string EmailAddress
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session["EmailAddress"] == null)
                    return null;

                return HttpContext.Current.Session["EmailAddress"] as string;

            }
            set { HttpContext.Current.Session["EmailAddress"] = value; }
        }
    }
}