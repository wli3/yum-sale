using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace YumSale.Models
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public List<Item> FindItemsByUserId(string currentUserId)
        {
            return _db.Users.Find(currentUserId).Items.ToList();
        }

        public Item FindItemById(int? id)
        {
            return _db.Items.Find(id);
        }

        public Item FindItemInCurrentUser(int? id, String userId)
        {
            var items = _db.Users.Find(userId).Items;
            var item = _db.Items.Find(id);
            if (!items.Contains(item))
            {
                item = null;
            }
            return item;
        }

        public SelectList GetItemIdAndNameSelectList()
        {
            return new SelectList(_db.Buyers, "ItemId", "Name");
        }

        public SelectList GetItemIdAndNameSelectListWithItemId(int itemId)
        {
            return new SelectList(_db.Buyers, "ItemId", "Name", itemId);
        }

        public void AddItemToUser(Item item, String userId)
        {
            _db.Items.Add(item);
            var user = _db.Users.Find(userId);
            user.Items.Add(item);
            SaveChanges();
        }

        public void MarkModified(Item item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveById(int? id)
        {
            var item = _db.Items.Find(id);
            _db.Items.Remove(item);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void AddBuyerToItem(Buyer buyer, Item item)
        {
            _db.Buyers.Add(buyer);
            item.Buyer = buyer;
            item.BuyerId = buyer.BuyerId;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}