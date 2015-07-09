using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.XPath;
using DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models;
using DevRainSolutions.KyivSmartCity.New.Mailers;
using Microsoft.AspNet.Identity.Owin;

namespace DevRainSolutions.KyivSmartCity.New.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationSignInManager _signInManager;
        protected ApplicationUserManager _userManager;

        protected KyivSmartCityNewContext db = new KyivSmartCityNewContext();

        public int PerPage = 10;

        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            protected set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            protected set
            {
                _signInManager = value;
            }
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //  _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }

   
}