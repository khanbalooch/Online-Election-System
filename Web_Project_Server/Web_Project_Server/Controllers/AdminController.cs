using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Project_Server.Models;

namespace Web_Project_Server.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
        }
		[HttpGet]
		public ActionResult ApproveCandidate()
		{
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}
			ElectionCatalog db = new ElectionCatalog();
			var notApproved = new List<User>();
			IQueryable<User> temp = from User in db.Users
							  where User.UserType == "Candidate" && User.isApproved == false
							  select User;
			notApproved = temp.ToList<User>();

			return View(notApproved);
		}

		[HttpGet]
		public ActionResult ApproveVoter()
		{
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}

			ElectionCatalog db = new ElectionCatalog();
			var notApproved = new List<User>();
			IQueryable<User> temp = from User in db.Users
									where User.UserType == "Voter" && User.isApproved == false
									select User;
			notApproved = temp.ToList<User>();

			return View(notApproved);
		}

		[HttpPost]
		public ActionResult Approve(List<User> notApproved)
		{
			ElectionCatalog db = new ElectionCatalog();
			var approved = from User in notApproved
						   where User.isApproved == true
						   select User;
			foreach (var item in approved)
			{
				db.Users.Find(item.UserName).isApproved = true;
			}
			db.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}