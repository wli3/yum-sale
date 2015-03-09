using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YumSale.Models
{
    public interface IApplicationDbContext {
        DbSet<Item> Items { get; set; }
        DbSet<Buyer> Buyers { get; set; }
    }
}