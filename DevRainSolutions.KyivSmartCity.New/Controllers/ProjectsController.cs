using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DevRainSolutions.KyivSmartCity.New.Controllers
{
    public class ProjectsController : BaseController
    {
        // GET: News
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            return View(db.Projects.ToList()
                .ToPagedList(pageNumber, 12));
        }

        public ActionResult Details(int id)
        {
            return View(db.Projects.ToList().FirstOrDefault(i => i.Id == id));
        }
    }
}