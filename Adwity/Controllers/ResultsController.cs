using Adwity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adwity.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult one(string name, string branches)
        {
            if (Session["id"] == null)
                return Redirect("/");
            ViewBag.medicines = Fetch.AltMedicine(name, branches);
            return View();
        }
        public ActionResult two(string name, string alt, string branches)
        {
            if (Session["id"] == null)
                return Redirect("/");
            ViewBag.medicines = Fetch.RepMedicine(name, alt, branches);
            return View();
        }
        public ActionResult three(string name)
        {
            if (Session["id"] == null)
                return Redirect("/");
            ViewBag.medicine = Fetch.MedicineInfo(name);
            return View();
        }
    }
}