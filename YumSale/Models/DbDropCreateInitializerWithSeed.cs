using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YumSale.Models
{
    public class DbDropCreateInitializerWithSeed : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (!(context.Users.Any(u => u.UserName == "testuser@test.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "testuser@test.com", PhoneNumber = "0797697898" };
                userManager.Create(userToInsert, "testuserpassword");

                var coffeeMachine = new Item
                {
                    Name = "Coffee Machine",
                    Descrption = "Good Coffee Machine",
                    ImageUrl = "http://www.coffeemakerscritic.com/gallery/coffee-maker-buying-guide-pictures/Coffee-Maker-Buying-Guide-4.jpg",
                    CreateDateTime = new DateTime(2015, 1, 2, 3, 4, 5),
                    HoldLongDay = 3,
                    HoldLongLessThanDay = new TimeSpan(0,3,0,0)

                };

                var coffeeBeans = new Item
                {
                    Name = "Coffee Beans",
                    Descrption = "Good Coffee Beans",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/4/48/Dark_roasted_espresso_blend_coffee_beans_1.jpg",
                    CreateDateTime = new DateTime(2015, 1, 2, 4, 4, 5),
                    HoldLongDay = 2,
                    HoldLongLessThanDay = new TimeSpan(0,5,0,0)

                };

                var coffeeBlender = new Item
                {
                    Name = "Coffee Blender",
                    Descrption = "Good Coffee Blender",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/a/a3/Electric_coffeegrinder.JPG",
                    CreateDateTime = new DateTime(2015, 1, 3, 4, 4, 5),
                    HoldLongDay = 2,
                    HoldLongLessThanDay = new TimeSpan(0,1,0,0),
                    Buyer = new Buyer
                    {
                        Name = "Johnson",
                        Contact = "Somewhere around",
                        Token = "Ohh long Johnson"
                    },
                    HoldTime = new DateTime(2015, 1, 5, 4, 4, 5)
                };
                userToInsert.Items = new List<Item> {coffeeMachine, coffeeBeans, coffeeBlender};
                context.SaveChanges();
            }

        }
    }
}