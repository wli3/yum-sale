using System.Data.Entity;
using YumSale.Models;

namespace YumSale
{
    public class DebugInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // seed database here
        }
    }
}