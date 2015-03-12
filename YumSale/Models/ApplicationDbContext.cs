using System.Data.Common;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YumSale.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public ApplicationDbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<YumSale.Models.ItemIndexViewModel> ItemIndexViewModels { get; set; }
    }
}