using System.Web.Mvc;

namespace ContinuousDelivery.Controllers
{
    public class IndexController : Controller
    {

        public ViewResult Index()
        {
            return View("Index", 0);
        }

        public ViewResult StringAdd(string values)
        {
            int result = 0;
            return View("Index", result);
        }
    }
}
