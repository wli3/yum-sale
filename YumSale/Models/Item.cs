using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime? HoldTime { get; set; }

        [Display(Name = "Sale Last")]
        public TimeSpan HoldLongLessThanDay { get; set; }
        public int HoldLongDay { get; set; }
    }
}