
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
            return View(db.Groups.Find(id));
        }

    
    }
}