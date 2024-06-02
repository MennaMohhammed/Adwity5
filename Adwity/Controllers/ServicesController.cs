using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adwity.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult one()
        {
            if (Session["id"] == null)
                return Redirect("/");
            return View();
        }
        public ActionResult two() 
        {
            if (Session["id"] == null)
                return Redirect("/");
            return View();
        }
        public ActionResult three() 
        {
            if (Session["id"] == null)
                return Redirect("/");
            return View();
        }
    }
}