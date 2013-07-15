using System.Configuration;

namespace Liki.Web.Models
{
    public class Config
    {
        public static string WebAPIUrl
        {
            get { return ConfigurationManager.AppSettings["WebAPIUrl"].ToString(); }
        }
    }
}