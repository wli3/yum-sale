using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace YumSale.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Descrption { get; set; }

        public int? BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime HoldTime { get; set; }

        public TimeSpan HoldLong { get; set; }
    }
}