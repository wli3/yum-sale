using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace YumSale.Controllers
{
    public class RichClientController : Controller
    {
        public ActionResult Items(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = id;
            return View();
        }
    }
}
