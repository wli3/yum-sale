using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace YumSale.Models
{
    public class BuyHoldViewModel
    {
        public BuyHoldViewModel(Item item)
        {
            if (item.Buyer != null || item.BuyerId != null || item.HoldTime != null)
            {
                throw new SystemException("Buyer is not null");
            }
            Descrption = item.Descrption;
            HoldLongDay = item.HoldLongDay;
            HoldLongLessThanDay = item.HoldLongLessThanDay;
            HoldTime = item.HoldTime;
            ImageUrl = item.ImageUrl;
            ItemId = item.ItemId;
            Name = item.Name;
        }

        public BuyHoldViewModel()
        {
        }

        [Key]
        [Editable(false)]
        public int ItemId { get; set; }

        [Editable(false)]
        public string Name { get; set; }

        [Editable(false)]
        public string Descrption { get; set; }

        [Url]
        [Display(Name = "Image")]
        [Editable(false)]
        public string ImageUrl { get; set; }

        [Display(Name = "Maxium time you can hold: hours")]
        [Editable(false)]
        public TimeSpan HoldLongLessThanDay { get; set; }

        [Display(Name = "Maxium time you can hold: days")]
        [Editable(false)]
        public int HoldLongDay { get; set; }

        [Required]
        [Display(Name = "Your name")]
        public string BuyerName { get; set; }

        [Required]
        [Display(Name = "How can I contact you?")]
        public string Contact { get; set; }

        [Display(Name = "Token, like \"Would you kindly sell it to me?\"")]
        public string Token { get; set; }

        public DateTime? HoldTime { get; set; }

        public Buyer ToBuyer()
        {
            return new Buyer
            {
                Name = BuyerName,
                Contact = Contact,
                Token = Token
            };
        }

        public static List<BuyHoldViewModel> MapItemsForIndexView(List<Item> items)
        {
            var buyHoldViewModels = (from item in items
                where item.Buyer == null
                select new BuyHoldViewModel(item)
                ).ToList();
            return buyHoldViewModels;
        }
    }
}