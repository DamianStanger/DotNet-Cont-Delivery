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

            if (!string.IsNullOrEmpty(values))
            {
                string[] individualValues = values.Split(',');
                foreach (var value in individualValues)
                {
                    int tmp;
                    bool valuesContainsAnInteger = int.TryParse(value, out tmp);
                    if (valuesContainsAnInteger)
                    {
                        result += tmp;
                    }
                }
            }

            return View("Index", result);
        }
    }
}
