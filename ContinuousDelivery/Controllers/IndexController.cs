using System.Web.Mvc;
using ContinuousDelivery.Models;
using ContinuousDelivery.Services;
using ContinuousDelivery.ViewModels;

namespace ContinuousDelivery.Controllers
{
    public class IndexController : Controller
    {
        private StringCalculator stringCalculator;

        public IndexController(StringCalculator stringCalculator)
        {
            this.stringCalculator = stringCalculator;
        }

        public IndexController() : this(new StringCalculator()){}

        public ViewResult Index()
        {
            return View("Index", new IndexViewModel());
        }

        public ViewResult StringAdd(string values)
        {
            IndexViewException returnedException = null;

            int result = 0;
            try
            {
                result = stringCalculator.PerformAddition(values);
            }
            catch (IndexViewException e)
            {
                returnedException = e;
            }

            var indexViewmodel = new IndexViewModel(result, returnedException);
            return View("Index", indexViewmodel);
        }
    }
}
