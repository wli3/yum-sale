using System.Data.Entity;

namespace YumSale.Models
{
    public interface IApplicationDbContext
    {
        DbSet<Item> Items { get; set; }
        DbSet<Buyer> Buyers { get; set; }
    }
}