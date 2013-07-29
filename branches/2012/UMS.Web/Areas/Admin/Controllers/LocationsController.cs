using System;
using System.Data;
using System.Web.Mvc;
using UMS.Core.Data.Models.App;
using UMS.Core.Data.Repository;

namespace UMS.Web.Areas.Admin.Controllers
{
    public class LocationsController : Controller
    {
        private readonly LocationRepository _repo = new LocationRepository();

        //
        // GET: /Locations/

        public ActionResult Index()
        {
            return View(_repo.All);
        }

        //
        // GET: /Locations/Details

        public ActionResult Details(Guid? id)
        {
            return id.HasValue ? View(_repo.Find(id.Value)) : View();
        }

        //
        // POST: /Locations/Details

        [HttpPost]
        public ActionResult Details(Location location)
        {
            try
            {
                ModelState["LocationId"].Errors.Clear();
                ModelState["IsEnabled"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    _repo.InsertOrUpdate(location);
                    _repo.Save();

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("dataError", ex);
                return View();
            }
        }
    }
}
