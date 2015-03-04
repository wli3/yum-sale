using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YumSale.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Buyer> Buyers { get; set; }


        public void Seed(ItemContext context)
        {
#if DEBUG
            // Create my debug (testing) objects here
            var item1 = new Item()
            {
                ItemId = 1,
                Name = "item1",
                CreateDateTime = new DateTime(2015, 1, 1),
                Descrption = "good item1",
                HoldLong = new TimeSpan(1)
            };

            var item2 = new Item()
            {
                ItemId = 1,
                Name = "item2",
                CreateDateTime = new DateTime(2015, 1, 2),
                Descrption = "good item2",
                HoldLong = new TimeSpan(2)
            };

            var item3 = new Item()
            {
                ItemId = 1,
                Name = "item3",
                CreateDateTime = new DateTime(2015, 1, 3),
                Descrption = "good item3",
                HoldLong = new TimeSpan(3)
            };
            context.Items.Add(item1);
            context.Items.Add(item2);
            context.Items.Add(item3);
#endif
            context.SaveChanges();
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<ItemContext>
        {
            protected override void Seed(ItemContext context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<ItemContext>
        {
            protected override void Seed(ItemContext context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        static ItemContext()
        {
            #if DEBUG
            Database.SetInitializer<ItemContext> (new DropCreateIfChangeInitializer ());
            #else
            Database.SetInitializer<ItemContext> (new CreateInitializer ());
            #endif
        }
    }
}