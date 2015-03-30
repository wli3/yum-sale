using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace YumSale.Models
{
    public class ItemCreateViewModel
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Descrption { get; set; }

        [Url]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Maximum time a buyer can hold: days")]
        [Range(0, 90)]
        public int HoldLongDay { get; set; }

        [Display(Name = "Maximum time a buyer can hold: hours")]
        [Range(0, 23)]
        public int HoldLongHour { get; set; }

        public Item ToItem()
        {
            var item = new Item
            {
                HoldLongLessThanDay = new TimeSpan(0, HoldLongHour, 0, 0),
                HoldLongDay = HoldLongDay,
                CreateDateTime = DateTime.Now,
                Descrption = Descrption,
                ItemId = ItemId,
                Name = Name,
                ImageUrl = ImageUrl
            };
            return item;
        }
    }

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