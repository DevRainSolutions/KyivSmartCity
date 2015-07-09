using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevRainSolutions.KyivSmartCity.New.Models;
using DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Controllers
{
    public class NewsItemsController : BaseAdminController
    {
		private readonly INewsItemRepository newsitemRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public NewsItemsController() : this(new NewsItemRepository())
        {
        }

        public NewsItemsController(INewsItemRepository newsitemRepository)
        {
			this.newsitemRepository = newsitemRepository;
        }

        //
        // GET: /NewsItems/

        public ViewResult Index()
        {
            return View(newsitemRepository.All);
        }

        //
        // GET: /NewsItems/Details/5

        public ViewResult Details(int id)
        {
            return View(newsitemRepository.Find(id));
        }

        //
        // GET: /NewsItems/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /NewsItems/Create

        [HttpPost]
        public ActionResult Create(NewsItem newsitem)
        {
            if (ModelState.IsValid) {
                newsitemRepository.InsertOrUpdate(newsitem);
                newsitemRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /NewsItems/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(newsitemRepository.Find(id));
        }

        //
        // POST: /NewsItems/Edit/5

        [HttpPost]
        public ActionResult Edit(NewsItem newsitem)
        {
            if (ModelState.IsValid) {
                newsitemRepository.InsertOrUpdate(newsitem);
                newsitemRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /NewsItems/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(newsitemRepository.Find(id));
        }

        //
        // POST: /NewsItems/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            newsitemRepository.Delete(id);
            newsitemRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                newsitemRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

