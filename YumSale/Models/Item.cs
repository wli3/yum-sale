using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YumSale.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Descrption { get; set; }

        [Url]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public int? BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }
        public DateTime CreateDateTime { get; set; }

        [Display(Name = "Time when buyer hold")]
        public DateTime? HoldTime { get; set; }

        [Display(Name = "Maximum time a buyer can hold: days")]
        public int HoldLongDay { get; set; }

        [Display(Name = "Maximum time a buyer can hold: hours")]
        public TimeSpan HoldLongLessThanDay { get; set; }

        public void CleanBuyer()
        {
            Buyer = null;
            BuyerId = null;
            HoldTime = null;
        }

        public bool HasBuyer()
        {
            return Buyer != null;
        }
    }
}