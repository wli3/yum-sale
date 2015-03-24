using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace YumSale.Models
{
    public interface IRepository
    {
        List<Item> FindItemsByUserId(string currentUserId);
        Item FindItemInCurrentUser(int? id, String userId);
        Item FindItemById(int? id);
        SelectList GetItemIdAndNameSelectList();
        SelectList GetItemIdAndNameSelectListWithItemId(int itemId);
        void AddItemToUser(Item item, String userId);
        void MarkModified(Item item);
        void RemoveById(int? id);
        void Dispose();
    }
}