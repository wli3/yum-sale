using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumSale.Controllers;
using NUnit.Framework;
namespace YumSale.Controllers.Tests
{
    [TestFixture()]
    public class ItemsControllerTests
    {
        private string GoodName;
        [SetUp]
        public void InitFakeDbContext()
        {
            GoodName = "12387182381078124689dcf489xt6q3y489ufys3u8rsfy384tf8q73styf87";
        }

        [Test()]
        public void IndexTest()
        {
            Console.Write(GoodName);

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
