using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using Test.ViewModels;


namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public readonly TestContext db = new TestContext();

        public ActionResult Index(int? id)
        {
            if(id.HasValue)
                ViewBag.TeamName = db.Teams.Single(t => t.ID == id).Name;

            return View(db.Teams.ToList());
        }

        public ActionResult Details(int id)
        {
            var team = db.Teams.Single(t => t.ID == id);
            return View(team.ToDetailsVM(db));
        }

        [HttpPost]
        public ActionResult Details(DetailsViewModel detailsVM)
        {
            detailsVM.UpdateCorrespondingTeam(db);
            return RedirectToAction("Index", new { id = detailsVM.ID });
        }
    }
}