﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Transactions;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using YumSale.Models;

namespace YumSale.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Items
        [Authorize]
        public ActionResult Index(IPrincipal user)
        {
            var currentUserId = user.Identity.GetUserId();
            var items = _db.Users.Find(currentUserId).Items.ToList();
            var itemIndexViewModels = MapItemsForIndexView(items);
            return View(itemIndexViewModels);
        }

        private static List<ItemIndexViewModel> MapItemsForIndexView(List<Item> items)
        {
            var itemIndexViewModels = (from item in items
                let endTime = item.CreateDateTime.AddDays(item.HoldLongDay)
                    .Add(item.HoldLongLessThanDay)
                select new ItemIndexViewModel
                {
                    HolderName = (item.Buyer != null) ? item.Buyer.Name : null,
                    EndTime = endTime,
                    Name = item.Name
                }).ToList();
            return itemIndexViewModels;
        }

        // GET: Items/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // TODO should be a way just each in _db
            var item = FindItemInCurrentUser(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        private Item FindItemInCurrentUser(int? id)
        {
            var items = _db.Users.Find(User.Identity.GetUserId()).Items;
            var item = _db.Items.Find(id);
            if (!items.Contains(item))
            {
                item = null;
            }
            return item;
        }

        // TODO anonymous create

        // GET: Items/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Buyers, "ItemId", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(
            [Bind(Include = "ItemId,Name,Descrption,HoldLongDay,HoldLongHour,ImageUrl")] ItemCreateViewModel
                itemCreateViewModel)
        {
            var item = new Item();
            if (ModelState.IsValid)
            {
                item.HoldLongLessThanDay = new TimeSpan(0, itemCreateViewModel.HoldLongHour, 0, 0);
                item.HoldLongDay = itemCreateViewModel.HoldLongDay;
                item.CreateDateTime = DateTime.Now;
                item.Descrption = itemCreateViewModel.Descrption;
                item.ItemId = itemCreateViewModel.ItemId;
                item.Name = itemCreateViewModel.Name;
                item.ImageUrl = itemCreateViewModel.ImageUrl;

                //var item = new Item { CreateDateTime = DateTime.Now };
                _db.Items.Add(item);
                var user = _db.Users.Find(User.Identity.GetUserId());
                user.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(_db.Buyers, "ItemId", "Name", item.ItemId);
            return View(item);
        }

        // GET: Items/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(_db.Buyers, "ItemId", "Name", item.ItemId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(
            [Bind(Include = "ItemId,Name,Descrption,ImageUrl,BuyerId,CreateDateTime,HoldTime,HoldLongLessThanDay")] Item
                item)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(item).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Buyers, "ItemId", "Name", item.ItemId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = _db.Items.Find(id);
            _db.Items.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}