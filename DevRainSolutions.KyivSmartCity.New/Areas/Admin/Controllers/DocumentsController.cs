using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using DevRainSolutions.KyivSmartCity.New.Models;
using DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models;
using PagedList;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Controllers
{   
    public class DocumentsController : BaseAdminController
    {
		private readonly IGroupRepository groupRepository;
		private readonly IDocumentRepository documentRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public DocumentsController() : this(new GroupRepository(), new DocumentRepository())
        {
        }

        public DocumentsController(IGroupRepository groupRepository, IDocumentRepository documentRepository)
        {
			this.groupRepository = groupRepository;
			this.documentRepository = documentRepository;
        }

        //
        // GET: /Documents/

        public ViewResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            return View(documentRepository.AllIncluding(document => document.Group)
                .OrderBy(i=>i.Title)
                .ToPagedList(pageNumber, 10));
        }

        //
        // GET: /Documents/Details/5

        public ViewResult Details(int id)
        {
            return View(documentRepository.Find(id));
        }

        //
        // GET: /Documents/Create

        public ActionResult Create()
        {
			ViewBag.PossibleGroups = groupRepository.All;
            return View();
        } 

        //
        // POST: /Documents/Create

        [HttpPost]
        public ActionResult Create(Document document)
        {
            if (ModelState.IsValid) {
                documentRepository.InsertOrUpdate(document);
                documentRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleGroups = groupRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Documents/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleGroups = groupRepository.All;
             return View(documentRepository.Find(id));
        }

        //
        // POST: /Documents/Edit/5

        [HttpPost]
        public ActionResult Edit(Document document)
        {
            if (ModelState.IsValid) {
                documentRepository.InsertOrUpdate(document);
                documentRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleGroups = groupRepository.All;
				return View();
			}
        }

        //
        // GET: /Documents/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(documentRepository.Find(id));
        }

        //
        // POST: /Documents/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            documentRepository.Delete(id);
            documentRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                groupRepository.Dispose();
                documentRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

