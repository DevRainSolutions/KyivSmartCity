using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using DevRainSolutions.KyivSmartCity.New.App_GlobalResources;
using DevRainSolutions.KyivSmartCity.New.Controllers;
using DevRainSolutions.KyivSmartCity.New.Models;

namespace DevRainSolutions.KyivSmartCity.New.Areas.En.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(new EnDataSource().GetGroups());
        }

        public ActionResult Hackathon()
        {
            return View();
        }
    }
}