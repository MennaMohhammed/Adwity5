using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adwity.Models;

namespace Adwity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult redirect(int id) 
        {
            adwityEntities db = new adwityEntities();
            User user = db.Users.Find(id);
            if (user.IsPharmacy)
                return Redirect("/pharmacy");
            else
            {
                return Redirect("/user");
            }
        }
        public ActionResult lgout()
        {
            Session["id"] = null;
            return Redirect("/");
        }
    }
}