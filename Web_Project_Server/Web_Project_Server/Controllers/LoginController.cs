using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Project_Server.Models;

namespace Web_Project_Server.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel verifyUser)
        {
            ElectionCatalog db = new ElectionCatalog();
            User user = new User();

            switch (verifyUser.UserType)
            {
                case "Voter":
                    user = db.Users.Find(verifyUser.UserName);
                    break;
                case "Candidate":
                    user = db.Users.Find(verifyUser.UserName);
                    break;
                case "Admin":
                    user = db.Users.Find(verifyUser.UserName);
                    break;
            }
            if (user.Password == verifyUser.Password && user != null)
            {
                Session.Add("UserName", user.UserName);
                Session["LoginStage"] = 1;
                Session.Timeout = 5;
                ViewBag.IsValidLogIn = true;
				if (user.UserType == "Voter")
					return RedirectToAction("Index", "VoterHome");
				else if (user.UserType == "Candidate")
					return RedirectToAction("Index", "CandidateHome");
				else
					return RedirectToAction("Index", "Admin");
			}
            else
            {
                ViewBag.IsValidLogIn = false;
                return RedirectToAction("Index", "Login");
            }

        }

    }
}