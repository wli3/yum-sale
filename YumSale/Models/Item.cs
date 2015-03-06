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

        public virtual Buyer Buyer { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime HoldTime { get; set; }
        public TimeSpan HoldLong { get; set; }
    }
}