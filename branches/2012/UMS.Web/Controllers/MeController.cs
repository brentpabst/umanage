using System.Web.Mvc;
using UMS.Core.Data.Models.Directory;

namespace UMS.Web.Controllers
{
    public class MeController : Controller
    {
        //
        // GET: /Me/
        public ActionResult Index()
        {
            return View(Session["User"] as User);
        }

        public ActionResult Account()
        {
            return View(Session["User"] as User);
        }

        public ActionResult Password()
        {
            ViewData["User"] = Session["User"] as User;
            return View();
        }

        public ActionResult Photo()
        {
            return View();
        }
    }
}
