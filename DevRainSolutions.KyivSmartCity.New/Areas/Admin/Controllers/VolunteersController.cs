using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using DevRainSolutions.KyivSmartCity.New.Models;
using DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models;
using PagedList;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Controllers
{
    public class VolunteersController : BaseAdminController
    {
        private readonly IGroupRepository groupRepository;
        private readonly IVolunteerRepository volunteerRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public VolunteersController()
            : this(new GroupRepository(), new VolunteerRepository())
        {
        }

        public VolunteersController(IGroupRepository groupRepository, IVolunteerRepository volunteerRepository)
        {
            this.groupRepository = groupRepository;
            this.volunteerRepository = volunteerRepository;
        }

        //
        // GET: /Volunteers/

        public ViewResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            return View(volunteerRepository.AllIncluding(volunteer => volunteer.Group)
                .OrderByDescending(i=>i.RegistrationDate)
                .ToPagedList(pageNumber, 10));
        }

        //
        // GET: /Volunteers/Details/5

        public ViewResult Details(int id)
        {
            return View(volunteerRepository.Find(id));
        }

        //
        // GET: /Volunteers/Create

        public ActionResult Create()
        {
            ViewBag.PossibleGroups = groupRepository.All;
            return View();
        }

        //
        // POST: /Volunteers/Create

        [HttpPost]
        public ActionResult Create(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                volunteerRepository.InsertOrUpdate(volunteer);
                volunteerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.PossibleGroups = groupRepository.All;
                return View();
            }
        }

        //
        // GET: /Volunteers/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.PossibleGroups = groupRepository.All;
            return View(volunteerRepository.Find(id));
        }

        //
        // POST: /Volunteers/Edit/5

        [HttpPost]
        public ActionResult Edit(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                volunteerRepository.InsertOrUpdate(volunteer);
                volunteerRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.PossibleGroups = groupRepository.All;
                return View();
            }
        }

        //
        // GET: /Volunteers/Delete/5

        public ActionResult Delete(int id)
        {
            return View(volunteerRepository.Find(id));
        }

        //
        // POST: /Volunteers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            volunteerRepository.Delete(id);
            volunteerRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                groupRepository.Dispose();
                volunteerRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Export()
        {
            var grid = new System.Web.UI.WebControls.GridView
            {
                DataSource = this.volunteerRepository.All.ToList()
            };

            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=KiyvSmartCity_Volunteers.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());


            Response.End();
            return null;
        }
    }
}

