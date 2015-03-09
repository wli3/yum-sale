using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using YumSale.Models;

namespace YumSale.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Items
        [Authorize]
        public ActionResult Index()
        {
            var items = db.Users.Find(User.Identity.GetUserId()).Items;

            return View(items.ToList());
        }

        // GET: Items/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // TODO should be a way just each in db
            var item = FindItemInCurrentUser(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        private Item FindItemInCurrentUser(int? id)
        {
            var items = db.Users.Find(User.Identity.GetUserId()).Items;
            var item = db.Items.Find(id);
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
            ViewBag.ItemId = new SelectList(db.Buyers, "ItemId", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(
            [Bind(Include = "ItemId,Name,Descrption,HoldLongDay,HoldLongHour,ImageUrl")] ItemViewModel itemViewModel)
        {
            var item = new Item();
            if (ModelState.IsValid)
            {
                item.HoldLong = new TimeSpan(0, itemViewModel.HoldLongHour, 0, 0);
                item.HoldTimeDay = itemViewModel.HoldLongDay;
                item.CreateDateTime = DateTime.Now;
                item.Descrption = itemViewModel.Descrption;
                item.ItemId = itemViewModel.ItemId;
                item.Name = itemViewModel.Name;
                item.ImageUrl = itemViewModel.ImageUrl;

                //var item = new Item { CreateDateTime = DateTime.Now };
                db.Items.Add(item);
                var user = db.Users.Find(User.Identity.GetUserId());
                user.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Buyers, "ItemId", "Name", item.ItemId);
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
            var item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Buyers, "ItemId", "Name", item.ItemId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(
            [Bind(Include = "ItemId,Name,Descrption,ImageUrl,BuyerId,CreateDateTime,HoldTime,HoldLong")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Buyers, "ItemId", "Name", item.ItemId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = db.Items.Find(id);
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
            var item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}