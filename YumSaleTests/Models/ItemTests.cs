using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumSale.Models;
using Xunit;
namespace YumSale.Models.Tests
{
    public class ItemTests
    {
        [Fact()]
        public void ItemShouldCleanBuyer()
        {
            // Arrange
            var item = new Item
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
            item.CleanBuyer();

            // Assert
            Assert.Equal(null, item.HoldTime);
            Assert.Equal(null, item.Buyer);
            Assert.Equal(null, item.BuyerId); 
        }
    }
}
