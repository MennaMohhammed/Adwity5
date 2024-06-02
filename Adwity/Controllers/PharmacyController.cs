using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adwity.Repositories;

namespace Adwity.Controllers
{
    public class PharmacyController : Controller
    {
        // GET: Pharmacy
        public ActionResult Index()
        {
            if(Session["id"] == null)
                return Redirect("/");
            ViewBag.medicines = Fetch.PharmacyHome(3);
            return View();
        }
        public ActionResult NewMedicine() 
        {
            if (Session["id"] == null)
                return Redirect("/");
            return View();
        }
        public ActionResult Edit(int id)
        {
            if (Session["id"] == null)
                return Redirect("/");
            ViewBag.medicine = Fetch.MedicineInfo(id);
            return View();
        }
    }
}