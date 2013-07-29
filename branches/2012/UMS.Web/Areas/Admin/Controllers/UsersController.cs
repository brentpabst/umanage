using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Core.Data.Repository;

namespace UMS.Web.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private UserRepository _repo = new UserRepository();
        private RoleRepository _roleRepo = new RoleRepository();

        //
        // GET: /Admin/Users/

        public ActionResult Index()
        {
            ViewData["CurrentUsers"] = _repo.AllIncluding(u => u.Roles);
            ViewData["Roles"] = _roleRepo.All.OrderBy(r => r.Name);
            return View();
        }

    }
}
