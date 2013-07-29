using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Core.Data.Models.App;
using UMS.Core.Data.Repository;
using System.Data;

namespace UMS.Web.Areas.Admin.Controllers
{
    public class WallController : Controller
    {
        private WallPostRepository _repo = new WallPostRepository();

        //
        // GET: /Admin/Wall/

        public ActionResult Index()
        {
            return View(_repo.All.OrderByDescending(p => p.PublishDate));
        }

        public ActionResult Details(Guid? id)
        {
            return id.HasValue ? View(_repo.Find(id.Value)) : View();
        }

        [HttpPost]
        public ActionResult Details(WallPost post)
        {
            try
            {
                ModelState["PostId"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    _repo.InsertOrUpdate(post);
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
