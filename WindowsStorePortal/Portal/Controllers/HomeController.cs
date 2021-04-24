using System;
using System.Web.Mvc;
using Store.Portal.Models;
using Store.Portal.ViewModel;

namespace Store.Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PortalServiceProxy proxy = new PortalServiceProxy();

            var viewModel = new IndexPageViewModel()
            {
                MostPopularApps = proxy.GetMostPopularApps(),
                SpecialApps = proxy.GetSpecialApps(),
                ChosenApps = proxy.GetChosenApps(),
                NewApps = proxy.GetNewApps(),
                RisingApps = proxy.GetNewApps(),
                SpecialGames = proxy.GetSpecialGames()
            };
            return PartialView(viewModel);
        }

        public ActionResult AppDetails()
        {
            return PartialView();
        }

        public ActionResult GetIcon128(Guid? id)
        {
            if (!id.HasValue)
                return File(Url.Content("~/Content/Image/none.jpg"), "image/jpeg");

            PortalServiceProxy proxy = new PortalServiceProxy();

            ActionResult result;
            byte[] image;

            try
            {
                image = proxy.GetApp128Icon(id.Value);
            }
            catch
            {
                image = null;
            }

            if (image != null)
            {
                result = new FileContentResult(image, "image/jpeg");
            }
            else
            {
                result = File(Url.Content("~/Content/Image/none.jpg"), "image/jpeg");
            }

            return result;
        }

        [AllowAnonymous]
        public ActionResult GetIcon256(Guid? id)
        {
            if (!id.HasValue)
                return File(Url.Content("~/Content/Image/none.jpg"), "image/jpeg");

            PortalServiceProxy proxy = new PortalServiceProxy();

            ActionResult result;
            byte[] image;

            try
            {
                image = proxy.GetApp256Icon(id.Value);
            }
            catch
            {
                image = null;
            }

            if (image != null)
            {
                result = new FileContentResult(image, "image/jpeg");
            }
            else
            {
                result = File(Url.Content("~/Content/Image/none.jpg"), "image/jpeg");
            }

            return result;
        }
    }
}