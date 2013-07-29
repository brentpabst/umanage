using System;
using System.Web.Mvc;
using UMS.Core.Data.Models.App;
using UMS.Core.Data.Repository;
using UMS.Core.Logic.Config;

namespace UMS.Web.Areas.Admin.Controllers
{
    public class OfficesController : Controller
    {
        private OfficeRepository _repo = new OfficeRepository();

        //
        // GET: /Admin/Offices/

        public ActionResult Index()
        {
            ViewData["Enable"] = Settings.Get<bool>("UseOfficeLocations");
            return View(_repo.All);
        }

        [HttpPost]
        public ActionResult Enable(bool enabled)
        {
            Settings.Put("UseOfficeLocations", enabled);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            var o = new Office { Name = name };
            _repo.InsertOrUpdate(o);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            _repo.Delete(id);
            _repo.Save();
            return RedirectToAction("Index");
        }

    }
}
