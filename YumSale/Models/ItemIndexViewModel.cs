using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace YumSale.Models
{
    public class ItemIndexViewModel
    {
        public ItemIndexViewModel(Item item)
        {
            BuyerName = (item.Buyer != null) ? item.Buyer.Name : null;
            BuyerId = item.BuyerId;
            HoldLong = item.HoldLongLessThanDay.Add(new TimeSpan(item.HoldLongDay, 0, 0, 0));
            Name = item.Name;
            ItemId = item.ItemId;
            HasBuyer = item.HasBuyer();
            if (item.Buyer != null && item.HoldTime != null)
            {
                DateTime maxiumTime = (DateTime) item.HoldTime;
                maxiumTime = maxiumTime.AddDays(item.HoldLongDay).Add(item.HoldLongLessThanDay);
                if (maxiumTime < DateTime.Now)
                {
                    BuyerTimeOut = true;
                }
            }
            else
            {
                BuyerTimeOut = false;
            }
        }

        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Maximum time a buyer can hold")]
        public TimeSpan HoldLong { get; set; }

        
        public int? BuyerId { get; set; }
        [Display(Name = "Buyer Name")]
        public string BuyerName { get; set; }

        public bool HasBuyer { get; set; }

        public bool BuyerTimeOut { get; set; }
 
        public static List<ItemIndexViewModel> MapItemsForIndexView(List<Item> items)
        {
            var itemIndexViewModels = (from item in items
                select new ItemIndexViewModel(item)
                ).ToList();
            return itemIndexViewModels;
        }
    }
}