using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Project_Server.Models;

namespace Web_Project_Server.Controllers
{
	public class VoterHomeController : Controller
	{
		// GET: VoterHome
		public ActionResult Index()
		{
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}

		public ActionResult CastVote(string Level)
		{
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				Vote vote = new Vote();
				ViewBag.Level = Level;
				ElectionCatalog db = new ElectionCatalog();
				string city = db.Users.Find(Session["UserName"]).City.ToString();
				//IQueryable<Election> elections = from Election in db.Elections
				//								 where Election.City == city && Election.Level == Level
				//								 select Election;
				//List<Election> ele = elections.ToList<Election>();

				//var query = from Election in ele
				//			join can in db.CandidateApplications
				//			on new { Election.Level, Election.City } equals new { can.Level, can.City }
				//			select new { can.Candidate, can.Election_Id, can.City };
				List<Vote> Vote = new List<Vote>();
				var query = from i in db.CandidateApplications
						   where i.City == city && i.Level == Level
						   select i;
					
				foreach (var i in query)
				{
					Vote.Add(new Vote
					{

						Candidate = i.Candidate.ToString(),
						Date = DateTime.Now,
						ElectionCity = i.City.ToString(),
						ElectionID = i.Election_Id.ToString(),
						Voter = Session["UserName"].ToString()
					});
				}

				return View(Vote);
			}

		}
		[HttpPost]
		public ActionResult CastVoteTo(Vote vote)
		{


			
			ElectionCatalog db = new ElectionCatalog();
			db.Votes.Add(vote);
			db.SaveChanges();
			return View();
		}
	}
}