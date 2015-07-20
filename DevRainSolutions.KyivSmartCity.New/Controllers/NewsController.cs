using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DevRainSolutions.KyivSmartCity.New.Controllers
{
    public class NewsController : BaseController
    {
        // GET: News
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            return View(db.NewsItems.OrderByDescending(i=>i.DatePublished)
                .ToPagedList(pageNumber, PerPage));
        }

        public ActionResult Details(int id)
        {
            return View(db.NewsItems.ToList().FirstOrDefault(i => i.Id == id && i.IsPublished));
        }
    }
}