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
    public class TeamMembersController : BaseAdminController
    {
		private readonly ITeamMemberRepository teammemberRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TeamMembersController() : this(new TeamMemberRepository())
        {
        }

        public TeamMembersController(ITeamMemberRepository teammemberRepository)
        {
			this.teammemberRepository = teammemberRepository;
        }

        //
        // GET: /TeamMembers/

        public ViewResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            return View(teammemberRepository.All.OrderBy(i=>i.Name)
                .ToPagedList(pageNumber, 10));
        }

        //
        // GET: /TeamMembers/Details/5

        public ViewResult Details(int id)
        {
            return View(teammemberRepository.Find(id));
        }

        //
        // GET: /TeamMembers/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TeamMembers/Create

        [HttpPost]
        public ActionResult Create(TeamMember teammember)
        {
            if (ModelState.IsValid) {
                teammemberRepository.InsertOrUpdate(teammember);
                teammemberRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /TeamMembers/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(teammemberRepository.Find(id));
        }

        //
        // POST: /TeamMembers/Edit/5

        [HttpPost]
        public ActionResult Edit(TeamMember teammember)
        {
            if (ModelState.IsValid) {
                teammemberRepository.InsertOrUpdate(teammember);
                teammemberRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /TeamMembers/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(teammemberRepository.Find(id));
        }

        //
        // POST: /TeamMembers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            teammemberRepository.Delete(id);
            teammemberRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                teammemberRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

