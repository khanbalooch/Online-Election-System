using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Project_Server.Models;

namespace Web_Project_Server.Controllers
{
    public class ElectionsController : Controller
    {
        private ElectionCatalog db = new ElectionCatalog();

        // GET: Elections
        public ActionResult Index()
        {
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View(db.Elections.ToList());
        }

        // GET: Elections/Details/5

        // GET: Elections/Create
        public ActionResult Create(string Level)
        {
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}
			Session.Add("Level", Level);
            return View();
        }
        // POST: Elections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Election election, string[] checkedItems)
        {
			if (Session["UserName"] == null)
			{
				return RedirectToAction("Index", "Login");
			}
			int maxId = db.Elections.Max(e => e.ID);
            election.Level = Session["Level"].ToString();

            for (int i = 0; i < checkedItems.Length; i++)
            {
                maxId++;
                election.City = checkedItems[i];
                election.ID = maxId;

                Election temp = new Election(election);
                db.Elections.Add(temp);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Elections/Edit/5
        // POST: Elections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}