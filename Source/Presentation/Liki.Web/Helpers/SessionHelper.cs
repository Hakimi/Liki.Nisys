using System.Web;

namespace Liki.Web.Helpers
{
    public class SessionHelper
    {
        public static int UserId
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session["UserId"] == null)
                    return 0;

                return HttpContext.Current.Session["UserId"] is int
                           ? (int) HttpContext.Current.Session["UserId"]
                           : 0;

            }
            set { HttpContext.Current.Session["UserId"] = value; }
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