using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using YumSale.Models;

namespace YumSale.Controllers.Api
{
    public class BuyController : ApiController
    {
        private readonly IRepository _repository = new Repository();

        /// <summary>
        ///     Get the specific user's all items
        /// </summary>
        /// <param name="id"> user id</param>
        /// <returns></returns>
        [ActionName("Items")]
        public List<BuyHoldViewModel> GetAllItems(string id)
        {
            var items = _repository.FindItemsByUserId(id);
            var buyHoldViewModels = BuyHoldViewModel.MapItemsForIndexView(items);
            return buyHoldViewModels;
        }

        /// <summary>
        ///     Get the specific item
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="itemId">specific user's item id</param>
        /// <returns></returns>
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

        /// <summary>
        ///     post buyer information to the item
        /// </summary>
        /// <param name="userId">user id that item belong</param>
        /// <param name="itemId"></param>
        /// <param name="buyHoldViewModel">buyer information</param>
        /// <returns></returns>
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