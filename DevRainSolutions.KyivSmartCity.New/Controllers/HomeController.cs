using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DevRainSolutions.KyivSmartCity.New.App_GlobalResources;
using DevRainSolutions.KyivSmartCity.New.Mailers;
using DevRainSolutions.KyivSmartCity.New.Models;
using Newtonsoft.Json;

namespace DevRainSolutions.KyivSmartCity.New.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

     
        public ActionResult Thanks()
        {
            return View();
        }

        public ActionResult Session2020()
        {
            return View();
        }


        public ActionResult Forum2015()
        {
            return View();
        }

        public ActionResult Join()
        {
            ViewBag.PossibleGroups = db.Groups.ToList();
            return View();

        }
        

        [HttpPost]
        //[SpamProtection]
        public async Task<ActionResult> Join(Volunteer model)
        {
            model.RegistrationDate = DateTime.Now;

            string encodedResponse = Request.Form["g-Recaptcha-Response"];
            bool isCaptchaValid = (ReCaptchaClass.Validate(encodedResponse) == "True");

            if (!isCaptchaValid)
            {
                ModelState.AddModelError("captcha", "Ви не пройшли перевірку, спробуйте ще раз.");
                ViewBag.PossibleGroups = db.Groups.ToList();
                return View(model);
            }


            if (ModelState.IsValid)
            {
                var count = db.Volunteers.Count(i => i.Email.Equals(model.Email, StringComparison.InvariantCultureIgnoreCase));

                if (count > 0)
                {
                    ViewBag.PossibleGroups = db.Groups.ToList();
                    ModelState.AddModelError("Email", ValidationResources.VolunteerExists);
                    return View(model);
                }

                db.Volunteers.Add(model);
                db.SaveChanges();

                await UserMailer.Welcome(model.Email).SendAsync(); 

                return RedirectToAction("Thanks");
            }

            ViewBag.PossibleGroups = db.Groups.ToList();
            return View(model);
        }

    }
}