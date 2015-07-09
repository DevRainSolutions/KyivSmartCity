using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Controllers
{
    [Authorize(Users = "alex.krakovetskiy@gmail.com,asyzenko@yahoo.com,annakibitko@gmail.com")]
    public abstract class BaseAdminController : Controller
    {
    }
}
