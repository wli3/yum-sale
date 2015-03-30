using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YumSale.Models
{
    public class BuyHoldViewModel
    {
        [Key]
        [Editable(false)]
        public int ItemId { get; set; }

        [Required]
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

        [ForeignKey("Buyer")]
        public string BuyerId { get; set; }

        [Required]
        [Display(Name = "Your name")]
        public string BuyerName { get; set; }

        [Required]
        [Display(Name = "How can I contact you?")]
        public string Contact { get; set; }

        [Display(Name = "Token, like \"Would you kindly sell it to me?\"")]
        public string Token { get; set; }

        public DateTime? HoldTime { get; set; }

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

        public BuyHoldViewModel() {}

        public Buyer ToBuyer()
        {
            return new Buyer
            {
                Name = BuyerName,
                Contact = Contact,
                Token = Token
            };
        }
    }
}