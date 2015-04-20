using System;
using System.Collections.Generic;
using Xunit;

namespace YumSale.Models.Tests
{
    public class BuyHoldViewModelsTests
    {
        [Fact]
        public void BuyHoldViewModelShouldLoadOneItem()
        {
            // Arrange
            var itemToMap = new Item
            {
                Buyer = null,
                BuyerId = null,
                CreateDateTime = new DateTime(2012, 12, 12, 1, 0, 0),
                Descrption = "good one",
                HoldLongDay = 3,
                HoldLongLessThanDay = new TimeSpan(0, 1, 0, 0),
                ImageUrl = "http://www.123.com",
                HoldTime = null,
                ItemId = 3,
                Name = "coffee machine"
            };

            // Act
            var holdViewModel = new BuyHoldViewModel(itemToMap);

            // Assert
            Assert.Equal(null, holdViewModel.BuyerName);
            Assert.Equal("good one", holdViewModel.Descrption);
            Assert.Equal(3, holdViewModel.HoldLongDay);
            Assert.Equal(new TimeSpan(0, 1, 0, 0), holdViewModel.HoldLongLessThanDay);
            Assert.Equal("http://www.123.com", holdViewModel.ImageUrl);
            Assert.Equal("coffee machine", holdViewModel.Name);
            Assert.Equal(3, holdViewModel.ItemId);
        }

        [Fact]
        public void BuyHoldViewModelShoudThrowErrorIfBuyerIsNotNull()
        {
            // Arrange
            var itemToMap = new Item
            {
                Buyer = new Buyer
                {
                    BuyerId = 1,
                    Contact = "123",
                    Name = "Anna",
                    Token = "Would you kindly"
                },
                BuyerId = 1,
                CreateDateTime = new DateTime(2012, 12, 12, 1, 0, 0),
                Descrption = "good one",
                HoldLongDay = 3,
                HoldLongLessThanDay = new TimeSpan(0, 1, 0, 0),
                ImageUrl = "http://www.123.com",
                HoldTime = null,
                ItemId = 3,
                Name = "coffee machine"
            };

            // Assert
            Assert.Throws(typeof (SystemException),
                delegate { new BuyHoldViewModel(itemToMap); });
        }

        [Fact]
        public void BuyHoldViewModelShouldCreateBuyerOutOfIt()
        {
            var buyHoldViewModel = new BuyHoldViewModel
            {
                BuyerName = "Rosalind Lutece",
                Contact = "123-123-3212",
                Token = "Bring us the girl, and wipe away the debt",
                Descrption = "good one",
                HoldLongDay = 3,
                HoldLongLessThanDay = new TimeSpan(0, 1, 0, 0),
                ImageUrl = "http://www.123.com",
                ItemId = 3,
                Name = "coffee machine"
            };
            var resultBuyer = buyHoldViewModel.ToBuyer();
            Assert.Equal("123-123-3212", resultBuyer.Contact);
            Assert.Equal("Rosalind Lutece", resultBuyer.Name);
            Assert.Equal("Bring us the girl, and wipe away the debt", resultBuyer.Token);
        }

        [Fact]
        public void BuyHoldViewModelShouldConvertACollectionOfItems()
        {
            // Arrange
            var itemToMap = new Item
            {
                Buyer = null,
                BuyerId = null,
                CreateDateTime = new DateTime(2012, 12, 12, 1, 0, 0),
                Descrption = "good one",
                HoldLongDay = 3,
                HoldLongLessThanDay = new TimeSpan(0, 1, 0, 0),
                ImageUrl = "http://www.123.com",
                HoldTime = null,
                ItemId = 3,
                Name = "coffee machine"
            };
            var items = new List<Item> {itemToMap, itemToMap, itemToMap};

            // Act
            var viewModels = BuyHoldViewModel.MapItemsForIndexView(items);
            Assert.Equal(3, viewModels.Count);
            Assert.Equal("coffee machine", viewModels[0].Name);
        }
        [Fact]
        public void BuyHoldViewModelShouldConvertACollectionOfItemsWithoutTheOneWithBuyer()
        {
            // Arrange
            var itemToMap = new Item
            {
                Buyer = null,
                BuyerId = null,
                CreateDateTime = new DateTime(2012, 12, 12, 1, 0, 0),
                Descrption = "good one",
                HoldLongDay = 3,
                HoldLongLessThanDay = new TimeSpan(0, 1, 0, 0),
                ImageUrl = "http://www.123.com",
                HoldTime = null,
                ItemId = 3,
                Name = "coffee machine"
            };
            var itemToMapWithBuyer = new Item
            {
                Buyer = new Buyer(),
                BuyerId = 1,
                CreateDateTime = new DateTime(2012, 12, 12, 1, 0, 0),
                Descrption = "good one",
                HoldLongDay = 3,
                HoldLongLessThanDay = new TimeSpan(0, 1, 0, 0),
                ImageUrl = "http://www.123.com",
                HoldTime = null,
                ItemId = 3,
                Name = "coffee machine"
            };

            var items = new List<Item> {itemToMap, itemToMap, itemToMap, itemToMapWithBuyer};

            // Act
            var viewModels = BuyHoldViewModel.MapItemsForIndexView(items);
            Assert.Equal(3, viewModels.Count);
            Assert.Equal("coffee machine", viewModels[0].Name);
        }


    }
}