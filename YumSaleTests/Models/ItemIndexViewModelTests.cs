using System;
using Xunit;

namespace YumSale.Models.Tests
{
    public class ItemIndexViewModelTests
    {
        [Fact]
        public void ItemIndexViewModelShouldMapItemFieldNeeded()
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

            // Act
            var viewModel = new ItemIndexViewModel(itemToMap);

            // Assert
            Assert.Equal(new DateTime(2012, 12, 15, 2, 0, 0), viewModel.EndTime);
            Assert.Equal("Anna", viewModel.HolderName);
            Assert.Equal(3, viewModel.ItemId);
            Assert.Equal("coffee machine", viewModel.Name);
        }

        [Fact]
        public void ItemIndexViewModelNameShouldbeNullIfMapItemFieldSNameIsNull()
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
            var viewModel = new ItemIndexViewModel(itemToMap);

            // Assert
            Assert.Equal(new DateTime(2012, 12, 15, 2, 0, 0), viewModel.EndTime);
            Assert.Equal(null, viewModel.HolderName);
            Assert.Equal(3, viewModel.ItemId);
            Assert.Equal("coffee machine", viewModel.Name);
        }
    }
}