using System.Web.Mvc;

namespace ZachAlbertCodingExercise.Domain
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
