using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace YumSale.Models
{
    public class ItemIndexViewModel
    {
        public ItemIndexViewModel(Item item)
        {
            BuyerName = (item.Buyer != null) ? item.Buyer.Name : null;
            HoldLong = item.HoldLongLessThanDay.Add(new TimeSpan(item.HoldLongDay, 0, 0, 0));
            Name = item.Name;
            ItemId = item.ItemId;
        }

        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Maximum time a buyer can hold")]
        public TimeSpan HoldLong { get; set; }

        [Display(Name = "Buyer Name")]
        public string BuyerName { get; set; }

        public static List<ItemIndexViewModel> MapItemsForIndexView(List<Item> items)
        {
            var itemIndexViewModels = (from item in items
                select new ItemIndexViewModel(item)
                ).ToList();
            return itemIndexViewModels;
        }
    }
}