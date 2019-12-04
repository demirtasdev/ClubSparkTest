using ClubSparkTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubSparkTest.Controllers
{
    public class TeamController : Controller
    {
        public readonly SportslabsContext db = new SportslabsContext();

        public ActionResult ListAll()
        {
            var teams = db.Teams.ToList();

            return View(teams);
        }
    }
}