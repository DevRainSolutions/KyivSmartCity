using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevRainSolutions.KyivSmartCity.New.Models;
using DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Controllers
{
    public class ExpertsController : BaseAdminController
    {
		private readonly IGroupRepository groupRepository;
		private readonly IExpertRepository expertRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ExpertsController() : this(new GroupRepository(), new ExpertRepository())
        {
        }

        public ExpertsController(IGroupRepository groupRepository, IExpertRepository expertRepository)
        {
			this.groupRepository = groupRepository;
			this.expertRepository = expertRepository;
        }

        //
        // GET: /Experts/

        public ViewResult Index()
        {
            return View(expertRepository.AllIncluding(expert => expert.Group));
        }

        //
        // GET: /Experts/Details/5

        public ViewResult Details(int id)
        {
            return View(expertRepository.Find(id));
        }

        //
        // GET: /Experts/Create

        public ActionResult Create()
        {
			ViewBag.PossibleGroups = groupRepository.All;
            return View();
        } 

        //
        // POST: /Experts/Create

        [HttpPost]
        public ActionResult Create(Expert expert)
        {
            if (ModelState.IsValid) {
                expertRepository.InsertOrUpdate(expert);
                expertRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleGroups = groupRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Experts/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleGroups = groupRepository.All;
             return View(expertRepository.Find(id));
        }

        //
        // POST: /Experts/Edit/5

        [HttpPost]
        public ActionResult Edit(Expert expert)
        {
            if (ModelState.IsValid) {
                expertRepository.InsertOrUpdate(expert);
                expertRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleGroups = groupRepository.All;
				return View();
			}
        }

        //
        // GET: /Experts/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(expertRepository.Find(id));
        }

        //
        // POST: /Experts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            expertRepository.Delete(id);
            expertRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                groupRepository.Dispose();
                expertRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

