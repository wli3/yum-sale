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
        private readonly IRepository _repository;

        public BuyController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Buy
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var items = _repository.FindItemsByUserId(id);
            var buyHoldViewModels = BuyHoldViewModel.MapItemsForIndexView(items);
            ViewBag.a = id;
            return View(buyHoldViewModels);
        }
    }
}
