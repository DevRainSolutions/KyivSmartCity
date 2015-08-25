using System.Linq;
using System.Web.Mvc;
using DevRainSolutions.KyivSmartCity.New.Controllers;

namespace DevRainSolutions.KyivSmartCity.New.Areas.En.Controllers
{
    public class TeamController : BaseController
    {
        // GET: Team
        public ActionResult Index()
        {
            return View(db.TeamMembers.OrderBy(i=>i.Index));
        }
    }
}