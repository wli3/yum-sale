using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
        // GET: Buy/Index/e3d42666-b875-41f6-8bf7-213d18e923fc
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var items = _repository.FindItemsByUserId(id);
            var buyHoldViewModels = BuyHoldViewModel.MapItemsForIndexView(items);
            ViewBag.userId = id;
            return View(buyHoldViewModels);
        }

        public ActionResult Details(string userId, int? itemId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _repository.FindItemInCurrentUser(itemId, userId);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(new BuyHoldViewModel(item));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(string userId, int? itemId,
        [Bind(Include = "BuyerName,Contact,Token")] BuyHoldViewModel buyHoldViewModel)
        {
            if (ModelState.IsValid)
            {
                var buyer = buyHoldViewModel.ToBuyer();
                var item = _repository.FindItemById(itemId);
                _repository.AddBuyerToItem(buyer, item);
            }
            return RedirectToAction("Index", new RouteValueDictionary(
     new { controller = "Buy", action = "Index", Id = userId }));
        }
    }
}
