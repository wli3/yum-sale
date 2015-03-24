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

        [Display(Name = "Sale Last: days")]
        [Range(0, 90)]
        public int HoldLongDay { get; set; }

        [Display(Name = "Sale Last: hours")]
        [Range(0, 23)]
        public int HoldLongHour { get; set; }
    }

    public class ItemIndexViewModel
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime EndTime { get; set; }

        [Display(Name = "Holder Name")]
        public string HolderName { get; set; }
    }
}