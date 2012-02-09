using System.Web.Mvc;
using NUnit.Framework;
using ContinuousDelivery.Controllers;

namespace Tests.Controllers
{
    [TestFixture]
    public class IndexControllerTest
    {
        [Test]
        public void ShouldReturnTheIndexView()
        {
            var ic = new IndexController();

            var view = (ViewResult) ic.Index();

            Assert.That(view.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void ShouldFail()
        {
            var ic = new IndexController();

            var view = ic.Index();

            Assert.True(false);
        }
    }
}