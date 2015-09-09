using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevRainSolutions.KyivSmartCity.New.Models;
using DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models;
using PagedList;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Controllers
{
    public class ProjectsController : BaseAdminController
    {
        private readonly IProjectRepository repository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ProjectsController() : this(new ProjectRepository())
        {
        }

        public ProjectsController(IProjectRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Groups/

        public ViewResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            return View(repository.All.OrderBy(i => i.Title)
                .ToPagedList(pageNumber, 10));
        }

        //
        // GET: /Groups/Details/5

        public ViewResult Details(int id)
        {
            return View(repository.Find(id));
        }

        //
        // GET: /Groups/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Groups/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid) {
                repository.InsertOrUpdate(project);
                repository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Groups/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(repository.Find(id));
        }

        //
        // POST: /Groups/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid) {
                repository.InsertOrUpdate(project);
                repository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Groups/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(repository.Find(id));
        }

        //
        // POST: /Groups/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            repository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

