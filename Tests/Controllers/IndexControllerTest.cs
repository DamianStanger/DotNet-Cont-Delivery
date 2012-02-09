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

            var view = ic.Index();

            Assert.That(view.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void IndexShouldReturnZero()
        {
            var ic = new IndexController();

            var view =  ic.Index();

            Assert.That(view.Model, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnZeroForEmptyString()
        {
            var ic = new IndexController();

            var view = ic.StringAdd(null);
            Assert.That(view.Model, Is.EqualTo(0));

            view = ic.StringAdd("");
            Assert.That(view.Model, Is.EqualTo(0));
        }
    }
}