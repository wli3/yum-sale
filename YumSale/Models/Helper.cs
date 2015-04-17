using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace YumSale.Models
{
    public class Helper
    {
        public static string GetSaleBaseLink()
        {
            HttpContext context = HttpContext.Current;
            string baseUrl = context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/');
            return baseUrl;
        }
    }
}