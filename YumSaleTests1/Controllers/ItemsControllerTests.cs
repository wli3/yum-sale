using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NUnit.Framework;
using YumSale.Controllers;
using YumSale.Models;
using YumSaleTests.FakeModel;

namespace YumSaleTests.Controllers
{
    [TestFixture()]
    public class ItemsControllerTests
    {
        private ApplicationDbContext _fakeDbContext;

        [SetUp]
        public void InitFakeDbContext()
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();

            _fakeDbContext = new ApplicationDbContext(connection);

            var item0 = new Item()
            {
                CreateDateTime = new DateTime(2012, 3, 4),
                Descrption = "good one",
                HoldLongLessThanDay = new TimeSpan(0, 1, 2, 3),
                HoldLongDay = 1,
                ItemId = 1,
                Name = "item0"
            };

            var item1 = new Item()
            {
                CreateDateTime = new DateTime(2012, 3, 4),
                Descrption = "good one",
                HoldLongLessThanDay = new TimeSpan(0, 1, 2, 3),
                HoldLongDay = 1,
                ItemId = 1,
                Name = "item1"
            };

            var items0 = new List<Item> {item0};
            var items1 = new List<Item> { item1 };

            var user0 = (new ApplicationUser
            {
                UserName = "User0 Name0",
                Id = "0",
                Items = items0
            });

            var user1 = (new ApplicationUser
            {
                UserName = "User1 Name1",
                Id = "1",
                Items = items1
            });

            _fakeDbContext.Users.Add(user0);
            _fakeDbContext.Users.Add(user1);
            _fakeDbContext.Items.Add(item0);
            _fakeDbContext.Items.Add(item1);
            _fakeDbContext.SaveChanges();
        }

        [Test()]
        public void IndexControlShouldOnlyFindCurrentUsers()
        {
            // Arrange
            var controller = new ItemsController();

            // Act
            IPrincipal fakeUser = new GenericPrincipal(new FakeClaimIdentity("0", "User0 Name0"), null);
            var result = controller.Index(fakeUser) as ViewResult;
            var itemIndexViewModels = (List<ItemCreateViewModel>) result.ViewData.Model;
            var onlyItem = itemIndexViewModels.First();

            // Assert
            Assert.Equals(1, itemIndexViewModels.Count());
            Assert.Equals(1, onlyItem.Name = "item0");
        }

        [Test()]
        public void IndexControlShouldMapViewModelCorrectly()
        {
            // Arrange
            var controller = new ItemsController();

            // Act
            IPrincipal fakeUser = new GenericPrincipal(new FakeClaimIdentity("0", "User0 Name0"), null);
            var userId = fakeUser.Identity.GetUserId();
            var result = controller.Index(fakeUser) as ViewResult;
            var itemIndexViewModels = (List<ItemCreateViewModel>)result.ViewData.Model;
            var onlyItem = itemIndexViewModels.First();

            // Assert
            Assert.Equals(1, onlyItem.Name = "item0");
            Assert.Equals(1, onlyItem.ItemId = 0);
            Assert.Equals(1, onlyItem.Descrption = "good one");
        }



        [Test()]
        public void DetailsTest()
        {
            //Assert.Fail();
        }

        [Test()]
        public void CreateTest()
        {
            //Assert.Fail();
        }

        [Test()]
        public void CreateTest1()
        {
            //Assert.Fail();
        }

        [Test()]
        public void EditTest()
        {
            //Assert.Fail();
        }

        [Test()]
        public void EditTest1()
        {
            //Assert.Fail();
        }

        [Test()]
        public void DeleteTest()
        {
            //Assert.Fail();
        }

        [Test()]
        public void DeleteConfirmedTest()
        {
            //Assert.Fail();
        }
    }
}
