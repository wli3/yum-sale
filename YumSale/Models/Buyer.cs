﻿using System.ComponentModel.DataAnnotations;

namespace YumSale.Models
{
    /// <summary>
    ///     Light weight account, then where is not item attached, it should be delete
    ///     shouldn't need login
    /// </summary>
    public class Buyer
    {
        public int BuyerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact { get; set; }

        public string Token { get; set; }
    }
}