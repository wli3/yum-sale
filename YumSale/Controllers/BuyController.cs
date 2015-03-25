using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YumSale.Models;

namespace YumSale.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.a = id;
            return View();
        }
    }
}
