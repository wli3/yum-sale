using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using YumSale.Models;

namespace YumSale.Controllers.Api
{
    public class BuyController : ApiController
    {
        private readonly IRepository _repository = new Repository();

        [ActionName("Index")]
        public List<BuyHoldViewModel> GetIndex(string id)
        {
            var items = _repository.FindItemsByUserId(id);
            var buyHoldViewModels = BuyHoldViewModel.MapItemsForIndexView(items);
            return buyHoldViewModels;
        }


        //// PUT: api/Items/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutItem(int id, Item item)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != item.ItemId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(item).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Items
        //[ResponseType(typeof(Item))]
        //public IHttpActionResult PostItem(Item item)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Items.Add(item);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = item.ItemId }, item);
        //}

        //// DELETE: api/Items/5
        //[ResponseType(typeof(Item))]
        //public IHttpActionResult DeleteItem(int id)
        //{
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Items.Remove(item);
        //    db.SaveChanges();

        //    return Ok(item);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ItemExists(int id)
        //{
        //    return db.Items.Count(e => e.ItemId == id) > 0;
        //}
    }
}