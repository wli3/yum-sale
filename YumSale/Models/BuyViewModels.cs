using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

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
            Debug.Assert(item.Buyer == null);
            

        }

    }
}