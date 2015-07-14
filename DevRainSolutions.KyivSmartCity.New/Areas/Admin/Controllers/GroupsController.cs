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
    public class GroupsController : BaseAdminController
    {
		private readonly ITeamMemberRepository teammemberRepository;
		private readonly IGroupRepository groupRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public GroupsController() : this(new TeamMemberRepository(), new GroupRepository())
        {
        }

        public GroupsController(ITeamMemberRepository teammemberRepository, IGroupRepository groupRepository)
        {
			this.teammemberRepository = teammemberRepository;
			this.groupRepository = groupRepository;
        }

        //
        // GET: /Groups/

        public ViewResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            return View(groupRepository.AllIncluding(group => group.Experts, group => group.Documents, group => group.TeamMember) .OrderBy(i=>i.Title)
                .ToPagedList(pageNumber, 10));
        }

        //
        // GET: /Groups/Details/5

        public ViewResult Details(int id)
        {
            return View(groupRepository.Find(id));
        }

        //
        // GET: /Groups/Create

        public ActionResult Create()
        {
			ViewBag.PossibleTeamMembers = teammemberRepository.All;
            return View();
        } 

        //
        // POST: /Groups/Create

        [HttpPost]
        public ActionResult Create(Group group)
        {
            if (ModelState.IsValid) {
                groupRepository.InsertOrUpdate(group);
                groupRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTeamMembers = teammemberRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Groups/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleTeamMembers = teammemberRepository.All;
             return View(groupRepository.Find(id));
        }

        //
        // POST: /Groups/Edit/5

        [HttpPost]
        public ActionResult Edit(Group group)
        {
            if (ModelState.IsValid) {
                groupRepository.InsertOrUpdate(group);
                groupRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTeamMembers = teammemberRepository.All;
				return View();
			}
        }

        //
        // GET: /Groups/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(groupRepository.Find(id));
        }

        //
        // POST: /Groups/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            groupRepository.Delete(id);
            groupRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                teammemberRepository.Dispose();
                groupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

