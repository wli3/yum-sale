using System;
using System.ComponentModel.DataAnnotations;

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
}