﻿using System.Web.Mvc;
using System.Web.Security;
using ASP_MVC_2.Models.EntityManager;
using ASP_MVC_2.Models.ViewModel;

namespace ASP_MVC_2.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public ActionResult SignOut() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogIn() {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl){
            if (ModelState.IsValid) {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else {
                    if (ULV.Password.Equals(password)) {
                        FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                        return RedirectToAction("Welcome", "Home");
                    }
                    else {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            } // If we got this far, something failed, redisplay form 
            return View(ULV);
        }
        // GET: Account
    public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUpView USV)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName))
                {
                    UM.AddUserAccount(USV);
                    FormsAuthentication.SetAuthCookie(USV.FirstName, false);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Name already taken.");
                }
            }
            return View();
        }

        public ActionResult AddOutbond()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Outbond(OutbondView OV)
        {
            if (ModelState.IsValid)
            {
                OutbondManager OM = new OutbondManager();
                
                    OM.AddOutbond(OV);
                    return RedirectToAction("Welcome", "Home");
                
            }
            return View();
        }
    }
}