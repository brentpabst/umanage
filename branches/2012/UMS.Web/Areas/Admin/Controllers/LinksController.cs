using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using UMS.Core.Data.Models.App;
using UMS.Core.Data.Repository;

namespace UMS.Web.Areas.Admin.Controllers
{
    public class LinksController : Controller
    {
        private readonly QuickLinkRepository _repo = new QuickLinkRepository();

        //
        // GET: /Admin/Links/

        public ActionResult Index()
        {
            return View(_repo.All.OrderBy(l => l.DisplayOrder));
        }

        public ActionResult Details(Guid? id)
        {
            return id.HasValue ? View(_repo.Find(id.Value)) : View();
        }

        [HttpPost]
        public ActionResult Details(QuickLink link)
        {
            try
            {
                ModelState["LinkId"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    _repo.InsertOrUpdate(link);
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

        public ActionResult Delete(Guid id)
        {
            try
            {
                _repo.Delete(id);
                _repo.Save();

                return RedirectToAction("Index");
            }
            catch (DataException ex)
            {
                // Log the error
                return RedirectToAction("Index");
            }
        }
    }
}
