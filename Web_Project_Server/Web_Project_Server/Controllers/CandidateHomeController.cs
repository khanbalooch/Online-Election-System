using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Project_Server.Models;

namespace Web_Project_Server.Controllers
{
    public class CandidateHomeController : Controller
    {
        // GET: CandidateHome
        public ActionResult Index()

        {
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
        }

        public ActionResult ApplyForNationalSeat(/*string Level*/)

        {
            ElectionCatalog db = new ElectionCatalog();
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                //ViewBag.Level = Level;
                //return View();


                //User Candidate = new User();
                string user = (string)Session["UserName"];
                var Candidate = from candidate in db.Users
                                   where candidate.UserName.Equals(user)
                                   && candidate.isApproved == true
                                   select candidate;

				//if(Candidate.FirstOrDefault().isApproved == true)
                if (Candidate!= null)
                {
                    var notApplied = new List<Election>();
					IQueryable<Election> temp = (from City in db.Elections
												 
												 select City);

                    notApplied = temp.ToList<Election>();

                    return View(notApplied);
                }

                return RedirectToAction("Index", "CandidateHome"); ;
            }

        }
        public ActionResult ApplyForProvincialSeat(/*string Level*/)

        {
            ElectionCatalog db = new ElectionCatalog();
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                //ViewBag.Level = Level;
                //return View();


                // User Candidate = new User();

                string user = (string)Session["UserName"];

                var Candidate = from candidate in db.Users
                                where candidate.UserName.Equals(user)
                                && candidate.isApproved == true
                                select candidate;

                if (Candidate != null)
                {
                    var notApplied = new List<Election>();
                    IQueryable<Election> temp = from City in db.Elections
                                                 select City;

                    notApplied = temp.ToList<Election>();

                    return View(notApplied);
                }

                return RedirectToAction("Index", "CandidateHome"); 
            }

        }
        [HttpPost]
        public ActionResult ApproveNational(List<Election> notApproved)
        {
            ElectionCatalog db = new ElectionCatalog();
            var approved = from Election in notApproved
                           where Election.isApproved == true
                           select Election;
			CandidateApplication candidateApplication = null;
            foreach (var item in approved)
            {
				candidateApplication = new CandidateApplication();
				var city =    from election in db.Elections
                              where election.ID == item.ID
                              select election.City;


                candidateApplication.City = city.FirstOrDefault() as string;
                candidateApplication.Candidate = (string)Session["UserName"];
                candidateApplication.Election_Id = item.ID;
                candidateApplication.Level = "National";
                db.CandidateApplications.Add(candidateApplication);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
                
                

        }
        [HttpPost]
        public ActionResult ApproveProvincial(List<Election> notApproved)
        {
            ElectionCatalog db = new ElectionCatalog();
            var approved = from Election in notApproved
                           where Election.isApproved == true
                           select Election;
			CandidateApplication candidateApplication = null;
            foreach (var item in approved)
            {
				candidateApplication = new CandidateApplication();
				var city = from election in db.Elections
                           where election.ID == item.ID
                           select election.City;


                
                candidateApplication.City = city.FirstOrDefault() as string;
                candidateApplication.Candidate = (string)Session["UserName"];
                candidateApplication.Election_Id = item.ID;
                candidateApplication.Level = "Provincial";
                db.CandidateApplications.Add(candidateApplication);
            }

            db.SaveChanges();
            return RedirectToAction("Index");



        }

    }
}