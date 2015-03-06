using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YumSale.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext() : base("DefaultConnection")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
    }
}