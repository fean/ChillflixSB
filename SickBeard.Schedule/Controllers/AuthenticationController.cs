using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SickBeard.Schedule.Models;

namespace SickBeard.Schedule.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login(String returnUrl)
        {
            return View(new LoginModel() { ReturnUrl = returnUrl });
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Login");
        }

        [Authorize]
        public ActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.Username, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.Remember);
                return string.IsNullOrEmpty(model.ReturnUrl) ? Redirect("/Schedule") : Redirect(model.ReturnUrl);
            }

            if (ModelState.IsValid) ModelState.AddModelError("", "The combination of username and password is incorrect.");
            model.Password = string.Empty;
            return View(model);
        }

    }
}
