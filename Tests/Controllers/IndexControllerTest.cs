using ContinuousDelivery.ViewModels;
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

            var model = (IndexViewModel) view.Model;
            Assert.That(model.Result, Is.EqualTo(0));
            Assert.That(model.Exception, Is.Null);
        }

        [Test]
        public void ShouldReturnZeroForEmptyString()
        {
            string nullString = null;
            nullString.ShouldAddUpTo(0);
            string.Empty.ShouldAddUpTo(0);
        }

        [Test]
        public void GivenOneNumberReturnThatNumber()
        {
            "7".ShouldAddUpTo(7);
        }

        [Test]
        public void twoCommaSeparatedNumbersAddUp()
        {
            "5,3".ShouldAddUpTo(8);
        }

        [Test]
        public void newlineSeparatedNumbersAreSupported()
        {
            "5\n3".ShouldAddUpTo(8);
        }

        [Test]
        public void FiveCommaSeparatedNumbersAddUp()
        {
            "5,3,10,100,1".ShouldAddUpTo(119);
        }

        [Test]
        public void shouldAllowForChangeInDelimeter()
        {
            "//;\n9;3".ShouldAddUpTo(12);
        }

        [Test]
        public void shouldAllowForMixedDelimetersNewAndDefault()
        {
            "//#\n9,3,1#100#2000\n50".ShouldAddUpTo(2163);
        }

        [Test]
        public void shouldFlagNegativeNumbersAsInvalidAndReturnZero()
        {
            var model = "-10".ShouldAddUpTo(0);
            Assert.That(model.Exception.Message, Is.EqualTo("Negative numbers are not permitted: -10"));
        }

        [Test]
        public void shouldFlagNegativeNumbersAsInvalidAndReturnAllOffendingNumbers()
        {
            var model = "-1,-2".ShouldAddUpTo(0);
            Assert.That(model.Exception.Message, Is.EqualTo("Negative numbers are not permitted: -1, -2"));
        }

        [Test]
        public void shouldFlagNegativeNumbersAsInvalidAndReturnAllOffendingNumbersButNotPositiveNumbers()
        {
            var model = "-1,2,-3".ShouldAddUpTo(0);
            Assert.That(model.Exception.Message, Is.EqualTo("Negative numbers are not permitted: -1, -3"));
        }
    }

    internal static class TestHelper
    {
        internal static IndexViewModel ShouldAddUpTo(this string values, int expected)
        {
            var ic = new IndexController();

            var view = ic.StringAdd(values);
            var model = (IndexViewModel) view.Model;
            Assert.That(model.Result, Is.EqualTo(expected));
            return model;
        }
    }
}