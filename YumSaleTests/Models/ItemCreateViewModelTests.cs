using System;
using Xunit;

namespace YumSale.Models.Tests
{
    public class ItemCreateViewModelTests
    {
        [Fact]
        public void ToItemTest()
        {
            // Arrange
            var toMapToItem = new ItemCreateViewModel
            {
                ItemId = 1,
                Name = "coffee machine",
                Descrption = "pretty good",
                ImageUrl = "http://www.123.com",
                HoldLongDay = 3,
                HoldLongHour = 1
            };

            // Act
            var item = toMapToItem.ToItem();

            // Assert
            Assert.Equal(1, item.ItemId);
            Assert.Equal("pretty good", item.Descrption);
            Assert.Equal("http://www.123.com", item.ImageUrl);
            Assert.Equal(3, item.HoldLongDay);
            Assert.Equal(null, item.Buyer);
            Assert.Equal(null, item.BuyerId);
            Assert.Equal(null, item.HoldTime);
            Assert.Equal(new TimeSpan(0, 1, 0, 0), item.HoldLongLessThanDay);
        }
    }
}