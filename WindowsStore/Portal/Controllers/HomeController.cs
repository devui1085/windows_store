using System.Web.Mvc;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult DownloadAndInstallationHelp()
        {
            ViewBag.Message = "Help page";
            return View();
        }
    }
}