using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using Effort;
using Effort.Provider;
using Microsoft.AspNet.Identity;
using Xunit;
using YumSale.Controllers;
using YumSale.Models;

//namespace YumSaleTests.Controllers
//{
//    public class ItemsControllerTests
//    {
//        private ApplicationDbContext _fakeDbContext;

//        public void InitFakeDbContext()
//        {
//            EffortProviderConfiguration.RegisterProvider();
//            var connection = DbConnectionFactory.CreateTransient();

//            _fakeDbContext = new ApplicationDbContext(connection);

//            var item0 = new Item
//            {
//                CreateDateTime = new DateTime(2012, 3, 4),
//                Descrption = "good one",
//                HoldLongLessThanDay = new TimeSpan(0, 1, 2, 3),
//                HoldLongDay = 1,
//                ItemId = 1,
//                Name = "item0"
//            };

//            var item1 = new Item
//            {
//                CreateDateTime = new DateTime(2012, 3, 4),
//                Descrption = "good one",
//                HoldLongLessThanDay = new TimeSpan(0, 1, 2, 3),
//                HoldLongDay = 1,
//                ItemId = 1,
//                Name = "item1"
//            };

//            var items0 = new List<Item> {item0};
//            var items1 = new List<Item> {item1};

//            var user0 = (new ApplicationUser
//            {
//                UserName = "User0 Name0",
//                Id = "0",
//                Items = items0
//            });

//            var user1 = (new ApplicationUser
//            {
//                UserName = "User1 Name1",
//                Id = "1",
//                Items = items1
//            });

//            _fakeDbContext.Users.Add(user0);
//            _fakeDbContext.Users.Add(user1);
//            _fakeDbContext.Items.Add(item0);
//            _fakeDbContext.Items.Add(item1);
//            _fakeDbContext.SaveChanges();
//        }

//        [Fact]
//        public void IndexControlShouldOnlyFindCurrentUsers()
//        {
//            // Arrange
//            InitFakeDbContext();
//            var controller = new ItemsController(_fakeDbContext);

//            // Act
//            IPrincipal fakeUser = new GenericPrincipal(new FakeClaimIdentity("0", "User0 Name0"), null);
//            var result = controller.Index(fakeUser) as ViewResult;
//            var itemIndexViewModels = (List<ItemCreateViewModel>) result.ViewData.Model;
//            var onlyItem = itemIndexViewModels.First();

//            // Assert
//            Assert.Equal(1, itemIndexViewModels.Count());
//            Assert.True(onlyItem.Name == "item0");
//        }

//        [Fact]
//        public void IndexControlShouldMapViewModelCorrectly()
//        {
//            // Arrange
//            InitFakeDbContext();
//            var controller = new ItemsController(_fakeDbContext);

//            // Act
//            IPrincipal fakeUser = new GenericPrincipal(new FakeClaimIdentity("0", "User0 Name0"), null);
//            var userId = fakeUser.Identity.GetUserId();
//            var result = controller.Index(fakeUser) as ViewResult;
//            var itemIndexViewModels = (List<ItemCreateViewModel>) result.ViewData.Model;
//            var onlyItem = itemIndexViewModels.First();

//            // Assert
//            Assert.True(onlyItem.Name == "item0");
//            Assert.True(onlyItem.ItemId == 0);
//            Assert.True(onlyItem.Descrption == "good one");
//        }
//    }
//}