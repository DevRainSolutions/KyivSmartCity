using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevRainSolutions.KyivSmartCity.New.Controllers
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