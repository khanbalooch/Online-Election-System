using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Project_Server.Models;

namespace Web_Project_Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			//if (Session["UserName"] == null)
			//{
			//	return RedirectToAction("Index", "Login");
			//}
			//ElectionCatalog db = new ElectionCatalog();
			//User admin = new User();
			//admin.UserName = "Admin1234";
			//admin.UserType = "Admin";
			//admin.PicPath = "somePath";
			//admin.CNIC = "36203-4943177-5";
			//admin.Education = "PHD";
			//admin.Gender = "Male";
			//admin.City = "Islambad";
			//admin.Age = 25;
			//admin.Password = "Admin1234";
			//admin.Name = "OnlineElection";
			//db.Users.Add(admin);
			//db.SaveChanges();
			return View();
        }

        public ActionResult About()
        {
			//if (Session["UserName"] == null)
			//{
			//	return RedirectToAction("Index", "Login");
			//}
			ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
			//if (Session["UserName"] == null)
			//{
			//	return RedirectToAction("Index", "Login");
			//}
			ViewBag.Message = "Your contact page.";

            return View();
        }
		public ActionResult LogOff()
		{

			//if (Session["UserName"] == null)
			//{
			//	return RedirectToAction("Index", "Login");
			//}
			//Session["UserName"];
			//return RedirectToAction("Index", "Login");

			ViewBag.Message = "Log Out.";
			Session.Clear();
			return RedirectToAction("Index", "Login");
			//return View();
		}
	}
}