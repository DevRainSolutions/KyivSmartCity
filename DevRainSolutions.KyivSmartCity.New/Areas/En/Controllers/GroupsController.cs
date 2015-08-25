using System.Linq;
using System.Web.Mvc;
using DevRainSolutions.KyivSmartCity.New.Controllers;
using DevRainSolutions.KyivSmartCity.New.Models;

namespace DevRainSolutions.KyivSmartCity.New.Areas.En.Controllers
{
    public class GroupsController :BaseController
    {
        public ActionResult Index()
        {
            return View(new EnDataSource().GetGroups());
        }

        public ActionResult Details(int id)
        {
            return View(new EnDataSource().GetGroups().First(i=>i.Id == id));
        }

    
    }
}