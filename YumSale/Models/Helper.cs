using System.Web;

namespace YumSale.Models
{
    public class Helper
    {
        public static string GetSaleBaseLink()
        {
            var context = HttpContext.Current;
            var baseUrl = context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/');
            return baseUrl;
        }
    }
}