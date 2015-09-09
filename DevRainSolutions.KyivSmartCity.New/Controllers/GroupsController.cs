
using System.Linq;
using System.Web.Mvc;

namespace DevRainSolutions.KyivSmartCity.New.Controllers
{
    public class GroupsController :BaseController
    {
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        public ActionResult Details(int id)
        {
            var group = db.Groups.Find(id);
            return View(group);
        }

    
    }
}