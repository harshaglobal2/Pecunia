using Inventory.Mvc.Identity;
using Inventory.Mvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Mvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //Get User Manager from Identity
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

                //Get Authentication Manager from Identity
                var authManager = HttpContext.GetOwinContext().Authentication;

                //Get User from Identity based on Email and Password
                ApplicationUser user = userManager.Find(loginViewModel.Email, loginViewModel.Password);
                if (user != null)
                {
                    //Create identity based on existing user for signin
                    var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //User signs-in here
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                    return RedirectToAction("Index", "Home");
                }
            }

            //If validation fails
            ModelState.AddModelError("", "Invalid email or password");
            return View(loginViewModel);
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                //Get User Manager from Identity
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

                //Get Authentication Manager from Identity
                var authManager = HttpContext.GetOwinContext().Authentication;

                //Create new ApplicationUser object with details
                ApplicationUser user = new ApplicationUser() {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email,
                    Role = "Admin"
                };

                //Call Create method of UserManager (BL)
                var chkUser = userManager.Create(user, registerViewModel.Password);

                //If user created successfully
                if (chkUser.Succeeded)
                {
                    //Create identity based on existing user for signin
                    var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //User signs-in here
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                    return RedirectToAction("Index", "Home");
                }
            }

            //If validation fails
            ModelState.AddModelError("", "Invalid email or password");
            return View(registerViewModel);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            //Get Authentication Manager from Identity
            var authManager = HttpContext.GetOwinContext().Authentication;

            //User signs-out here
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}



