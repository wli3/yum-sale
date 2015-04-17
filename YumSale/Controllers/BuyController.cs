﻿using System;
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
        // GET: Buy/Index/e3d42666-b875-41f6-8bf7-213d18e923fc
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(
            string id, List<BuyHoldViewModel> buyHoldViewModels)
        {
            foreach (var buyHoldViewModel in buyHoldViewModels)
            {
                if (buyHoldViewModel.BuyerName != null)
                {
                    var buyer = buyHoldViewModel.ToBuyer();
                    var item = _repository.FindItemById(buyHoldViewModel.ItemId);
                    _repository.AddBuyerToItem(buyer, item);

                }
            }
            return View(buyHoldViewModels);
        }
    }
}
