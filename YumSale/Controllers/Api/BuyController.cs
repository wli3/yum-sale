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

        [ActionName("Items")]
        public List<BuyHoldViewModel> GetAllItems(string id)
        {
            var items = _repository.FindItemsByUserId(id);
            var buyHoldViewModels = BuyHoldViewModel.MapItemsForIndexView(items);
            return buyHoldViewModels;
        }

        [ActionName("Items")]
        public IHttpActionResult GetItem(string userId, int itemId)
        {
            if (userId == null)
            {
                return NotFound();
            }
            var item = _repository.FindItemInCurrentUser(itemId, userId);
            if (item == null || item.HasBuyer())
            {
                return NotFound();
            }
            return Ok(new BuyHoldViewModel(item));
        }


        [ActionName("Items")]
        [ResponseType(typeof (void))]
        public IHttpActionResult PostItem(string userId, int itemId, BuyHoldViewModel buyHoldViewModel)
        {
            if (ModelState.IsValid)
            {
                var buyer = buyHoldViewModel.ToBuyer();
                var item = _repository.FindItemById(itemId);
                if (item.HasBuyer())
                {
                    return BadRequest();
                }
                _repository.AddBuyerToItem(buyer, item);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}