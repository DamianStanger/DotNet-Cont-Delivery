using NUnit.Framework;
using ContinuousDelivery.Controllers;

namespace Tests.Controllers
{
    [TestFixture]
    public class IndexControllerTest
    {
        [Test]
        public void ShouldReturnTrue()
        {
            var ic = new IndexController();

            var view = ic.Index();

            Assert.True(true);
        }

        [Test]
        public void ShouldFailNot()
        {
            var ic = new IndexController();

            var view = ic.Index();

            Assert.True(true);
        }
    }
}